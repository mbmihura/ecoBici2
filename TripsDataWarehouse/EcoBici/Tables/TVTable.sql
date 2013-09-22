CREATE TABLE [EcoBici].[TVTable] (
    [ID_Random]         INT NULL,
    [IdEstacionOrigen]  INT NULL,
    [IdEstacionDestino] INT NULL,
    [TiempoDeViaje]     INT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_IdEstacionDestinoTV]
    ON [EcoBici].[TVTable]([IdEstacionDestino] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdEstacionOrigenTV]
    ON [EcoBici].[TVTable]([IdEstacionOrigen] ASC);

