--Creating database
Create Learning

--Using the database
USE Learning

--Creating table Login
CREATE TABLE [dbo].[Login](   
[id] [int] IDENTITY(1,1) NOT NULL,   
[username] [varchar](50) NOT NULL,   
[password] [varchar](50) NOT NULL,   
CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED   
(   
[id] ASC   
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]   
) ON [PRIMARY] 

--Creating database for Authentication
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

--Inserting data into the table to test
insert into Login(username, password) values
('test','test')
