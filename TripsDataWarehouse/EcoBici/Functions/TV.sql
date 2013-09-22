
CREATE FUNCTION [EcoBici].[TV](@IdOrigen INT,@IdDestino	INT)
RETURNS INT
AS
BEGIN	
	DECLARE 
		 @cant_tiempos			NUMERIC(18)
		,@retorno				INT

	SELECT @cant_tiempos = count(*)
	FROM [EcoBici].[TVTable]
	WHERE IdEstacionOrigen = @IdOrigen
	  AND IdEstacionDestino = @IdDestino
	
	SELECT @retorno = TiempoDeViaje
	FROM [EcoBici].[TVTable]
	WHERE ID_Random = cast(((SELECT RandomNumber FROM [EcoBici].[RandomV])*@cant_tiempos) AS INT)
	  AND IdEstacionOrigen = @IdOrigen
	  AND IdEstacionDestino = @IdDestino

	RETURN @retorno
END