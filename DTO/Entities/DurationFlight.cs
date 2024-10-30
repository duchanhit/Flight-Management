namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DurationFlight")]
    public partial class DurationFlight
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string IDFlight { get; set; }

        public TimeSpan? Duration { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string IDDurationFlight { get; set; }
    }
}
