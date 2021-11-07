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
    public class TestDayMapping : Profile
    {
        public TestDayMapping()
        {
            CreateMap<TestDays, TestDaysWithLocationVm>()
                .ForMember(x => x.Date, opt => opt.MapFrom(a => a.Date))
                .ForMember(x => x.Lab, opt => opt.MapFrom(x => x.Lab.Name))
                .ForMember(x => x.AvailableSpace, opt => opt.MapFrom(x => x.AvailableSpace))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Lab.Location.Name));
        }
    }
}
