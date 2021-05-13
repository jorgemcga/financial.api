using System;
using Financial.API.Common.Entities;

namespace Financial.API.Common.ViewModel
{
    public class ExpiredTitlePortionViewModel
    {
        public int Id { get; set; }
        public int ExpiredTitleId { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }

        public ExpiredTitlePortionViewModel() { }

        public ExpiredTitlePortionViewModel(ExpiredTitlePortionEntity entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                ExpiredTitleId = entity.ExpiredTitleId;
                Value = entity.Value;
                DueDate = entity.DueDate;
            }
        }
    }
}