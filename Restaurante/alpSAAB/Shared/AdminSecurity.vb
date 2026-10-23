Imports System.Security.Cryptography

Public Module AdminSecurity
    Private failures As Integer
    Private blockedUntil As DateTime
    Private ReadOnly gate As New Object()
    Private Const Iterations As Integer = 100000

    Public Function HashPassword(ByVal password As String) As String
        If String.IsNullOrEmpty(password) Then Throw New ArgumentException("La clave no puede estar vacía.")
        Dim salt(15) As Byte
        Using random = RandomNumberGenerator.Create()
            random.GetBytes(salt)
        End Using
        Using derive As New Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)
            Return "PBKDF2$" & Iterations & "$" & Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(derive.GetBytes(32))
        End Using
    End Function

    Public Function Verify(ByVal password As String, ByVal encoded As String) As Boolean
        SyncLock gate
            If DateTime.UtcNow < blockedUntil Then Return False
            Dim valid As Boolean = False
            Try
                Dim parts = If(encoded, String.Empty).Split("$"c)
                If parts.Length = 4 AndAlso parts(0) = "PBKDF2" AndAlso Not String.IsNullOrEmpty(password) Then
                    Dim count As Integer
                    If Integer.TryParse(parts(1), count) AndAlso count >= Iterations AndAlso count <= 1000000 Then
                        Dim expected = Convert.FromBase64String(parts(3))
                        Dim salt = Convert.FromBase64String(parts(2))
                        If expected.Length = 32 AndAlso salt.Length = 16 Then
                            Using derive As New Rfc2898DeriveBytes(password, salt, count, HashAlgorithmName.SHA256)
                                Dim actual = derive.GetBytes(32)
                                Dim difference As Integer = 0
                                For i = 0 To actual.Length - 1
                                    difference = difference Or (actual(i) Xor expected(i))
                                Next
                                valid = difference = 0
                            End Using
                        End If
                    End If
                End If
            Catch ex As FormatException
                valid = False
            End Try
            If valid Then
                failures = 0
            Else
                failures += 1
                If failures >= 5 Then
                    blockedUntil = DateTime.UtcNow.AddMinutes(1)
                    failures = 0
                End If
            End If
            Return valid
        End SyncLock
    End Function
End Module
