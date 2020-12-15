BEGIN
	INSERT INTO tblModerator(Id, Moderator)
	VALUES
	(NEWID(), 'Moderator1'),
	(NEWID(), 'Moderator2'),
	(NEWID(), 'Moderator3')
END