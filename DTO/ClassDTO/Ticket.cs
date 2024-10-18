namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            ChairBookeds = new HashSet<ChairBooked>();
        }

        [StringLength(100)]
        public string TicketId { get; set; }

        [Required]
        [StringLength(100)]
        public string TicketIDPassenger { get; set; }

        [Required]
        [StringLength(100)]
        public string ClassId { get; set; }

        [Required]
        [StringLength(100)]
        public string FlightId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? timeFlight { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TimeBooking { get; set; }

        public int? isPaid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChairBooked> ChairBookeds { get; set; }

        public virtual Class Class { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
