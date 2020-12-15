BEGIN
	INSERT INTO tblTeam(Id, TeamName, ImageSource)
	VALUES
	(NEWID(), 'Team1', '/img4.jpg'),
	(NEWID(), 'Team2', '/img5.jpg'),
	(NEWID(), 'Team3', '/img6.jpg'),
	(NEWID(), 'Team4', '/img7.jpg')
END