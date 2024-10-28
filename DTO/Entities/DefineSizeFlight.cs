namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefineSizeFlight")]
    public partial class DefineSizeFlight
    {
        [Key]
        [StringLength(100)]
        public string IdFlight { get; set; }

        public int? width { get; set; }

        public int? height { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
