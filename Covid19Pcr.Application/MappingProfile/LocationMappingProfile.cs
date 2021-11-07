using AutoMapper;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.MappingProfile
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Locations, GetlocationsAndLabWithTestDayVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Labs, opt => opt.MapFrom(l => l.Labs.Select(a => new LabVm
                {
                    Id = a.Id,
                    Name = a.Name,

                    TestDays = a.TestDays.Select(t => new TestDayVm
                    {
                        Id = t.Id,
                        Date = t.Date.ToLongDateString()
                    })
                })));
        }

    }
}
