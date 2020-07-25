using e_Days.DataLayer.Entities;
using System.Threading.Tasks;

namespace e_Days.DataLayer.Contracts
{
    public interface IEDaysRepository
    {
        Task<MessageOfTheDay> GetMessageByDay(string day);
    }
}
