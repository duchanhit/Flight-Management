namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transit")]
    public partial class Transit
    {
        [StringLength(100)]
        public string transitID { get; set; }

        [Required]
        [StringLength(100)]
        public string flightID { get; set; }

        [Required]
        [StringLength(100)]
        public string airportID { get; set; }

        public int? transitOrder { get; set; }

        public TimeSpan? transitTime { get; set; }

        public string transitNote { get; set; }

        public int? isActive { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport Airport1 { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Flight Flight1 { get; set; }
    }
}
