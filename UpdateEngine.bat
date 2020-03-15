echo set current directory
cd /d %~dp0

git pull
git submodule update --init
git submodule update --remote -- "Src"

pause