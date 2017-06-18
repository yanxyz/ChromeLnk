If WScript.Arguments.Count < 3 Then
  MsgBox "Not enough parameters." & vbCrLf & "Usage: shortcut.vbs exe lnk args", vbCritical
  WScript.Quit(1)
End If

strExe = WScript.Arguments(0)
strLnk = WScript.Arguments(1)
strTemp = Replace(WScript.Arguments(2), "\q", """")
strArgs = Replace(strTemp, "\b", " ")

' WScript.Echo(strArgs)

Set fso = CreateObject("Scripting.FileSystemObject")
If Not fso.FileExists(strExe) Then
  MsgBox "chrome.exe does not exist." & vbCrLf & vbCrLf & strExe, vbCritical
  WScript.Quit(1)
End If

strFolder = fso.GetParentFolderName(strLnk)
If Not fso.FolderExists(strFolder) Then
  fso.CreateFolder(strFolder)
End If

Sub CreateShortcut()
  Set WshShell = WScript.createObject("WScript.Shell")
  Set oShellLink = WshShell.CreateShortcut(strLnk)
  oShellLink.TargetPath = strExe
  oShellLink.Arguments = strArgs
  oShellLink.WorkingDirectory = fso.GetParentFolderName(strExe)
  oShellLink.Save
End Sub

CreateShortcut
