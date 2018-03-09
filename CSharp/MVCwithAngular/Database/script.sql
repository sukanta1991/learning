USE [learning]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userDetails](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NULL,
	[AccessAllowed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[books](
	[bookId] [int] IDENTITY(1,1) NOT NULL,
	[bookName] [varchar](50) NOT NULL,
	[authors] [varchar](50) NOT NULL,
	[readbook] [varchar](10) NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[bookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[skills](
	[skillId] [int] IDENTITY(1,1) NOT NULL,
	[skills] [varchar](50) NULL,
	[trained] [bit] NULL,
	[userId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[skillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginByUsernamePassword]   
@username varchar(50),   
@password varchar(50)   
AS   
BEGIN   
SELECT id, username, password   
FROM Login   
WHERE username = @username   
AND password = @password   
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_hasAccess](@user varchar(50))
RETURNS INT
AS
BEGIN

RETURN (SELECT ISNULL((SELECT 
			AccessAllowed AS ACCESS 
		FROM userDetails
		WHERE userName = @user),0))
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_updateSkills]
(
	@skills varchar(50),
	@trained varchar(5),
	@userName varchar(50)
)
as
BEGIN
BEGIN TRY
	Declare @userID int = (select userid 
							from  userDetails 
							where userName = @userName
							and AccessAllowed = 1)
	IF(@userID is NULL OR @userID < 1)
		Return 0
	UPDATE skills 
	set trained = case when @trained = 'No' then 0 else 1 end
	where userId = @userID
	and skills = @skills
	
	Return 1
END TRY		
BEGIN CATCH
	RETURN -1
END CATCH
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_insertSkills]
(
	@skills varchar(50),
	@trained varchar(5),
	@userName varchar(50)
)
as
BEGIN
BEGIN TRY
	Declare @userID int = (select userid 
							from  userDetails 
							where userName = @userName
							and AccessAllowed = 1)
	IF(@userID is NULL OR @userID < 1)
		Return 0
	ELSE IF EXISTS( 
			SELECT 1 
			from skills 
			where userId = @userID
			  AND skills = @skills)
		RETURN -1
	BEGIN TRAN
	BEGIN TRY
	INSERT INTO skills 
		(skills,trained,userID) values
		(@skills,case when @trained = 'No' then 0 else 1 end,@userID)
	COMMIT TRAN
	Return 1
	END TRY
	BEGIN CATCH
	ROLLBACK
	END CATCH
	
END TRY		
BEGIN CATCH
	RETURN -2
END CATCH
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_deleteSkills]
(
	@skills varchar(50),
	@userName varchar(50)
)
as
BEGIN
BEGIN TRY
	Declare @userID int = (select userid 
							from  userDetails 
							where userName = @userName
							and AccessAllowed = 1)
	IF(@userID is NULL OR @userID < 1)
		Return 0
	ELSE IF EXISTS( 
			SELECT 1 
			from skills 
			where userId = @userID
			  AND skills = @skills)
		DELETE FROM skills
		where userId = @userID
			  AND skills = @skills 
	Return 1
	RETURN -1
END TRY		
BEGIN CATCH
	RETURN -2
END CATCH
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[ufn_getSkills]
(
	@userName varchar(50)
)
RETURNS @tabRes TABLE(
userName varchar(50),
Skills varchar(50),
trained varchar(5)
)
as
BEGIN
	INSERT INTO @tabRes
	select 
		@userName, 
		skills, 
		case when trained = 0 then 'No'
			else 'Yes' END
	from skills
	where 
		userId in (select userId 
				   from userDetails
				   where userName = @userName)
	RETURN
END
GO
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [DF__books__readbook__014935CB]  DEFAULT ('No') FOR [readbook]
GO
ALTER TABLE [dbo].[skills]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[userDetails] ([userId])
GO
