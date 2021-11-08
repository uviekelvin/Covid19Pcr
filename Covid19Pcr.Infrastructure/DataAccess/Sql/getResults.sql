
GO

/****** Object:  StoredProcedure [dbo].[sp_getTestResults]    Script Date: 08/11/2021 12:18:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getTestResults]
	-- Add the parameters for the stored procedure here

@pageindex int = 1,
@pagesize int = 10,
@resultType int=0,
@totalCount int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select tr.ResultType as ResultType,tr.Remarks as Remarks,
	CONCAT(p.FirstName,',', p.SurName) as Patient,l.Name as Lab,
	lo.Name as Location,td.Date as ScheduleDate 

	from TestResults tr 
	inner join Bookings b on b.Id = tr.BookingsId
	inner join TestDays td on b.TestDayId = td.Id
	inner join Labs l on l.Id= td.LabId
	inner join Locations lo on lo.Id= l.LocationId
	inner join Patients p on b.PatientId= p.Id
	where (@resultType = 0 OR tr.ResultType = @resultType)
	and b.Status='Completed'
		ORDER BY b.DateCreated ASC
OFFSET (@pagesize * (@pageindex -1)) ROWS FETCH NEXT @pagesize ROWS ONLY


SELECT @totalCount = COUNT(*) FROM  TestResults tr
inner join Bookings b on tr.BookingsId= b.Id
where (@resultType = 0  OR tr.ResultType = @resultType) 
and b.Status='Completed'
END
GO


