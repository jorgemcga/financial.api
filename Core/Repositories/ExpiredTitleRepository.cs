using System.Linq;
using Financial.API.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Financial.API.Common.Data;
using Financial.API.Common.Entities;

namespace Financial.API.Core.Repositories
{
    public class ExpiredTitleRepository : DbContext, IExpiredTitleRepository
    {
        /// <summary>
        /// context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// construcor
        /// </summary>
        /// <param name="context"></param>
        public ExpiredTitleRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public IQueryable<ExpiredTitleEntity> Get()
            => _context.ExpiredTitle
                       .Include(e => e.Portions);

       
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExpiredTitleEntity Insert(ref ExpiredTitleEntity model)
        {
            _context.ExpiredTitle.Add(model);
            _context.SaveChanges();

            return model;
        }
    }
}
