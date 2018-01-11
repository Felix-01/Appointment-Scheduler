CREATE DATABASE MyAppointmentDb;

Use MyAppointmentDb
Go 
CREATE TABLE [Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL
	);

CREATE TABLE [User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PPSNo] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](max) NULL,
	[Date] [date] NULL,
	[Comments] [nvarchar](max) NULL
	)
