CREATE PROCEDURE [EcoBici].[InsertED] 
AS
BEGIN
	DECLARE
		 @cant_estaciones			numeric(18) 
		,@estacion_origen			int
		,@estacion_origen_anterior	int 
		,@estacion_destino			int
		,@id_random					numeric(10)
		,@retorno					int
	
	DELETE EDTable
	
	DECLARE Estaciones_c CURSOR
	FOR SELECT EstacionOrigen
			  ,EstacionDestino
		FROM [EcoBici].[Trips]
		ORDER BY EstacionOrigen
	 
	OPEN  Estaciones_c
	FETCH Estaciones_c INTO @estacion_origen, @estacion_destino

	SET @estacion_origen_anterior = -1
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF (@estacion_origen_anterior <> @estacion_origen)
				SET @id_random = 0
								
			INSERT INTO [EcoBici].[EDTable] 
					(ID_Random,IdEstacionOrigen,IdEstacionDestino)
				VALUES
					(@id_random,@estacion_origen,@estacion_destino)
						
			SET @id_random = @id_random + 1
			SET @estacion_origen_anterior = @estacion_origen

			FETCH Estaciones_c INTO @estacion_origen, @estacion_destino			
		END
END