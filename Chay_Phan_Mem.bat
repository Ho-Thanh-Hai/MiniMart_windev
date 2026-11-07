@echo off
chcp 65001 >nul
title Khởi chạy Hệ thống Quản lý Siêu thị Mini (MiniMart)
color 0b

echo =======================================================================
echo     HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINIMART MANAGEMENT SYSTEM)
echo =======================================================================
echo.
echo [*] Đang kiểm tra và khởi động ứng dụng...
echo.

if exist "MiniMart_windev\bin\Debug\MiniMart_windev.exe" (
    echo [+] Đã tìm thấy tệp thực thi. Đang mở MiniMart...
    start "" "MiniMart_windev\bin\Debug\MiniMart_windev.exe"
    exit
)

echo [!] Chưa tìm thấy bản biên dịch. Đang tự động biên dịch dự án...
where msbuild >nul 2>&1
if %ERRORLEVEL% equ 0 (
    msbuild MiniMart_windev.sln /t:Build /p:Configuration=Debug
    if exist "MiniMart_windev\bin\Debug\MiniMart_windev.exe" (
        start "" "MiniMart_windev\bin\Debug\MiniMart_windev.exe"
        exit
    )
)

echo.
echo [!] Bạn có thể mở tệp giải pháp 'MiniMart_windev.sln' bằng Visual Studio
echo     và nhấn F5 (hoặc Start) để khởi chạy chương trình một cách dễ dàng!
pause
