BEGIN
	DECLARE @ModeratorId uniqueidentifier;
	SELECT @ModeratorId = Id from tblModerator where Moderator = 'Moderator1'

	DECLARE @BGameId uniqueidentifier;
	SELECT @BGameId = Id from tblGame where GameType = 'Sports'

	INSERT INTO tblBracket(Id, ModeratorId, BracketName, ImageSource, GameId)
	VALUES
	(NEWID(), @ModeratorId, 'Bracket1', '/img5.jpg', @BGameId)
END