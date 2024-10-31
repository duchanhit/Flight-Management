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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DurationFlight()
        {
            ChairBookeds = new HashSet<ChairBooked>();
            Tickets = new HashSet<Ticket>();
        }

        [Required]
        [StringLength(100)]
        public string IDFlight { get; set; }

        public TimeSpan? Duration { get; set; }

        [Key]
        [StringLength(100)]
        public string IDDurationFlight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChairBooked> ChairBookeds { get; set; }

        public virtual Flight Flight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
