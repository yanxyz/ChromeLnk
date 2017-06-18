If WScript.Arguments.Count < 1 Then
  MsgBox("missing arguments: ver")
  WScript.Quit(1)
End If

strVer = WScript.Arguments(0)

Set fso = CreateObject("Scripting.FileSystemObject")
strCwd = fso.GetParentFolderName(WScript.ScriptFullName)
strDir = fso.BuildPath(strCwd, strVer)
strLnk = fso.BuildPath(strDir, strVer & "_chrome.lnk")
strExe = fso.BuildPath(strDir, "Chrome-bin\chrome.exe")
strDataDir = fso.BuildPath(strDir, "User Data")
strCacheDir = fso.BuildPath(fso.GetSpecialFolder(2), strVer) ' %temp%\\ver

CreateShortcut()

Sub CreateShortcut()
  Set WshShell = WScript.createObject("WScript.Shell")
  Set oShellLink = WshShell.CreateShortcut(strLnk)
  oShellLink.TargetPath = strExe
  oShellLink.Arguments = "--user-data-dir=" & """" & strDataDir & """" & _
    " --disk-cache-dir=" & """" & strCacheDir & """"
  oShellLink.WorkingDirectory = strDir
  oShellLink.Save
End Sub

