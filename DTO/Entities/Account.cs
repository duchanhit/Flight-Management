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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Per_Acc = new HashSet<Per_Acc>();
            Per_Acc1 = new HashSet<Per_Acc>();
        }

        [StringLength(100)]
        public string AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountUser { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountPass { get; set; }

        [Required]
        [StringLength(50)]
        public string Gmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Per_Acc> Per_Acc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Per_Acc> Per_Acc1 { get; set; }
    }
}
