CREATE PROCEDURE [EcoBici].[InsertTV] 
AS
BEGIN 
	
	DECLARE
		 @estacion_origen			int
		,@estacion_origen_anterior	int 
		,@estacion_destino			int
		,@estacion_destino_anterior	int		
		,@tiempo_uso				int
		,@id_random					numeric(10)	
	
	DELETE TVTable

	DECLARE TV_c CURSOR
	FOR SELECT EstacionOrigen
			  ,EstacionDestino
			  ,TiempoUso
		FROM [EcoBici].[Trips]
		ORDER BY EstacionOrigen,EstacionDestino
	 
	OPEN  TV_c
	FETCH TV_c INTO @estacion_origen, @estacion_destino, @tiempo_uso

	SET @estacion_origen_anterior = -1
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF ((@estacion_origen_anterior <> @estacion_origen) or (@estacion_destino_anterior <> @estacion_destino))
				SET @id_random = 1
						
			INSERT INTO [EcoBici].[TVTable]
					(ID_Random,IdEstacionOrigen,IdEstacionDestino,TiempoDeViaje)	
				VALUES
					(@id_random,@estacion_origen,@estacion_destino,@tiempo_uso)
													
			SET @id_random = @id_random + 1
			SET @estacion_origen_anterior = @estacion_origen
			SET @estacion_destino_anterior = @estacion_destino

			FETCH TV_c INTO @estacion_origen, @estacion_destino, @tiempo_uso
		END
END