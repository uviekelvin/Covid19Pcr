using Covid19Pcr.Domain.Enums;
using Covid19Pcr.Domain.Exceptions;
using CovidPcr.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPcr.Tests.Domains
{
    [TestFixture]
    public class BookingTest
    {


        [Test]
        public void CreateBooking_IfPatientAlreadyHasBooking_ShouldThrowAnException()
        {
            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.Exception);
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.InstanceOf<DomainException>());
        }

        [Test]
        public void CreateBooking_IfTestDateBehindCurrentDate_ShouldThrowAnException()
        {
            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            testDay.Date = DateTime.Now.AddDays(-1);
            var ex = Assert.Throws<DomainException>(() => patient.CreateBooking(testDay, 1));
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.InstanceOf<DomainException>());
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.Exception);
            Assert.AreSame("Cannot Scheduled booking in the past", ex.Message);
        }

        [Test]
        public void CreateBooking_IfNoSpaceAvailableForTestDay_ShouldThrowAnException()
        {
            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            testDay.AvailableSpace = 0;
            var ex = Assert.Throws<DomainException>(() => patient.CreateBooking(testDay, 1));
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.InstanceOf<DomainException>());
            Assert.That(() => patient.CreateBooking(testDay, 1), Throws.Exception);
            Assert.AreSame("No available space to book", ex.Message);
        }

        [Test]
        public void CreateBooking_IfTestDayAvailable_ShouldCreateBooking()
        {
            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            Assert.That(patient.Bookings.Count(), Is.EqualTo(1));
        }
        [Test]
        public void CancelBooking_IfBookingNotFound_ShouldThrowException()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            var ex = Assert.Throws<DomainException>(() => patient.CancelBooking("23457"));
            Assert.AreSame("Booking not found", ex.Message);
        }
        [Test]
        public void CancelBooking_IfBookingAlreadyCompleted_ShouldThrowAnException()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);

            var booking = patient.Bookings.FirstOrDefault();

            booking.Status = Covid19Pcr.Domain.Enums.BookingStatus.Completed;
            Assert.That(() => patient.CancelBooking(booking.BookingCode), Throws.InstanceOf<DomainException>());
            Assert.That(() => patient.CancelBooking(booking.BookingCode), Throws.Exception);

        }

        [Test]
        public void CancelBooking_IfBookingAlreadyCancelled_ShouldThrowAnException()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);

            var booking = patient.Bookings.FirstOrDefault();

            booking.Status = Covid19Pcr.Domain.Enums.BookingStatus.Cancelled;
            var ex = Assert.Throws<DomainException>(() => patient.CancelBooking(booking.BookingCode));
            Assert.AreSame("Booking already cancelled", ex.Message);

        }

        [Test]
        public void CancelBooking_IfBookingBooked_ShouldCancelBooking()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            var booking = patient.Bookings.FirstOrDefault();
            patient.CancelBooking(booking.BookingCode);
            Assert.AreEqual(booking.Status, BookingStatus.Cancelled);
            Assert.That(testDay.AvailableSpace, Is.EqualTo(1));

        }

        [Test]
        public void AddTestResult_IfBookingCancelled_ShouldThrowException()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            var booking = patient.Bookings.FirstOrDefault();
            patient.CancelBooking(booking.BookingCode);

            var ex = Assert.Throws<DomainException>(() => booking.AddTestResult(LabResultTypes.Positive, ""));
            Assert.That($"Test result cannot be added for a {booking.Status} booking", Is.EqualTo(ex.Message));

        }


        [Test]
        public void AddTestResult_IfBookingCompleted_ShouldThrowException()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            var booking = patient.Bookings.FirstOrDefault();
            booking.AddTestResult(LabResultTypes.Positive, "");
            var ex = Assert.Throws<DomainException>(() => booking.AddTestResult(LabResultTypes.Positive, ""));
            Assert.That($"Test result cannot be added for a {booking.Status} booking", Is.EqualTo(ex.Message));

        }


        [Test]
        public void AddTestResult_IfBookingBooked_ShouldAddTestTesults()
        {

            var patient = MockData.GetPatients().FirstOrDefault(x => x.Email == "uviekelvin@gmail.com");
            var testDay = MockData.GetTestDay();
            patient.CreateBooking(testDay, 1);
            var booking = patient.Bookings.FirstOrDefault();
            booking.AddTestResult(LabResultTypes.Positive, "");

            Assert.That(booking.TestResult, Is.Not.Null);
            Assert.That(booking.TestResult.ResultType, Is.EqualTo(LabResultTypes.Positive));

        }
    }
}
