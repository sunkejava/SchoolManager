Install-Package Microsoft.EntityFrameworkCore.Tools   --安装Ef工具
Update-Package Microsoft.EntityFrameworkCore.Tools --更新Ef工具
Get-Help about_EntityFrameworkCore --验证安装
--使用命令建立脚本
Add-Migration 'Name'
Update-Database
--生成脚本
 Script-Migration