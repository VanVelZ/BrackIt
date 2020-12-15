INSERT INTO tblMessage(Id, Text, SendDate)
	VALUES
	(NEWID(), 'Hello', GETDATE()),
	(NEWID(), 'How are you?', GETDATE()),
	(NEWID(), 'OK', GETDATE()),
	(NEWID(), 'Bye', GETDATE())
