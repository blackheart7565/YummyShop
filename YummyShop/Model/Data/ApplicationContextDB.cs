using Accessibility;
using Microsoft.EntityFrameworkCore;
using YummyShop.Model.DataBaseTableModel;

namespace YummyShop.Model.Data {
    /// <summary>
    /// Класс подключения к БД || создание БД
    /// </summary>

    public class ApplicationContextDB : DbContext {

        public DbSet<Users> Users { get; set; }

        public ApplicationContextDB() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CI6CQHH\\SQL_BLACK_HEART;Initial Catalog=YummyShopDataBase;User ID=sa;Password=55986;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
