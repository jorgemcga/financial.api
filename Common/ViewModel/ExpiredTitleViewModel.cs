using System.Collections.Generic;
using System.Linq;
using Financial.API.Common.Entities;

namespace Financial.API.Common.ViewModel
{
    public class ExpiredTitleViewModel
    {
        public int Id { get; set; }
        public string DebtorName { get; set; }
        public decimal FeesPercent { get; set; }
        public decimal FinePercent { get; set; }
        public virtual IList<ExpiredTitlePortionViewModel> Portions { get; set; }

        public ExpiredTitleViewModel() { }

        public ExpiredTitleViewModel(ExpiredTitleEntity entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                DebtorName = entity.DebtorName;
                FeesPercent = entity.FeesPercent;
                FinePercent = entity.FinePercent;
                Portions = (from portion in entity.Portions
                            select new ExpiredTitlePortionViewModel(portion)).ToList();
            }
        }
    }
}
