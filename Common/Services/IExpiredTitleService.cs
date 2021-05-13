using System.Collections.Generic;
using Financial.API.Common.ViewModel;

namespace Financial.API.Common.Services
{
    public interface IExpiredTitleService
    {
        ICollection<ExpiredTitleViewModel> Get();
        ExpiredTitleViewModel Insert(ExpiredTitleViewModel request);
    }
}