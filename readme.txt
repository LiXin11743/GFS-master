用户名：admin
密码：admin



环境：vs 2010 + sql 2008 + 4.0 framework
环境不符的想运行可以发布到本地iis，release里就是项目编译好的文件；附加不了数据库的有sql 2005和2008的数据脚本，运行前先创建一个名为ZGZY的数据库

注意：
1.运行脚本后，用户表（tbUser）需要设置UserId、UserPwd两个字段区分大小写，否则登陆时不区分用户名和密码的大小写。
设置：设计 - 列属性 - 排序规则 - 区分大小写
2.发布iis后需要配置html映射，否则访问登陆页面不会被FormsAuthentication带到登陆页面，而是js带到的登陆页面，如果出现这种url就对了：
http:www.***.com/admin/login.html?ReturnUrl=%2fadmin%2findex.html
配置html映射方法：
IIS 控制台 - 定位到应用程序 - 处理程序映射 - 添加 - *.html 找到4.0 Framework下的aspnet_isapi.dll
机器是32bit的系统就选32位下framework的aspnet_isapi.dll，是64得选64位下的aspnet_isapi.dll，否则不起效果


源码里以下地方打了广告，不喜欢可以删掉：
1.UI层html目录下的：ui_myinfo.html里；
2.DALFactory类库下Factory.cs里；
3.Common类库下SqlHelper.cs里



QQ群：33353329
Blog：oppoic.cnblogs.com

本系统下载地址：http://www.cnblogs.com/oppoic/p/html_js_ashx_easyui_authorize.html
