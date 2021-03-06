USE [2C2P_Antaresa]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 12/18/2019 7:58:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] [varchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [varchar](10) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[UploadDate] [datetime] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000001', CAST(1000.00 AS Decimal(18, 2)), N'USD', CAST(0x0000AB1C00735B40 AS DateTime), N'A', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000002', CAST(2000.00 AS Decimal(18, 2)), N'USD', CAST(0x0000AB1D00735B40 AS DateTime), N'R', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000003', CAST(3000.00 AS Decimal(18, 2)), N'USD', CAST(0x0000AB1E00735B40 AS DateTime), N'D', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000004', CAST(4000.00 AS Decimal(18, 2)), N'USD', CAST(0x0000AB1F00735B40 AS DateTime), N'A', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000005', CAST(5000.00 AS Decimal(18, 2)), N'IDR', CAST(0x0000AB2000735B40 AS DateTime), N'R', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000006', CAST(6000.00 AS Decimal(18, 2)), N'IDR', CAST(0x0000AB2100735B40 AS DateTime), N'D', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000007', CAST(7000.00 AS Decimal(18, 2)), N'IDR', CAST(0x0000AB2200735B40 AS DateTime), N'A', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000008', CAST(8000.00 AS Decimal(18, 2)), N'THB', CAST(0x0000AB2300735B40 AS DateTime), N'R', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000009', CAST(9000.00 AS Decimal(18, 2)), N'THB', CAST(0x0000AB2400735B40 AS DateTime), N'D', CAST(0x00008EAC00735B40 AS DateTime))
INSERT [dbo].[Transaction] ([TransactionID], [Amount], [CurrencyCode], [TransactionDate], [Status], [UploadDate]) VALUES (N'Invoice0000010', CAST(10000.00 AS Decimal(18, 2)), N'THB', CAST(0x0000AB2500735B40 AS DateTime), N'A', CAST(0x00008EAC00735B40 AS DateTime))
