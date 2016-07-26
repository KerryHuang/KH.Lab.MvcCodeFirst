// TODO Step3 SampleContext
namespace MvcCodeFirst.Models
{
    using System.Data.Entity;

    public class SampleContext : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }

        // TODO Step4 Add Web.config
        public SampleContext()
            : base("name=DefaultConnection")
        { }

        // TODO Step5 開啟套件管理器主控台
        // TODO Step6 輸入「Enable-Migrations」
        // TODO Step7 再輸入「 Add-Migration Init」
        // TODO Step8 最後使用「 Update-Database」完成資料庫合併

    }
}