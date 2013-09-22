CREATE TABLE [EcoBici].[EDTable] (
    [ID_Random]         INT NULL,
    [IdEstacionOrigen]  INT NULL,
    [IdEstacionDestino] INT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_IdEstacionDestino]
    ON [EcoBici].[EDTable]([IdEstacionDestino] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdEstacionOrigen]
    ON [EcoBici].[EDTable]([IdEstacionOrigen] ASC);

