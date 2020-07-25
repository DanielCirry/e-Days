using e_Days.DataLayer.Contracts;
using e_Days.Domain.Contracts;
using e_Days.Domain.Models;
using System.Threading.Tasks;

namespace e_Days.Domain.Services
{
    public class EDaysService : IEDaysService
    {
        private readonly IEDaysRepository _repository;

        public EDaysService(IEDaysRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageOfTheDayModel> GetMessageByDay(string day)
        {
            if (string.IsNullOrEmpty(day))
                return null;

            var messageOfTheDay = await _repository.GetMessageByDay(day.ToLower());

            if (messageOfTheDay == null)
                return null;

            var model = new MessageOfTheDayModel
            {
                Day = messageOfTheDay.Day,
                Message = messageOfTheDay.Message,
                ImageUri = messageOfTheDay.ImageUri
            };

            return model;
        }
    }
}
