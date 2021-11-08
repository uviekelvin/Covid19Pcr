USE [Covid19Pcr]
GO

/****** Object:  StoredProcedure [dbo].[sp_getBookings]    Script Date: 08/11/2021 13:21:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_getBookings]
@startDate datetime,
@endDate datetime,
@pageindex int = 1,
@pagesize int = 10,
@totalCount int OUT


as
select
b.BookingCode,b.Status,
t.Date as ScheduledDate,p.FirstName,p.SurName,p.Email,p.PhoneNumber,tt.Name as TestType,lo.Name as Location,l.Name as Lab
from dbo.[Bookings] b 
  inner join TestDays t on b.TestDayId= t.Id 
  inner join Labs l on t.LabId = l.Id
  inner join Locations lo on l.LocationId = lo.Id 
  inner join Patients p on b.PatientId = p.Id 
  inner join TestTypes tt on b.TestTypeId= tt.Id
 where CAST(t.Date As DATE) between CAST(@startDate As DATE)  and CAST(@endDate As DATE)  
	ORDER BY b.DateCreated ASC
OFFSET (@pagesize * (@pageindex -1)) ROWS FETCH NEXT @pagesize ROWS ONLY

SELECT @totalCount = COUNT(*) FROM  dbo.Bookings b
inner join TestDays t on  t.Id= b.TestDayId
where CAST(t.Date As DATE) between CAST(@startDate As DATE)  and CAST(@endDate As DATE)  
GO


