namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flight")]
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            DurationFlights = new HashSet<DurationFlight>();
            Transits = new HashSet<Transit>();
        }

        [StringLength(100)]
        public string FlightId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string OriginAP { get; set; }

        [Required]
        [StringLength(100)]
        public string DestinationAP { get; set; }

        public int TotalSeat { get; set; }

        public int? isActive { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport Airport1 { get; set; }

        public virtual DefineSizeFlight DefineSizeFlight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DurationFlight> DurationFlights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transit> Transits { get; set; }
    }
}
