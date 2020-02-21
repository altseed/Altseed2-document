echo set current directory
cd /d %~dp0

git pull
git submodule update --init

pause