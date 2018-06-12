BEGIN TRANSACTION
BEGIN TRY
BULK INSERT dbo.tblStreamerBulkData
FROM 'C:\Dev\SparkDays\streamers\db\TestFile\FL_insurance_sample.csv'
WITH
(
	FIRSTROW = 2,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)
COMMIT TRANSACTION
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH