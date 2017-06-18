# chrome-windows

Some handy tools for Chrome/Windows.

## Usage

### extract

Extract the chrome_installer.exe and create a shortcut for it under the folder
"lnk", then double click the shortcut will launch that version of Chrome.

Prepare:

1. download [7za.exe](http://www.7-zip.org/download.html) and put it into this folder.
1. download chrome_installer.exe and put it into the folder "exe".

Tips: You could download chrome_installer.exe from
[this page](http://www.geocities.jp/ecvcn/exam/chrome_installer.html),
however the download links of the old installers are out of date.

```bat
node extract.js exe\43.0.2357.130_chrome_installer.exe
```

### shortcut

create a shortcut for a specified chrome.

```bat
copy config-sample.js config.js
subl.exe config.js
node shortcut.js name
rem the opposite: delete the shortcut and user-data-dir
node shortcut.js name -d
```

subl.exe is Sublime Text editor, you could use your favorite editor.

## License

MIT (c) Ivan Yan
