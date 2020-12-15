BEGIN
	DECLARE @SendUserId uniqueidentifier;
	SELECT @SendUserId = Id from tblUser where Email = 'email@address.com'

	DECLARE @ReceivedUserId uniqueidentifier;
	SELECT @ReceivedUserId = Id from tblUser where Email = 'email@gmail.com'

	/*DECLARE @MessageID uniqueidentifier;*/
	SELECT @MessageID = Id from tblMessage where Text = 'Hello'

	INSERT INTO tblUserChat(Id, SentUserId, ReceivedUserId, MessageId)
	VALUES
	(NEWID(), @SendUserId, @ReceivedUserId, @MessageID)
END