
On Error Resume Next

Set WshShell = Wscript.CreateObject("Wscript.Shell") 
Set fso = CreateObject("Scripting.FileSystemObject") 

'ɾ���ֶ������������ԭ����LOMSϵͳ��ݷ�ʽ
fso.DeleteFile(WshShell.SpecialFolders("Desktop") & "\ԭ����LOMSϵͳ.lnk")

'ɾ���ֶ�������D:\JingXinWMSĿ¼�ľɳ���
fso.DeleteFolder("D:\JingXinWMS")
 
Set WshShell = Nothing 
Set fso = Nothing 
