CREATE PROCEDURE [EcoBici].[LoadTripsFromCSVFile]
AS
	DELETE [EcoBici].[Trips]

	BULK INSERT [EcoBici].[Trips]
	FROM 'c:\recorrido-bicis-2012.csv' --TODO: set using sp params
	WITH
	(
		FIRSTROW = 1,
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n'
	)
RETURN 0