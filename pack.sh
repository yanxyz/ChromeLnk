#/bin/bash

name="ChromeLnk.zip"

if [ -e "$name" ]; then
  rm $name
fi

zip -jq $name\
  src/WindowsFormsApplication1/bin/release/ChromeLnk.exe\
  src/WindowsFormsApplication1/bin/release/RunProcessAsTask.dll\
  README.md\
  MIT-License
