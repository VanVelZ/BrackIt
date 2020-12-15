BEGIN
	DECLARE @Team1 uniqueidentifier
	SELECT @Team1 = Id from tblTeam where TeamName = 'Team1'

	DECLARE @Team2 uniqueidentifier
	SELECT @Team2 = Id from tblTeam where TeamName = 'Team2'

	DECLARE @BracketId uniqueidentifier
	SELECT @BracketId = Id from tblBracket where Name = 'Bracket1'

	/*DECLARE @GameId uniqueidentifier*/
	SELECT @GameId = Id from tblGame where GameType = 'Action'

	INSERT INTO tblMatch(Id, Team1, Team2, Outcome, DueDate, ScheduledDate, BracketId, GameId, ReportingPlayer, Round)
	VALUES
	(NEWID(), @Team1, @Team2, NEWID(), GETDATE(), GETDATE(), @BracketId, @GameId, NEWID(), 1)

	SELECT @Team1 = Id from tblTeam where TeamName = 'Team3'
	SELECT @Team2 = Id from tblTeam where TeamName = 'Team4'
	SELECT @BracketId = Id from tblBracket where Name = 'Bracket2'
	SELECT @GameId = Id from tblGame where GameType = 'Sports'

	INSERT INTO tblMatch(Id, Team1, Team2, Outcome, DueDate, ScheduledDate, BracketId, GameId, ReportingPlayer, Round)
	VALUES
	(NEWID(), @Team1, @Team2, NEWID(), GETDATE(), GETDATE(), @BracketId, @GameId, NEWID(), 1)
END