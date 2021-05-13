using System.Linq;
using Financial.API.Common.Entities;

namespace Financial.API.Common.Repositories
{
    public interface IExpiredTitleRepository
    {
        IQueryable<ExpiredTitleEntity> Get();
        ExpiredTitleEntity Insert(ref ExpiredTitleEntity model);
    }
}
