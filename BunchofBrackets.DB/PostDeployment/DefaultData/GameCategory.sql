BEGIN
	DECLARE @CategoriesId uniqueidentifier;
	SELECT @CategoriesId = Id from tblCategories where CategoryName = 'Action'
	Declare @GameId uniqueIdentifier;
	SELECT @GameId = Id from tblGame where GameType = 'Action';

	INSERT INTO tblGameCategory(Id, CategoriesId, GameId)
	VALUES
	(NEWID(), @CategoriesId, @GameId)

	SELECT @CategoriesId = Id from tblCategories where CategoryName = 'Strategy'
	SELECT @GameId = Id from tblGame where GameType = 'Strategy';
	INSERT INTO tblGameCategory(Id, CategoriesId, GameId)
	VALUES
	(NEWID(), @CategoriesId, @GameId)

	SELECT @CategoriesId = Id from tblCategories where CategoryName = 'Puzzle'
	SELECT @GameId = Id from tblGame where GameType = 'Puzzle';
	INSERT INTO tblGameCategory(Id, CategoriesId, GameId)
	VALUES
	(NEWID(), @CategoriesId, @GameId)

	SELECT @CategoriesId = Id from tblCategories where CategoryName = 'Sports'
	SELECT @GameId = Id from tblGame where GameType = 'Sports';
	INSERT INTO tblGameCategory(Id, CategoriesId, GameId)
	VALUES
	(NEWID(), @CategoriesId,@GameId)
END