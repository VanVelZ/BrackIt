/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS tblUser
DROP TABLE IF EXISTS tblBracket
DROP TABLE IF EXISTS tblCategories
DROP TABLE IF EXISTS tblFriend
DROP TABLE IF EXISTS tblGame
DROP TABLE IF EXISTS tblGameCategory
DROP TABLE IF EXISTS tblMatch
DROP TABLE IF EXISTS tblMessage
DROP TABLE IF EXISTS tblTeam
DROP TABLE IF EXISTS tblTeamChat
DROP TABLE IF EXISTS tblUserChat
DROP TABLE IF EXISTS tblUserTeam
DROP TABLE IF EXISTS tblModerator