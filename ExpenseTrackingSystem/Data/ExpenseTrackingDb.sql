USE [master]
GO
/****** Object:  Database [ExpenseTrackingDB]    Script Date: 11/9/2025 4:13:31 PM ******/
CREATE DATABASE [ExpenseTrackingDB]
 
USE [ExpenseTrackingDB]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 11/9/2025 4:13:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](512) NULL,
	[Date] [datetime2](7) NOT NULL,
	[ExpenseType] [nvarchar](50) NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseTypes]    Script Date: 11/9/2025 4:13:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseTypes](
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ExpenseType] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/9/2025 4:13:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'aee8ffe1-9d70-4db3-81ca-04bd44443592', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(290.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-12T07:32:00.9130000' AS DateTime2), N'Utilities', CAST(N'2025-11-09T07:39:54.7736522' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'373500e5-c98d-4339-b449-1260d60ce41a', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(125.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-23T07:32:00.9130000' AS DateTime2), N'Travel', CAST(N'2025-11-09T07:41:19.1435945' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'3020730a-7618-4521-8143-1b189afd7f02', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(2300.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-10T07:32:00.9130000' AS DateTime2), N'Travel', CAST(N'2025-11-09T07:39:33.7850161' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'575bdf9f-8fb8-4c73-8656-1b80e5b035c4', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(1820.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-27T07:32:00.9130000' AS DateTime2), N'Entertainment', CAST(N'2025-11-09T07:41:39.8814048' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'856a71e0-5f11-4ffd-819c-20047c8eec9d', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(120.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-15T07:32:00.9130000' AS DateTime2), N'Groceries', CAST(N'2025-11-09T07:40:32.9969800' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'31e64c7e-2f1d-4495-bc02-29d4ad608754', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(405.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-22T07:32:00.9130000' AS DateTime2), N'Groceries', CAST(N'2025-11-09T07:40:44.0308096' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'795ec213-0a86-45a5-8802-2a0639bbe05a', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(100.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-01T07:32:00.9130000' AS DateTime2), N'Travel', CAST(N'2025-11-09T07:38:47.5990253' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'825cdb6c-e1fe-4cfb-9bd9-38f5147b8a36', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(220.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-28T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:37:52.8075536' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'3bc747d7-55e7-472a-8bbd-438ac129e81f', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(220.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-01T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:38:38.3795799' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'3bf3a943-9007-4a17-8aac-4ee912fcf8ea', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(700.00 AS Decimal(18, 2)), N'', CAST(N'2025-11-07T07:32:00.9130000' AS DateTime2), N'Utilities', CAST(N'2025-11-09T07:35:55.7170685' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'6128140e-87e5-4228-8f1e-52a3568fb9a7', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(18500.00 AS Decimal(18, 2)), N'Rent', CAST(N'2025-11-09T07:32:00.9130000' AS DateTime2), N'Rent', CAST(N'2025-11-09T07:34:08.0364373' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'bc81e8d3-9cb4-4632-8912-7fb108ed2780', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(127.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-29T07:32:00.9130000' AS DateTime2), N'Groceries', CAST(N'2025-11-09T07:41:54.4163946' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'd1a3fb13-6966-4d28-8315-829830d651b6', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(1100.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-08T07:32:00.9130000' AS DateTime2), N'Travel', CAST(N'2025-11-09T07:39:21.2539519' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'3178bdee-5e96-4b17-9127-8a5ef36f70c9', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(200.00 AS Decimal(18, 2)), N'', CAST(N'2025-11-04T07:32:00.9130000' AS DateTime2), N'Utilities', CAST(N'2025-11-09T07:35:44.4472488' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'b2940ced-5fd4-4357-a702-8c50e37f339d', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(200.00 AS Decimal(18, 2)), N'', CAST(N'2025-11-01T07:32:00.9130000' AS DateTime2), N'Utilities', CAST(N'2025-11-09T07:35:33.2995490' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'b68f1b87-7b95-43e3-ba13-938ecabf5c33', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(300.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-22T07:32:00.9130000' AS DateTime2), N'Utilities', CAST(N'2025-11-09T07:40:51.5287525' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'c75e8a88-a35b-465d-82ac-9533439daf8b', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(450.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-05T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:39:05.6005032' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'74078b1e-29ca-4a2b-8089-ac738fdbf3de', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(150.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-29T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:37:44.9207595' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'00d5ec9c-e320-4a91-a63c-b5b81fe88187', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(19200.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-01T07:32:00.9130000' AS DateTime2), N'Rent', CAST(N'2025-11-09T07:38:55.5009034' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'7d2b61cf-d4ae-49e4-8ed6-b71e43c24d38', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(7000.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-30T07:32:00.9130000' AS DateTime2), N'Travel', CAST(N'2025-11-09T07:42:09.3537652' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'1cded211-1b41-44e0-8940-cc90c457394c', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(89.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-13T07:32:00.9130000' AS DateTime2), N'Groceries', CAST(N'2025-11-09T07:40:26.3130753' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'a1b9b541-97f4-45df-bd1d-f5c6496d73e9', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(22300.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-31T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:37:14.5920847' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'3976ec2b-5052-4492-9505-f5caed24d9c5', N'5c59d726-fe77-443c-8c40-4b0bf42959ca', CAST(800.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-12T07:32:00.9130000' AS DateTime2), N'Food', CAST(N'2025-11-09T07:39:46.8839329' AS DateTime2))
GO
INSERT [dbo].[Expenses] ([Id], [UserId], [Amount], [Description], [Date], [ExpenseType], [CreatedOnUtc]) VALUES (N'f4a99807-bae2-4f95-ac61-fda54089f525', N'98086867-54fb-4fb9-9e16-28c959616612', CAST(18500.00 AS Decimal(18, 2)), N'', CAST(N'2025-10-01T07:32:00.9130000' AS DateTime2), N'Rent', CAST(N'2025-11-09T07:36:11.8272906' AS DateTime2))
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Entertainment')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Food')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Groceries')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Rent')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Travel')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Unknown')
GO
INSERT [dbo].[ExpenseTypes] ([Name]) VALUES (N'Utilities')
GO
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (N'98086867-54fb-4fb9-9e16-28c959616612', N'user1@example.com', N'Password123')
GO
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (N'5c59d726-fe77-443c-8c40-4b0bf42959ca', N'user2@example.com', N'Password234')
GO
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (N'82dd9851-4649-4f05-a9ae-b031824a8445', N'user3@example.com', N'Password345')
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_ExpenseTypes] FOREIGN KEY([ExpenseType])
REFERENCES [dbo].[ExpenseTypes] ([Name])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_ExpenseTypes]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMonthlyExpenseOfUser]    Script Date: 11/9/2025 4:13:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

-- EXEC sp_GetMonthlyExpenseOfUser @UserId='98086867-54FB-4FB9-9E16-28C959616612', @Year=2025, @Month=0, @ExpenseType= 'Utilities'
CREATE PROCEDURE [dbo].[sp_GetMonthlyExpenseOfUser] 
@UserId uniqueIdentifier,
@Year int = NULL,
@Month int = NULL,
@ExpenseType nvarchar(50) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @Year IS NULL
		SET @Year = Year(GetDate())

	IF @Month IS NULL OR @Month = 0 OR @Month > 12
		SET @Month = Month(GetDate())

    -- Insert statements for procedure here
	SELECT [Date] as ExpenseDate, ExpenseType, Amount, [Description] FROM Expenses 
	WHERE 
	UserId = @UserId
	AND Year([Date]) = @Year
	AND Month([Date]) = @Month
	AND (ExpenseType = @ExpenseType OR @ExpenseType = '')
END
GO
USE [master]
GO
ALTER DATABASE [ExpenseTrackingDB] SET  READ_WRITE 
GO
