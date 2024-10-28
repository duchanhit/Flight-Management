namespace DTO.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChairBooked")]
    public partial class ChairBooked
    {
        [Key]
        [StringLength(100)]
        public string IDChairBooked { get; set; }

        [Required]
        [StringLength(100)]
        public string FlightId { get; set; }

        public int? XPos { get; set; }

        public int? YPos { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Time { get; set; }

        [Required]
        [StringLength(100)]
        public string TicketId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
