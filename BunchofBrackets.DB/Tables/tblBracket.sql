CREATE TABLE [dbo].[tblBracket]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ModeratorId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ImageSource] NVARCHAR(255) NOT NULL, 
    [Game] NVARCHAR(50) NOT NULL, 
    [OriginalRoundCount] INT NOT NULL, 
    [CurrentDivision] INT NOT NULL 
)
