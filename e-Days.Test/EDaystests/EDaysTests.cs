using e_Days.DataLayer.Entities;
using e_Days.Domain.Models;
using FakeItEasy;
using System.Linq;
using Xunit;

namespace e_Days.Test.EDaystests
{
    public class EDaysTests
    {
        private readonly EDaysTestHelpers _helpers;

        public EDaysTests()
        {
            _helpers = new EDaysTestHelpers();
        }

        [Fact]
        public async void GetMessageByDayRepository_RightInput_ShouldReturnOkWithData()
        {
            //Given
            var iEDaysRepository = _helpers.GenerateFakeEDaysRepository();
            var entity = _helpers.CreateMessageOfTheDayList()
                .Where(d => d.Day == "monday")
                .FirstOrDefault();
            A.CallTo(() => iEDaysRepository.GetMessageByDay("Monday"))
                .Returns(_helpers.CreateMessageOfTheDayList()
                .Where(d => d.Day == "monday").SingleOrDefault());

            //When
            var response = await iEDaysRepository.GetMessageByDay("Monday");

            //Then
            Assert.Equal(entity.Day, response.Day);
            Assert.Equal(entity.Message, response.Message);
            Assert.Equal(entity.ImageUri, response.ImageUri);
        }

        [Fact]
        public async void GetMessageByDayRepository_WrongInput_ShouldReturnNull()
        {
            //Given
            var iEDaysRepository = _helpers.GenerateFakeEDaysRepository();
            MessageOfTheDay returnValue = null;

            var model = _helpers.CreateMessageOfTheDayList()
                .Where(d => d.Day == "monday")
                .FirstOrDefault();
            var c = A.CallTo(() => iEDaysRepository.GetMessageByDay("SomeData")).Returns(returnValue);

            //When
            var response = await iEDaysRepository.GetMessageByDay("SomeData");

            //Then
            Assert.Null(response);
        }

        [Fact]
        public async void GetMessageByDayService_RightInput_ShouldReturnOkWithData()
        {
            //Given
            var iEDaysService = _helpers.GenerateFakeEDaysServicve();
            var model = _helpers.CreateMessageOfTheDayList()
                .Where(d => d.Day == "monday")
                .FirstOrDefault();
            A.CallTo(() => iEDaysService.GetMessageByDay("Monday"))
                .Returns(_helpers.CreateMessageOfTheDayModelList()
                .Where(d => d.Day == "monday").SingleOrDefault());

            //When
            var response = await iEDaysService.GetMessageByDay("Monday");

            //Then
            Assert.Equal(model.Day, response.Day);
            Assert.Equal(model.Message, response.Message);
            Assert.Equal(model.ImageUri, response.ImageUri);
        }

        [Fact]
        public async void GetMessageByDayService_WrongInput_ShouldReturnNull()
        {
            //Given
            var iEDaysService = _helpers.GenerateFakeEDaysServicve();
            MessageOfTheDayModel returnValue = null;

            var model = _helpers.CreateMessageOfTheDayList()
                .Where(d => d.Day == "monday")
                .FirstOrDefault();
            var c = A.CallTo(() => iEDaysService.GetMessageByDay("SomeData")).Returns(returnValue);

            //When
            var response = await iEDaysService.GetMessageByDay("SomeData");

            //Then
            Assert.Null(response);
        }
    }
}
