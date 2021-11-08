using Covid19Pcr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPcr.Tests.Mock
{
    public static class MockData
    {

        public static List<Patients> GetPatients()
        {
            return new List<Patients>
            {
                new Patients
                {
                   FirstName = "Uvie",
                   SurName ="Oghenejakpor",
                   Email="uviekelvin@gmail.com",
                   PhoneNumber="07059647234"
                   
,                },
                   new Patients
                {
                   FirstName = "James",
                   SurName ="Kelvin",
                   Email="uviejakpor@gmail.com",
                   PhoneNumber="07059647233"
,                }
            };
        }



        public static TestDays GetTestDay()
        {
            return new TestDays
            {
                AvailableSpace = 1,
                Date = DateTime.Now,
                DateCreated = DateTime.Now,
                LabId = 1,
                Lab = new Labs
                {
                    Id = 1,
                    Name = "Apapa Medic",
                    LocationId = 1,
                    Location = new Locations
                    {
                        Name = "Apapa",
                        Id = 1,
                    }
                }


            };
        }
    }
}
