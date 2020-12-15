BEGIN 
	DECLARE @MessageId uniqueidentifier;
	SELECT @MessageId = Id from tblMessage where Text = 'Hello'

	DECLARE @TeamId uniqueidentifier;
	SELECT @TeamId = Id from tblTeam where TeamName = 'Team1'

	INSERT INTO tblTeamChat(Id, MessageId, TeamId)
	VALUES
	(NEWID(), @MessageId, @TeamId)
END