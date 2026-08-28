
using versta.Models;
using Microsoft.EntityFrameworkCore;

namespace versta.Shared
{
    /// <summary>
    /// Класс контекста подключения к БД: осуществляет запросы к БД.
    /// </summary>
    public class ApplicationContext : DbContext
    {

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Delivery> Deliverys { get; set; } = null!;
        public DbSet<Models.Endpoint> Endpoints { get; set; } = null!;
        public DbSet<Cargo> Cargos { get; set; } = null!;

        public DatabaseConfig config_;

        public ApplicationContext(DatabaseConfig config)
        {
            config_ = config;
            if (!Database.CanConnect())
            {
                throw new ArgumentException($"Ошибка подключения к базе данных: база данных недоступна.");
            }
        }
        /// <summary>
        /// Подключенеи к БД
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={config_.dbHost};Port={config_.dbPort};Database={config_.dbName};Username={config_.dbUser};Password={config_.dbPass}");
        }
        /// <summary>
        /// Спецификация сущностей в БД
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>(entity =>
            {
                // === НАСТРОЙКА ТАБЛИЦЫ ===
                entity.ToTable("Order", "public");

                // === ПЕРВИЧНЫЙ КЛЮЧ ===
                entity.HasKey(o => o.ID);

                entity.Property(o => o.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Delivery>(entity =>
            {
                // === НАСТРОЙКА ТАБЛИЦЫ ===
                entity.ToTable("Delivery", "public");

                // === ПЕРВИЧНЫЙ КЛЮЧ ===
                entity.HasKey(d => d.OrderID);

                // === ВНЕШНИЙ КЛЮЧ ===
                entity.HasOne(d => d.Cargo)
                    .WithMany(c => c.Deliverys)
                    .HasForeignKey(d => d.CargoID)
                    .HasConstraintName("FK_Cargo_Delivery")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.SenderEndpoint)
                    .WithMany(e => e.Deliverys_sender)
                    .HasForeignKey(d => d.SenderID)
                    .HasConstraintName("FK_Endpoint_sid_Delivery")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.RecipientEndpoint)
                    .WithMany(e => e.Deliverys_recipient)
                    .HasForeignKey(d => d.RecipientID)
                    .HasConstraintName("FK_Endpoint_rid_Delivery")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Order)
                    .WithOne(o => o.Delivery)
                    .HasForeignKey<Delivery>(d => d.OrderID)
                    .HasConstraintName("FK_Order_Delivery")
                    .OnDelete(DeleteBehavior.Cascade);

                // === НАСТРОЙКА ПОЛЕЙ ===
                entity.Property(d => d.OrderID)
                    .HasColumnName("OrderID")
                    .HasColumnOrder(0)
                    .IsRequired();

                entity.Property(d => d.CargoID)
                    .HasColumnName("CargoID")
                    .HasColumnOrder(1)
                    .IsRequired();

                entity.Property(d => d.SenderID)
                    .HasColumnName("SenderID")
                    .HasColumnOrder(2)
                    .IsRequired();

                entity.Property(d => d.RecipientID)
                    .HasColumnName("RecipientID")
                    .HasColumnOrder(3)
                    .IsRequired();

                entity.Property(d => d.Date)
                    .HasColumnName("Date")
                    .HasColumnOrder(4)
                    .IsRequired();
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                // === НАСТРОЙКА ТАБЛИЦЫ ===
                entity.ToTable("Cargo", "public");

                // === ПЕРВИЧНЫЙ КЛЮЧ ===
                entity.HasKey(c => c.ID);

                // === НАСТРОЙКА ПОЛЕЙ ===
                entity.Property(c => c.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.Weight)
                    .HasColumnName("Weight")
                    .IsRequired();
            });
            modelBuilder.Entity<Models.Endpoint>(entity =>
            {
                // === НАСТРОЙКА ТАБЛИЦЫ ===
                entity.ToTable("Endpoint", "public");

                // === ПЕРВИЧНЫЙ КЛЮЧ ===
                entity.HasKey(e => e.ID);

                // === НАСТРОЙКА ПОЛЕЙ ===
                entity.Property(c => c.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.City)
                    .HasColumnName("City")
                    .IsRequired();

                entity.Property(c => c.Address)
                    .HasColumnName("Address")
                    .IsRequired();
            });
        }
    }
}

