// TODO Step1 SystemRole
namespace MvcCodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SystemRole
    {
        [Display(Name = "ID")]
        [Key]
        [Required]
        public Guid ID { get; set; }

        [Display(Name = "名稱")]
        [Required]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Name { get; set; }

        [Display(Name = "排序")]
        [Required]
        public int Sort { get; set; }

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

        public SystemRole()
        {
            this.ID = Guid.NewGuid();
            this.IsEnable = false;
            this.CreateBy = new Guid();
            this.CreateOn = DateTime.Now;
            this.SystemUsers = new List<SystemUser>();
        }

        public ICollection<SystemUser> SystemUsers { get; set; }
    }
}