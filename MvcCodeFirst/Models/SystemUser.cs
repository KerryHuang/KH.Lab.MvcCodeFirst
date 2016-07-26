// TODO Step2 SystemUser
namespace MvcCodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SystemUser
    {
        [Display(Name = "ID")]
        [Key]
        [Required]
        public Guid ID { get; set; }

        [Display(Name = "帳號")]
        [Required]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "長度不可小於 5")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [StringLength(200)]
        [MinLength(5, ErrorMessage = "長度不可小於 5")]
        [MaxLength(200, ErrorMessage = "長度不可超過 200")]
        public string Password { get; set; }

        [Display(Name = "名稱")]
        [Required]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(200)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(200, ErrorMessage = "長度不可超過 200")]
        public string Email { get; set; }

        [Display(Name = "是否使用")]
        [Required]
        public bool IsEnable { get; set; }

        [Display(Name = "建立者")]
        [Required]
        public Guid CreateBy { get; set; }

        [Display(Name = "建立時間")]
        [Required]
        public DateTime CreateOn { get; set; }

        [Display(Name = "更新者")]
        public Guid? UpdateBy { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? UpdateOn { get; set; }

        public SystemUser()
        {
            this.ID = Guid.NewGuid();
            this.IsEnable = false;
            this.CreateBy = new Guid();
            this.CreateOn = DateTime.Now;
            this.SystemRoles = new List<SystemRole>();
        }

        public ICollection<SystemRole> SystemRoles { get; set; }
    }
}