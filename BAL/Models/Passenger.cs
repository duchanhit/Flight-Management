namespace BAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger()
        {
            Tickets = new HashSet<Ticket>();
        }

        [StringLength(100)]
        public string PassengerId { get; set; }

        [Required]
        [StringLength(50)]
        public string PassengerName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassengerIDCard { get; set; }

        [Required]
        [StringLength(50)]
        public string PassenserTel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
