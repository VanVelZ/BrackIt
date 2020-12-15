BEGIN
	INSERT INTO tblGame(Id, GameType)
	VALUES
	(NEWID(), 'Action'),
	(NEWID(), 'Strategy'),
	(NEWID(), 'Puzzle'),
	(NEWID(), 'Sports')
END