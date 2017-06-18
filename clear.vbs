If WScript.Arguments.Count < 2 Then
  MsgBox "Not enough parameters." & vbCrLf & "Usage: clear.vbs lnk userdatadir", vbCritical
  WScript.Quit(1)
End If

strLnk = WScript.Arguments(0)
strDir = Replace(WScript.Arguments(1), "\q", """")

Set fso = CreateObject("Scripting.FileSystemObject")

If fso.FileExists(strLnk) Then
  fso.DeleteFile(strLnk)
End If

If fso.FolderExists(strDir) Then
  fso.DeleteFolder(strDir)
End If
