using e_Days.DataLayer.Entities;

namespace e_Days.Domain.Models
{
    public class MessageOfTheDayModel
    {
        public static explicit operator MessageOfTheDayModel(MessageOfTheDay item)
        {
            if (item == null)
                return null;

            return new MessageOfTheDayModel
            {
                Day = item.Day,
                Message = item.Message,
                ImageUri = item.ImageUri
            };
        }

        public string Day { get; set; }
        public string Message { get; set; }
        public string ImageUri { get; set; }
    }
}
