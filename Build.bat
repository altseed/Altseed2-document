cd /d %~dp0

rmdir /s /q References
rmdir /s /q Site
rmdir /s /q obj
rmdir /s /q Src\Engine\obj

docfx metadata
docfx build