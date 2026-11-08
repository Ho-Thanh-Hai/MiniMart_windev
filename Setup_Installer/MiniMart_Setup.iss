; =========================================================================
; KỊCH BẢN ĐÓNG GÓI CÀI ĐẶT INNO SETUP - ĐỒ ÁN MINIMART (WINDEV)
; Tự động tạo Setup Wizard cài đặt hoàn chỉnh cho Windows
; Tạo Shortcut Desktop, Start Menu và đính kèm CSDL SQL Server tự động
; =========================================================================

#define MyAppName "Hệ thống Quản lý Siêu thị Mini (MiniMart)"
#define MyAppVersion "1.0"
#define MyAppPublisher "Nhóm WinDev - Trường ĐH Sư Phạm TP.HCM"
#define MyAppExeName "MiniMart_windev.exe"

[Setup]
AppId={{E584D29C-A20B-4E38-9B5B-8B40FE86B021}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\MiniMart_WinDev
DefaultGroupName=MiniMart WinDev
AllowNoIcons=yes
OutputDir=..\Output_Installer
OutputBaseFilename=MiniMart_Setup_v1.0
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Tệp thực thi chính và cấu hình
Source: "..\MiniMart_windev\bin\Debug\MiniMart_windev.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\MiniMart_windev\bin\Debug\MiniMart_windev.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\MiniMart_windev\bin\Debug\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
; Kịch bản CSDL và tệp khởi chạy nhanh
Source: "..\Database\QuanLySieuThiMini.sql"; DestDir: "{app}\Database"; Flags: ignoreversion
Source: "..\Chay_Phan_Mem.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\README.md"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\Cấu hình CSDL SQL Server"; Filename: "{app}\{#MyAppExeName}"; Parameters: "--config"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
