namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerDetail")]
    public partial class PerDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PerDetailId { get; set; }

        [Required]
        [StringLength(50)]
        public string code_action { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
