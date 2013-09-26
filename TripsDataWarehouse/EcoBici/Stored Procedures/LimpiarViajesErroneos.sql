Create PROCEDURE [EcoBici].[LimpiarViajesErroneos]
AS
BEGIN
	-- Elimina viajes que duren mas de 480 minutos, ya que si bien pueden suceder distorcionarian los resultados como el % de uso de bicis del sistema que es lo que realmente interesa obtener.
	DELETE [TripsDataWarehouse].[EcoBici].[TVTable]
	WHERE TiempoDeViaje > 480	
	
END;