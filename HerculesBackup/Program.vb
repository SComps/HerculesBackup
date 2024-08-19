Imports System
Imports System.Collections.Immutable
Imports System.IO

Module Program
    Dim copies As Integer = 12
    Dim dasdsource As String = ""
    Dim backupdest As String = ""
    Sub Main(args As String())
        Console.WriteLine("Hercules Backup-2024 S Johnson")
        If args.Count < 3 Then
            Console.WriteLine("You must specify three parameters.")
            Console.WriteLine("<copies> <source dasd dir> <backup destination>")
            End
        Else
            copies = Val(args(0))
            dasdsource = args(1)
            backupdest = args(2)
            Dim recap As String = "Backing up {0} to {1}.{2}"
            Console.WriteLine(String.Format(recap, dasdsource, backupdest, ""))
            BackupTemp()
            RotateDirs()
        End If
    End Sub

    Sub BackupTemp()
        ' Copy source to a temp directory under backupdest
        Dim dasdList As List(Of String) = IO.Directory.EnumerateFiles(dasdsource).ToList
        Dim TempDest As String = backupdest & ".temp"
        IO.Directory.CreateDirectory(TempDest)
        For Each f As String In dasdList
            Dim FileInfo As New DirectoryInfo(f)
            Dim baseName As String = FileInfo.Name
            Console.WriteLine(f & " --> " & TempDest & "/" & baseName)
            FileCopy(f, TempDest & "/" & baseName)
        Next
    End Sub

    Sub RotateDirs()
        'First check to see if there's a <copies> directory.
        'If there is, delete it, it's no longer needed in the rotation
        If Directory.Exists(backupdest & "." & copies.ToString) Then
            Console.WriteLine("Removing " & backupdest & "." & copies)
            Directory.Delete(backupdest & "." & copies, True)
        Else
            Console.WriteLine("Backup rotation has not exceeded it's rotation copies.")
        End If
        For i = (copies - 1) To 1 Step -1
            Dim oldDir As String = backupdest & "." & i
            Dim newDir As String = backupdest & "." & i + 1
            If Directory.Exists(oldDir) Then
                Console.WriteLine("Moving " & oldDir & " to " & newDir)
                Directory.Move(oldDir, newDir)
            Else
                Console.WriteLine("Rotation " & i & " has not been used.")
            End If
        Next
        'Move Temp into .1
        If Directory.Exists(backupdest & ".temp") Then
            Console.WriteLine("Moving temp backup to .1")
            Directory.Move(backupdest & ".temp", backupdest & ".1")
        Else
            Console.WriteLine("Unable to move the temporary backup.  It doesn't exist!")
        End If
    End Sub
End Module
