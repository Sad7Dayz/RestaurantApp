/*****************************************************************************************************
 *
 * Entity framework core 접속 정보
 *
 *****************************************************************************************************/

using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.DataBase.EF
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public AppDbContext()
        {

        }

        /// <summary>
        /// 고객
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 접시
        /// </summary>
        public DbSet<Dish> Dishes { get; set; }

        /// <summary>
        /// 유형별 접시
        /// </summary>
        public DbSet<TypeDish> TypeDishs { get; set; }

        /// <summary>
        /// 주문
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 결제
        /// </summary>
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// SqlServer 접속정보
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=127.0.0.1;database=RestaurantWpfDb;User ID=sa;Password=senna3700!;Encrypt=true;TrustServerCertificate=true;App=EntityFramework;");
        }
    }
}
