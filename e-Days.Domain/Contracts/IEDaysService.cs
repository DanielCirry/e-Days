using e_Days.Domain.Models;
using System.Threading.Tasks;

namespace e_Days.Domain.Contracts
{
    public interface IEDaysService
    {
        Task<MessageOfTheDayModel> GetMessageByDay(string day);
    }
}
