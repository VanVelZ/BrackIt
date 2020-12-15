BEGIN
	/*DECLARE @TeamId uniqueidentifier;*/
	SELECT @TeamId = Id from tblTeam where TeamName = 'Team1'

	DECLARE @UserId uniqueidentifier;
	SELECT @UserId = Id from tblUser where Email = 'email@gmail.com'

	INSERT INTO tblUserTeam(Id, TeamId, UserId)
	VALUES
	(NEWID(), @TeamId, @UserId)

	SELECT @TeamId = Id from tblTeam where TeamName = 'Team2'
	SELECT @UserId = Id from tblUser where Email = 'email@address.com'

	INSERT INTO tblUserTeam(Id, TeamId, UserId)
	VALUES
	(NEWID(), @TeamId, @UserId)
END