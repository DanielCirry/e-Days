using e_Days.DataLayer.Contracts;
using e_Days.DataLayer.DbContexts;
using e_Days.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace e_Days.DataLayer.Repositories
{
    public class EDaysRepository : IEDaysRepository
    {
        private readonly EDaysDbContext _context;

        public EDaysRepository(EDaysDbContext context)
        {
            _context = context;
        }

        public async Task<MessageOfTheDay> GetMessageByDay(string day)
        {
            if (string.IsNullOrEmpty(day))
                return null;

            return await _context.MessageOfTheDays.Where(d => d.Day == day).FirstOrDefaultAsync();
        }
    }
}
