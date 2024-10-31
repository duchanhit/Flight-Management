namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [StringLength(100)]
        public string AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountUser { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountPass { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
