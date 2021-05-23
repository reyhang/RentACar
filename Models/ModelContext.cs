using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Deletedrentalhistory> Deletedrentalhistories { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Rentalhistory> Rentalhistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1))); Persist Security Info=True; User ID=SYSTEM;Password=1234; Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESSES");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    .HasDefaultValueSql("\"SYSTEM\".\"ISEQ$$_74201\".nextval ");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRANDS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Brandname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRANDNAME");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CARS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Brandid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BRANDID");

                entity.Property(e => e.Colorid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COLORID");

                entity.Property(e => e.Dailyprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DAILYPRICE");

                entity.Property(e => e.Modelid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MODELID");

                entity.Property(e => e.Plate)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("PLATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Brandid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARBRANDID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Colorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COLORID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Modelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODELID");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("CARDS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cardmonth)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDMONTH");

                entity.Property(e => e.Cardnumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Caryear)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARYEAR");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVV");

                entity.Property(e => e.Userfirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERFIRSTNAME");

                entity.Property(e => e.Userlastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLASTNAME");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("COLORS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Colorname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLORNAME");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACTS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<Deletedrentalhistory>(entity =>
            {
                entity.ToTable("DELETEDRENTALHISTORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Carid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARID");

                entity.Property(e => e.Rentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("RENTDATE");

                entity.Property(e => e.Returndate)
                    .HasColumnType("DATE")
                    .HasColumnName("RETURNDATE");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Deletedrentalhistories)
                    .HasForeignKey(d => d.Carid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DELETEDRENTALHISTORYCARID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deletedrentalhistories)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DELETEDRENTALHISTORYUSERID");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("MODELS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Brandid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BRANDID");

                entity.Property(e => e.Modelname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODELNAME");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.Brandid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRANDID");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("RENTALS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Carid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARID");

                entity.Property(e => e.Delivery)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("DELIVERY")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Rentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("RENTDATE");

                entity.Property(e => e.Returndate)
                    .HasColumnType("DATE")
                    .HasColumnName("RETURNDATE");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.Carid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RENTALCARID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RENTALUSERID");
            });

            modelBuilder.Entity<Rentalhistory>(entity =>
            {
                entity.ToTable("RENTALHISTORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Carid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARID");

                entity.Property(e => e.Rentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("RENTDATE");

                entity.Property(e => e.Returndate)
                    .HasColumnType("DATE")
                    .HasColumnName("RETURNDATE");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Rentalhistories)
                    .HasForeignKey(d => d.Carid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RENTALHISTORYCARID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentalhistories)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RENTALHISTORYUSERID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Addressid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADDRESSID");

                entity.Property(e => e.Birthplace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIRTHPLACE");

                entity.Property(e => e.Birthyear)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BIRTHYEAR");

                entity.Property(e => e.Cardid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDID");

                entity.Property(e => e.Contactid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONTACTID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Nationalid)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Addressid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADDRESSID");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Cardid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARDID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Contactid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTACTID");
            });

            modelBuilder.HasSequence("ADMİN_SEQ");

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
