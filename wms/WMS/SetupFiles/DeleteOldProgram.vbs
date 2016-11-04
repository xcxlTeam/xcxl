
On Error Resume Next

Set WshShell = Wscript.CreateObject("Wscript.Shell") 
Set fso = CreateObject("Scripting.FileSystemObject") 

'删除手动拷贝到桌面的原材料LOMS系统快捷方式
fso.DeleteFile(WshShell.SpecialFolders("Desktop") & "\原材料LOMS系统.lnk")

'删除手动拷贝到D:\JingXinWMS目录的旧程序
fso.DeleteFolder("D:\JingXinWMS")
 
Set WshShell = Nothing 
Set fso = Nothing 
