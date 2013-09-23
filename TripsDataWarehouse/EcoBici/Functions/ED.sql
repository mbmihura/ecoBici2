CREATE FUNCTION [EcoBici].[ED](@IdSDE	INT)
RETURNS INT
AS
BEGIN	
	DECLARE
		 @cant_estaciones	numeric(18) 
		,@retorno			int
		
	SELECT @cant_estaciones = Count(*) 
	FROM [EcoBici].[EDTable]
	WHERE IdEstacionOrigen = @IdSDE	
	
	SELECT @retorno = IdEstacionDestino
	FROM [EcoBici].[EDTable]
	WHERE ID_Random = Cast(((SELECT RandomNumber FROM [EcoBici].[RandomV])*@cant_estaciones) AS INT)
	  AND IdEstacionOrigen = @IdSDE	

	RETURN @retorno
END