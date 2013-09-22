CREATE FUNCTION [EcoBici].[IA] (@IdEstacion INT)
RETURNS INT
AS
BEGIN    
	DECLARE 
	   @cant_intervalos  numeric(18)
	  ,@retorno    int
   
 select @cant_intervalos = count(*)
 from [EcoBici].[IATable]
 where IdEstacion = @IdEstacion
 
 select @retorno = IntervaloMinutos
 from [EcoBici].[IATable]
 where ID_Random = cast(((SELECT RandomNumber FROM [EcoBici].[RandomV])*@cant_intervalos) as int)
   and IdEstacion = @IdEstacion

 return @retorno
END