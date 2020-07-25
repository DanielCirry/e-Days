using e_Days.DataLayer.Contracts;
using e_Days.DataLayer.Entities;
using e_Days.Domain.Contracts;
using e_Days.Domain.Models;
using e_Days.Domain.Services;
using FakeItEasy;
using System.Collections.Generic;

namespace e_Days.Test
{
    public class EDaysTestHelpers
    {
        public List<MessageOfTheDay> CreateMessageOfTheDayList()
        {
            return new List<MessageOfTheDay>()
            {
                new MessageOfTheDay
                {
                    Day = "monday",
                    Message = "First day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "tuesday",
                    Message = "Second day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "wednesday",
                    Message = "Third day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "thursday",
                    Message = "Fourth day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "friday",
                    Message = "Fifth day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "saturday",
                    Message = "Sixth day of the week!"
                },
                new MessageOfTheDay
                {
                    Day = "sunday",
                    Message = "Seventh day of the week!"
                }
            };
        }

        public List<MessageOfTheDayModel> CreateMessageOfTheDayModelList()
        {
            return new List<MessageOfTheDayModel>()
            {
                new MessageOfTheDayModel
                {
                    Day = "monday",
                    Message = "First day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "tuesday",
                    Message = "Second day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "wednesday",
                    Message = "Third day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "thursday",
                    Message = "Fourth day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "friday",
                    Message = "Fifth day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "saturday",
                    Message = "Sixth day of the week!"
                },
                new MessageOfTheDayModel
                {
                    Day = "sunday",
                    Message = "Seventh day of the week!"
                }
            };

        }

        public IEDaysRepository GenerateFakeEDaysRepository()
        {
            return A.Fake<IEDaysRepository>();
        }

        public IEDaysService GenerateFakeEDaysServicve()
        {
            return A.Fake<IEDaysService>();
        }

        public EDaysService GenerateEDaysService(IEDaysRepository repository)
        {
            return new EDaysService(repository);
        }
    }
}