using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial.API.Common.Entities
{
    [Table("ExpiredTitle")]
    public class ExpiredTitleEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("debtor_name")]
        public string DebtorName { get; set; }

        [Required, Column("fees_percent")]
        public decimal FeesPercent { get; set; }

        [Required, Column("fine_percent")]
        public decimal FinePercent { get; set; }

        [NotMapped]
        public virtual HashSet<ExpiredTitlePortionEntity> Portions { get; set; }
    }
}
