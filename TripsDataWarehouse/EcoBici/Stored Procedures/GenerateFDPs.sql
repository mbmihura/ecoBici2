CREATE PROCEDURE [EcoBici].[GenerateFDPs]
AS
BEGIN	
	EXECUTE [EcoBici].[InsertED] 
	
	DECLARE @t numeric(10)
	SELECT @t = count(*) FROM [EcoBici].[EDTable]
	print 'ED has ' + CAST(@t as varchar) + 'samples.'

	EXECUTE [EcoBici].[InsertIA] 
	
	SELECT @t = count(*) FROM [EcoBici].[IATable]
	print 'IA has ' + CAST(@t as varchar) + 'samples.'

	EXECUTE [EcoBici].[InsertTV]
	
	SELECT @t = count(*) FROM [EcoBici].[TVTable]
	print 'TV has ' + CAST(@t as varchar) + 'samples.'
END