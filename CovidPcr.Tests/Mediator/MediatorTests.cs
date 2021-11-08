using AutoMapper;
using AutoMapper.Configuration;
using Covid19Pcr.Application.Commands;
using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.MappingProfile;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Models;
using Covid19Pcr.Infrastructure.DataAccess.UnitOfWork;
using CovidPcr.Tests.Mock;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CovidPcr.Tests.Mediator
{
    [TestFixture]
    public class MediatorTests
    {

        protected Mock<IUnitofWork> _uow;
        protected readonly IConfiguration _config;
        protected readonly IMapper _mapper;
        public MediatorTests()
        {
            _mapper = new MapperConfiguration(cfg =>
                    cfg.AddProfile<BookingMappingProfile>())
             .CreateMapper();
        }

        [SetUp]
        public void SetUp()
        {
            _uow = new Mock<IUnitofWork>();


        }
        [Test]
        public async Task SchdeuleTestCommand_IfTestDayAvailabe_ShouldSchdule()
        {
            var mediator = new Mock<IMediator>();

            var testDay = this._uow.Setup(m => m.Repository<TestDays>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestDays, bool>>>(), l => l.Lab, l => l.Lab.Location))
                .Returns(Task.FromResult(MockData.GetTestDay()));

            var testType =
                this._uow.Setup(m => m.Repository<TestTypes>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestTypes, bool>>>()))
                .Returns(Task.FromResult(new TestTypes { Id = 1, Name = "Test Type" }));

            var patient =
             this._uow.Setup(m => m.Repository<Patients>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Patients, bool>>>(), x => x.Bookings))
             .Returns(Task.FromResult(MockData.GetPatients().FirstOrDefault()));

            var command = new ScheduleTestCommand { Email = "uviekelvin@gmail.com", FirstName = "uvie", PhoneNumber = "07059647234", SurName = "Oghenejakpor", TestDayId = 1 };
            var handler = new ScheduleTestCommandHandler(this._uow.Object);

           var response =  await handler.Handle(command, new System.Threading.CancellationToken());

            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Code, Is.EqualTo(ApiResponseCodes.OK));
        }
        [Test]
        public async Task SchdeuleTestCommand_IfTestDayNotAvailabe_ShouldThrowException()
        {
            var mediator = new Mock<IMediator>();

            var testDay = MockData.GetTestDay();
            testDay.Date = DateTime.Now.AddDays(-1);
            this._uow.Setup(m => m.Repository<TestDays>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestDays, bool>>>(), l => l.Lab, l => l.Lab.Location))
                .Returns(Task.FromResult(testDay));

            var testType =
                this._uow.Setup(m => m.Repository<TestTypes>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestTypes, bool>>>()))
                .Returns(Task.FromResult(new TestTypes { Id = 1, Name = "Test Type" }));

            var patient =
             this._uow.Setup(m => m.Repository<Patients>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Patients, bool>>>(), x => x.Bookings))
             .Returns(Task.FromResult(MockData.GetPatients().FirstOrDefault()));

            var command = new ScheduleTestCommand { Email = "uviekelvin@gmail.com", FirstName = "uvie", PhoneNumber = "07059647234", SurName = "Oghenejakpor", TestDayId = 1 };
            var handler = new ScheduleTestCommandHandler(this._uow.Object);
            Assert.That(() => handler.Handle(command, new System.Threading.CancellationToken()).Result, Throws.Exception);
        }

        [Test]
        public async Task SchdeuleTestCommand_IfTestTypeNotFound_ShouldReturnFailedResponse()
        {
            var mediator = new Mock<IMediator>();

            var testDay = MockData.GetTestDay();
            testDay.Date = DateTime.Now.AddDays(-1);
            this._uow.Setup(m => m.Repository<TestDays>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestDays, bool>>>(), l => l.Lab, l => l.Lab.Location))
                .Returns(Task.FromResult(testDay));

            TestTypes testType = null;
            
                this._uow.Setup(m => m.Repository<TestTypes>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TestTypes, bool>>>()))
                .Returns(Task.FromResult(testType));

            var patient =
             this._uow.Setup(m => m.Repository<Patients>().GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Patients, bool>>>(), x => x.Bookings))
             .Returns(Task.FromResult(MockData.GetPatients().FirstOrDefault()));

            var command = new ScheduleTestCommand { Email = "uviekelvin@gmail.com", FirstName = "uvie", PhoneNumber = "07059647234", SurName = "Oghenejakpor", TestDayId = 1 };
            var handler = new ScheduleTestCommandHandler(this._uow.Object);
            var response = await handler.Handle(command, new System.Threading.CancellationToken());
            Assert.That(response.Data, Is.EqualTo("The selected test type is not found"));
            Assert.That(response.Code, Is.EqualTo(ApiResponseCodes.FAIL));
        }
    }
}
