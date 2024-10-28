namespace DTO.Entites
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
            Permissions = new HashSet<Permission>();
        }

        [StringLength(100)]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "Account cannot be empty.")]
        [StringLength(50, ErrorMessage = "Account cannot exceed 50 characters.")]
        public string AccountUser { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        public string AccountPass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
