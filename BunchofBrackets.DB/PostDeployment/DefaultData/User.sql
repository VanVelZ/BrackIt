BEGIN
	INSERT INTO tblUser(Id, Email, FirstName, LastName, Password, ImageSource) 
	VALUES 
	(NEWID(),'email@address.com', 'Zach','VanderVelden','1234','/img1.jpg'),
	(NEWID(),'email@gmail.com', 'Lydia', 'Schmalz', '5678', '/img2.jpg'),
	(NEWID(),'email@fvtc.edu', 'Achraf', 'Briki', '4321', '/im3.jpg'),
	(NEWID(),'email@outlook.com', 'Stephen', 'Lee', '8765', '/img4.jpg')
END