SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

USE StreamersDB
GO
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblStreamerBulkData'  )
    BEGIN
        PRINT 'Skipping Table Create Since Table dbo.[tblStreamerBulkData] already exists ' 
    END
ELSE
BEGIN
	PRINT 'Creating table dbo.[tblStreamerBulkData]' 

	CREATE TABLE [dbo].[tblStreamerBulkData](
		[StreamerDataID] bigint NOT NULL IDENTITY(1,1),
		[policyID] [varchar](50) NOT NULL,
		[statecode] [varchar](50) NOT NULL,
		[county] [varchar](50) NOT NULL,
		[eq_site_limit] [varchar](50) NOT NULL,
		[hu_site_limit] [varchar](50) NOT NULL,
		[fl_site_limit] [varchar](50) NOT NULL,
		[fr_site_limit] [varchar](50) NOT NULL,
		[tiv_2011] [varchar](50) NOT NULL,
		[tiv_2012] [varchar](50) NOT NULL,
		[eq_site_deductible] [varchar](50) NOT NULL,
		[hu_site_deductible] [varchar](50) NOT NULL,
		[fl_site_deductible] [varchar](50) NOT NULL,
		[fr_site_deductible] [varchar](50) NOT NULL,
		[point_latitude] [varchar](50) NOT NULL,
		[point_longitude] [varchar](50) NOT NULL,
		[line] [varchar](50) NOT NULL,
		[construction] [varchar](50) NOT NULL,
		[point_granularity] [varchar](50) NOT NULL
		
		CONSTRAINT [PK_tblStreamerBulkData] PRIMARY KEY CLUSTERED 
			(
			[StreamerDataID] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
		
		
PRINT ''
PRINT 'Script Executed Successfully'
END
GO
