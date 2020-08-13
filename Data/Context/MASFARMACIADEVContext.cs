using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductsAPI.Data.Context
{
    public partial class MASFARMACIADEVContext : DbContext
    {
        public MASFARMACIADEVContext()
        {
        }

        public MASFARMACIADEVContext(DbContextOptions<MASFARMACIADEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<IdentificationsTypes> IdentificationsTypes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PostalCodes> PostalCodes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<PurchasesDetails> PurchasesDetails { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StatesOrders> StatesOrders { get; set; }
        public virtual DbSet<SubCategorys> SubCategorys { get; set; }
        public virtual DbSet<TypesOrders> TypesOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-20VCMA9\\UNDEFINEDLOCAL;Initial Catalog=MAS-FARMACIA-DEV;User Id=undefinedss;Password=Undefined.s.s.20;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("categorys", "dbo");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("clients", "dbo");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomeHeigth).HasColumnName("home_heigth");

                entity.Property(e => e.HomeStreet)
                    .HasColumnName("home_street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPostalCode).HasColumnName("id_postal_code");

                entity.Property(e => e.IdTypeIdentification).HasColumnName("id_type_identification");

                entity.Property(e => e.IdentificationNumber)
                    .IsRequired()
                    .HasColumnName("identification_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentificationsTypes>(entity =>
            {
                entity.HasKey(e => e.IdTypeIdentification);

                entity.ToTable("identifications_types", "dbo");

                entity.Property(e => e.IdTypeIdentification).HasColumnName("id_type_identification");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("orders", "dbo");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdTypeOrder).HasColumnName("id_type_order");
            });

            modelBuilder.Entity<PostalCodes>(entity =>
            {
                entity.HasKey(e => e.IdPostalCode);

                entity.ToTable("postal_codes", "dbo");

                entity.Property(e => e.IdPostalCode)
                    .HasColumnName("id_postal_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("products", "dbo");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdResoruce).HasColumnName("id_resoruce");

                entity.Property(e => e.IdSubCategory).HasColumnName("id_sub_category");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Recipe).HasColumnName("recipe");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.HasKey(e => e.IdPurchase);

                entity.ToTable("purchases", "dbo");

                entity.Property(e => e.IdPurchase).HasColumnName("id_purchase");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UploadDate)
                    .HasColumnName("upload_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<PurchasesDetails>(entity =>
            {
                entity.HasKey(e => e.IdPurchaseDetail);

                entity.ToTable("purchases_details", "dbo");

                entity.Property(e => e.IdPurchaseDetail).HasColumnName("id_purchase_detail");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdPurchase).HasColumnName("id_purchase");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.IdRecipe);

                entity.ToTable("recipes", "dbo");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resources>(entity =>
            {
                entity.HasKey(e => e.IdResource);

                entity.ToTable("resources", "dbo");

                entity.Property(e => e.IdResource).HasColumnName("id_resource");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.IdState);

                entity.ToTable("states", "dbo");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatesOrders>(entity =>
            {
                entity.HasKey(e => e.IdStateOrder);

                entity.ToTable("states_orders", "dbo");

                entity.Property(e => e.IdStateOrder).HasColumnName("id_state_order");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdState).HasColumnName("id_state");
            });

            modelBuilder.Entity<SubCategorys>(entity =>
            {
                entity.HasKey(e => e.IdSubCategory);

                entity.ToTable("sub_categorys", "dbo");

                entity.Property(e => e.IdSubCategory).HasColumnName("id_sub_category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypesOrders>(entity =>
            {
                entity.HasKey(e => e.IdTypeOrder);

                entity.ToTable("types_orders", "dbo");

                entity.Property(e => e.IdTypeOrder).HasColumnName("id_type_order");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
