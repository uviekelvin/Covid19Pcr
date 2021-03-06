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
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Bookings, BookingVm>()
                 .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Patient.FirstName))
                 .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.Patient.PhoneNumber))
                 .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Patient.Email))
                 .ForMember(x => x.SurName, opt => opt.MapFrom(x => x.Patient.SurName))
                 .ForMember(x => x.Lab, opt => opt.MapFrom(x => x.TestDay.Lab.Name))
                 .ForMember(x => x.TestType, opt => opt.MapFrom(x => x.TestType.Name))
                 .ForMember(x => x.ScheduledDate, opt => opt.MapFrom(x => x.TestDay.Date))
                 .ForMember(x => x.Location, opt => opt.MapFrom(x => x.TestDay.Lab.Location.Name));


            CreateMap<TestDays, BookingCapacityVm>()
                .ForMember(x => x.Lab, opt => opt.MapFrom(x => x.Lab.Name))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Lab.Location.Name))
                .ForMember(x => x.AvailableSpace, opt => opt.MapFrom(x => x.AvailableSpace))
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date));


            CreateMap<Bookings, TestResultVm>()
                .ForMember(x => x.ScheduleDate, opt => opt.MapFrom(x => x.TestDay.Date))
                .ForMember(x => x.ResultType, opt => opt.MapFrom(x => x.TestResult.ResultType))
                .ForMember(x => x.Patient, opt => opt.MapFrom(x => $"{x.Patient.FirstName},{x.Patient.SurName}"))
                .ForMember(x => x.Lab, opt => opt.MapFrom(x => x.TestDay.Lab.Name))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.TestDay.Lab.Location.Name))
                .ForMember(x => x.Remarks, opt => opt.MapFrom(x => x.TestResult.Remarks));
        }
    }
}
