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
            Permissions = new HashSet<Permission>();
        }

        [Key]
        [StringLength(100)]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        [StringLength(50, ErrorMessage = "Tên người dùng không được quá 50 ký tự")]
        public string AccountUser { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50, ErrorMessage = "Mật khẩu không được quá 50 ký tự")]
        public string AccountPass { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50, ErrorMessage = "Email không được quá 50 ký tự")]
        public string Gmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
