USE [GFS]
GO
/****** Object:  Table [dbo].[tbUserRole]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserRole](
	[UserId] [int] NULL,
	[RoleId] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tbUserRole] ([UserId], [RoleId]) VALUES (74, 52)
INSERT [dbo].[tbUserRole] ([UserId], [RoleId]) VALUES (72, 1)
/****** Object:  Table [dbo].[tbUserOperateLog]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserOperateLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[OperateInfo] [varchar](64) NULL,
	[Description] [varchar](max) NULL,
	[IfSuccess] [bit] NULL,
	[OperateDate] [datetime] NULL,
 CONSTRAINT [PK_tbUserOperateInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserDepartment]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserDepartment](
	[UserId] [int] NULL,
	[DepartmentId] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tbUserDepartment] ([UserId], [DepartmentId]) VALUES (72, 15)
/****** Object:  Table [dbo].[tbUser]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[UserPwd] [varchar](50) NULL,
	[IsAble] [bit] NULL,
	[IfChangePwd] [bit] NULL,
	[AddDate] [datetime] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbUser] ON
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (72, N'admin', N'管理员', N'21232F297A57A5A743894A0E4A801F', 1, 1, CAST(0x0000A2AD00ADD91E AS DateTime), N'管理员账号')
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (74, N'wangjie', N'汪杰', N'209EAE20CEF54355B3FC1086CB9CEA', 1, 1, CAST(0x0000A2D7009B9EA5 AS DateTime), N'oppoic.cnblogs.com')
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (75, N'test', N'测试用户', N'202CB962AC59075B964B07152D234B', 1, 1, CAST(0x0000A2DC00A3B365 AS DateTime), N'测试账号')
SET IDENTITY_INSERT [dbo].[tbUser] OFF
/****** Object:  Table [dbo].[tbRoleMenuButton]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRoleMenuButton](
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[ButtonId] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 7)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 8, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 8)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 8, 6)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 9, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 9)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 10)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 11)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 6)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 1, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 9, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 4, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 7, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 3, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 2, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 10, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 5, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 1, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 2, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 6, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 8, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 12)
/****** Object:  Table [dbo].[tbRole]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[AddDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_tbRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbRole] ON
INSERT [dbo].[tbRole] ([Id], [RoleName], [Description], [AddDate], [ModifyDate]) VALUES (1, N'超级管理员', N'拥有所有增删改查权限', CAST(0x0000A27301080F41 AS DateTime), CAST(0x0000A29800AAFBF4 AS DateTime))
INSERT [dbo].[tbRole] ([Id], [RoleName], [Description], [AddDate], [ModifyDate]) VALUES (52, N'浏览角色', N'仅拥有浏览菜单的权限，无增删改权限', CAST(0x0000A2D7009C9F8B AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbRole] OFF
/****** Object:  Table [dbo].[tbMenuButton]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMenuButton](
	[MenuId] [int] NULL,
	[ButtonId] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 7)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (8, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 8)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (8, 6)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (9, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 9)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 10)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 11)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 6)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 12)
/****** Object:  Table [dbo].[tbMenu]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Code] [varchar](50) NULL,
	[LinkAddress] [varchar](100) NULL,
	[Icon] [varchar](50) NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL,
 CONSTRAINT [PK_tbMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbMenu] ON
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (1, N'系统设置', 0, NULL, NULL, N'icon-cog', 1, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (2, N'其他', 0, NULL, NULL, N'icon-tux', 2, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (3, N'菜单管理', 1, N'menu', N'html/ui_menu.html', N'icon-layout', 2, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (4, N'用户管理', 1, N'user', N'html/ui_user.html', N'icon-user_suit_black', 3, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (5, N'部门管理', 1, N'department', N'html/ui_department.html', N'icon-group', 5, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (6, N'角色管理', 1, N'role', N'html/ui_role.html', N'icon-key_go', 4, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (7, N'按钮管理', 1, N'button', N'html/ui_button.html', N'icon-button', 1, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (8, N'登录日志', 2, N'loginlog', N'html/ui_loginlog.html', N'icon-drive_user', 1, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (9, N'操作日志', 2, N'operatelog', N'html/ui_operatelog.html', N'icon-table', 2, CAST(0x0000A24000EFB330 AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (10, N'Bug反馈', 2, N'bugs', N'html/ui_bugs.html', N'icon-bug', 3, CAST(0x0000A24000EFB330 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbMenu] OFF
/****** Object:  Table [dbo].[tbLoginLog]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbLoginLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Success] [bit] NULL,
	[LoginDate] [datetime] NULL,
 CONSTRAINT [PK_tbLoginInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbDepartment]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL,
 CONSTRAINT [PK_tbDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbDepartment] ON
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (1, N'人事行政部', 0, 3, CAST(0x0000A25801693D18 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (2, N'研发部', 0, 1, CAST(0x0000A258016942B9 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (3, N'技术支持', 0, 2, CAST(0x0000A25801694C97 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (4, N'人事部', 1, 1, CAST(0x0000A25801694DBA AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (5, N'行政部', 1, 2, CAST(0x0000A258016977BD AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (7, N'C#组', 2, 2, CAST(0x0000A258016988A0 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (8, N'Java组', 2, 1, CAST(0x0000A25801698D5A AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (9, N'Shell脚本组', 2, 5, CAST(0x0000A2580169A16C AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (10, N'C/C++组', 2, 4, CAST(0x0000A2580169A90E AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (11, N'宽带光纤', 3, 2, CAST(0x0000A2580169B668 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (12, N'系统运维', 3, 1, CAST(0x0000A2580169BF0C AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (15, N'人事1部', 4, 1, CAST(0x0000A29100B66FCF AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (16, N'行政1部', 5, 2, CAST(0x0000A29600AD985A AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (17, N'行政2部', 5, 1, CAST(0x0000A29600ADACB4 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (41, N'销售部', 0, 4, CAST(0x0000A2AD00B7E540 AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (43, N'销售组', 41, 1, CAST(0x0000A2AD00B8079D AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (46, N'PHP组', 2, 3, CAST(0x0000A2AD00B863C5 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbDepartment] OFF
/****** Object:  Table [dbo].[tbButton]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbButton](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_tbButton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbButton] ON
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (1, N'浏览', N'browser', N'icon-eye', 1, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (3, N'添加', N'add', N'icon-add', 3, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (4, N'修改', N'edit', N'icon-application_edit', 4, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (5, N'删除', N'delete', N'icon-delete', 5, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (6, N'导出', N'export', N'icon-page_excel', 6, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (7, N'部门设置', N'setdepartment', N'icon-group', 8, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (8, N'角色设置', N'setrole', N'icon-user_key', 7, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (9, N'角色授权', N'authorize', N'icon-key', 9, CAST(0x0000A28A00C1ED72 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (10, N'分配按钮', N'setbutton', N'icon-link', 10, CAST(0x0000A2910097FDB5 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (11, N'全部展开', N'expandall', N'icon-expand', 11, CAST(0x0000A29100ACA955 AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (12, N'全部隐藏', N'collapseall', N'icon-collapse', 12, CAST(0x0000A29100ACBC48 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbButton] OFF
/****** Object:  Table [dbo].[tbBug]    Script Date: 02/25/2014 09:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbBug](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[BugInfo] [varchar](max) NULL,
	[BugReply] [varchar](max) NULL,
	[BugDate] [datetime] NULL,
	[IfShow] [bit] NULL,
	[IfSolve] [bit] NULL,
 CONSTRAINT [PK_tbBug] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Pager]    Script Date: 02/25/2014 09:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Pager]
@tableName varchar(64),  --分页表名
@columns varchar(512),  --查询的字段
@order varchar(256),    --排序方式
@pageSize int,  --每页大小
@pageIndex int,  --当前页
@where varchar(1024) = '1=1',  --查询条件
@totalCount int output  --总记录数
as
declare @beginIndex int,@endIndex int,@sqlResult nvarchar(2000),@sqlGetCount nvarchar(2000)
set @beginIndex = (@pageIndex - 1) * @pageSize + 1  --开始
set @endIndex = (@pageIndex) * @pageSize  --结束
set @sqlresult = 'select '+@columns+' from (
select row_number() over(order by '+ @order +')
as Rownum,'+@columns+'
from '+@tableName+' where '+ @where +') as T
where T.Rownum between ' + CONVERT(varchar(max),@beginIndex) + ' and ' + CONVERT(varchar(max),@endIndex)
set @sqlGetCount = 'select @totalCount = count(*) from '+@tablename+' where ' + @where  --总数
--print @sqlresult
exec(@sqlresult)
exec sp_executesql @sqlGetCount,N'@totalCount int output',@totalCount output
--测试调用：
--declare @total int
--exec sp_Pager 'tbLoginInfo','Id,UserName,Success','LoginDate','desc',4,2,'1=1',@total output
--print @total
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuthorityByUserId]    Script Date: 02/25/2014 09:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetAuthorityByUserId]  
@userId int  --用户主键id  
as    
declare @roleIds varchar(128)  --用户所有的角色集合  
declare @sql varchar(max)    
SELECT @roleIds=REPLACE(    
(select str(ur.RoleId)+',' from tbUser u    
join tbUserRole ur on u.Id = ur.UserId where u.Id = @userId  
for xml path('')),' ','')    
--print substring(@roleids,1,len(@roleids)-1)  --打印出用户所拥有的角色id  
set @sql=    
'select m.Id menuid,m.Name menuname,m.ParentId parentid,m.Icon menuicon,mb.ButtonId buttonid,b.Name buttonname,b.Icon buttonicon,rmb.RoleId roleid,  
case      
when isnull(rmb.ButtonId,0) = 0   
then ''false'' else ''true''    
end checked    
from tbMenu m  
left join tbMenuButton mb on m.Id=mb.MenuId  
left join tbButton b on mb.ButtonId=b.Id    
left join tbRoleMenuButton rmb on (mb.MenuId=rmb.MenuId and mb.ButtonId=rmb.ButtonId and rmb.RoleId in ('    
+    
isnull(substring(@roleIds,1,len(@roleIds)-1),0)    
+'))    
order by m.ParentId,m.Sort,b.Sort'  
--print @sql    
exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckLogin]    Script Date: 02/25/2014 09:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CheckLogin]  
@ip nvarchar(50),  
@lastErrorLoginTime datetime output  
as          
declare @errorLoginCount int  --错误次数  
select @errorLoginCount = Count(1) from tbLoginLog where Success = 0 and DATEADD(MI,30,LoginDate) > GETDATE() and UserIp = @ip  
if @errorLoginCount >= 5  
begin  
 select top 1 @lastErrorLoginTime = T.LoginDate from (select top 5 LoginDate from tbLoginLog where UserIp = @ip order by LoginDate desc ) T order by LoginDate asc  
end  
else  
begin  
 set @lastErrorLoginTime = null  
end
GO
/****** Object:  Default [DF_tbUserOperateInfo_OperateDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbUserOperateLog] ADD  CONSTRAINT [DF_tbUserOperateInfo_OperateDate]  DEFAULT (getdate()) FOR [OperateDate]
GO
/****** Object:  Default [DF_tbUser_AddDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbUser] ADD  CONSTRAINT [DF_tbUser_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_tbRole_AddDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbRole] ADD  CONSTRAINT [DF_tbRole_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_tbMenu_AddDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbMenu] ADD  CONSTRAINT [DF_tbMenu_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_tbLoginInfo_LoginDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbLoginLog] ADD  CONSTRAINT [DF_tbLoginInfo_LoginDate]  DEFAULT (getdate()) FOR [LoginDate]
GO
/****** Object:  Default [DF_tbDepartment_AddDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbDepartment] ADD  CONSTRAINT [DF_tbDepartment_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_tbButton_AddDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbButton] ADD  CONSTRAINT [DF_tbButton_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_tbBug_BugDate]    Script Date: 02/25/2014 09:41:25 ******/
ALTER TABLE [dbo].[tbBug] ADD  CONSTRAINT [DF_tbBug_BugDate]  DEFAULT (getdate()) FOR [BugDate]
GO
