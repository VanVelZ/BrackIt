/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
:r .\DefaultData\Bracket.sql
:r .\DefaultData\Categories.sql
:r .\DefaultData\Friend.sql
:r .\DefaultData\Game.sql
:r .\DefaultData\GameCategory.sql
:r .\DefaultData\Match.sql
:r .\DefaultData\Message.sql
:r .\DefaultData\Team.sql
:r .\DefaultData\TeamChat.sql
:r .\DefaultData\User.sql
:r .\DefaultData\UserChat.sql
:r .\DefaultData\UserTeam.sql
:r .\DefaultData\Bracket.sql
:r .\DefaultData\Categories.sql
:r .\DefaultData\Friend.sql
:r .\DefaultData\Game.sql
:r .\DefaultData\GameCategory.sql

:r .\DefaultData\Message.sql
:r .\DefaultData\Team.sql
:r .\DefaultData\TeamChat.sql
:r .\DefaultData\User.sql
:r .\DefaultData\UserChat.sql
:r .\DefaultData\UserTeam.sql
:r .\DefaultData\Moderator.sql
*/