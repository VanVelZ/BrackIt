BEGIN 
	INSERT INTO tblCategories(Id, CategoryName)
	VALUES
	(NEWID(), 'Action'),
	(NEWID(), 'Strategy'),
	(NEWID(), 'Puzzle'),
	(NEWID(), 'Sports')
END