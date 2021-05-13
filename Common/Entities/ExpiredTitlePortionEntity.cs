using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial.API.Common.Entities
{
    [Table("ExpiredTitlePortion")]
    public class ExpiredTitlePortionEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("expiredtitle_id")]
        public int ExpiredTitleId { get; set; }

        [Required, Column("value")]
        public decimal Value { get; set; }

        [Required, Column("due_date")]
        public DateTime DueDate { get; set; }

        [NotMapped]
        public virtual ExpiredTitleEntity ExpiredTitle { get; set; }
    }
}
