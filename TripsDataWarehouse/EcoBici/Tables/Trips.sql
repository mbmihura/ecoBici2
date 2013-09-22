CREATE TABLE [EcoBici].[Trips] (
    [IdUsuario]       NUMERIC (10) NULL,
    [EstacionOrigen]  NUMERIC (4)  NULL,
    [FechaInicio]     DATETIME     NULL,
    [EstacionDestino] NUMERIC (4)  NULL,
    [FechaFin]        DATETIME     NULL,
    [TiempoUso]       NUMERIC (10) NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_EstacionOrigen]
    ON [EcoBici].[Trips]([EstacionOrigen] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EstacionDestino]
    ON [EcoBici].[Trips]([EstacionDestino] ASC);

