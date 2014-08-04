CREATE PROCEDURE [EcoBici].[InsertIA] 
AS
BEGIN 
	DECLARE 
	   @fecha_salida				datetime 
	  ,@fecha_salida_anterior		datetime
	  ,@minutos						int
	  ,@cant_intervalos				numeric(18)
	  ,@estacion_origen				int
	  ,@estacion_origen_anterior	int
	  ,@retorno						int
	  ,@id_random					numeric(10)
   
    DELETE IATable

	DECLARE Estaciones_c CURSOR
	FOR SELECT FechaInicio
			  ,EstacionOrigen
		FROM Trips
		ORDER BY EstacionOrigen, FechaInicio
	 
	OPEN Estaciones_c
	FETCH  Estaciones_c INTO @fecha_salida, @estacion_origen
  
	SET @fecha_salida_anterior = '2008-01-01'  
	SET @estacion_origen_anterior = -1  

	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF (@estacion_origen_anterior <> @estacion_origen)
				BEGIN
					SET @id_random = 0
					SET @fecha_salida_anterior = '2008-01-01'
				END			
			IF DATEDIFF(DAY,@fecha_salida_anterior,@fecha_salida) = 0 
				BEGIN
					-- cargo el intervalo en minutos de cada pasada
					SET @minutos = DATEDIFF(MINUTE,@fecha_salida_anterior,@fecha_salida)
																							
					INSERT INTO IATable
					(ID_Random,IdEstacion,IntervaloMinutos)
					VALUES
					(@id_random,@estacion_origen,@minutos)

					SET @id_random = @id_random + 1
				END 

			SET @fecha_salida_anterior = @fecha_salida  
			SET @estacion_origen_anterior = @estacion_origen

			FETCH  Estaciones_c INTO @fecha_salida, @estacion_origen
		END	
END