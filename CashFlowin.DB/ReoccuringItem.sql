CREATE TABLE [dbo].[ReoccuringItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Value] DECIMAL NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [RepeatEvery] INT NOT NULL, 
    [ReoccuranceType] NVARCHAR(50) NOT NULL, 
    [ReoccuranceModifier] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1 

)
