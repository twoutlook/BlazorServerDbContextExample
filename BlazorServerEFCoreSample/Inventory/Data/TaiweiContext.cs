﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Inventory.Data
{
    public partial class TaiweiContext : DbContext
    {
        public TaiweiContext()
        {
        }

        public TaiweiContext(DbContextOptions<TaiweiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasePart> BasePart { get; set; }
        public virtual DbSet<StockCurrent> StockCurrent { get; set; }
        public virtual DbSet<StockCurrentSn> StockCurrentSn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MARK10\\SQLEXPRESS01;Initial Catalog=TaiWei;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<BasePart>(entity =>
            {
                entity.ToTable("BASE_PART");

                entity.HasIndex(e => e.Cerpcode, "BASE_PART_INDEX_CERPCODE");

                entity.HasIndex(e => e.Cpartnumber, "BASE_PART_INDEX_CPARTNUMBER");

                entity.HasIndex(e => e.Id, "SYS_C0014393")
                    .IsUnique();

                entity.HasIndex(e => e.Cpartnumber, "uk_BASE_PART_cpartnumber")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Bonded)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("bonded")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Boxnum)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("boxnum")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Calias)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("calias");

                entity.Property(e => e.Cbarrule)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("cbarrule");

                entity.Property(e => e.Cdefaultcargo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("cdefaultcargo");

                entity.Property(e => e.Cdefaultvendor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cdefaultvendor");

                entity.Property(e => e.Cdefaultware)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("cdefaultware");

                entity.Property(e => e.Cdefine1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cdefine1");

                entity.Property(e => e.Cdefine2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cdefine2");

                entity.Property(e => e.Cerpcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cerpcode");

                entity.Property(e => e.Cinrule)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("cinrule");

                entity.Property(e => e.Cmemo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cmemo");

                entity.Property(e => e.Coutrule)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("coutrule");

                entity.Property(e => e.Cpartname)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("cpartname");

                entity.Property(e => e.Cpartnumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cpartnumber");

                entity.Property(e => e.Createowner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createowner");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Csafeqty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("csafeqty");

                entity.Property(e => e.Csafeqtyceiling)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("csafeqtyceiling");

                entity.Property(e => e.Cspecifications)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cspecifications");

                entity.Property(e => e.Cstatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cstatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ctype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ctype")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cunits)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cunits");

                entity.Property(e => e.Cusetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cusetype");

                entity.Property(e => e.Cversion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cversion");

                entity.Property(e => e.Cvolume)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cvolume");

                entity.Property(e => e.Ddefine3)
                    .HasColumnType("datetime")
                    .HasColumnName("ddefine3");

                entity.Property(e => e.Ddefine4)
                    .HasColumnType("datetime")
                    .HasColumnName("ddefine4");

                entity.Property(e => e.Dexpiredate)
                    .HasColumnType("datetime")
                    .HasColumnName("dexpiredate");

                entity.Property(e => e.ExpDays)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("exp_days");

                entity.Property(e => e.Icw)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("icw");

                entity.Property(e => e.Idefine5)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("idefine5");

                entity.Property(e => e.Iheight)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("iheight");

                entity.Property(e => e.Ilength)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ilength");

                entity.Property(e => e.Ineedcheck)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ineedcheck")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ineedwarn)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ineedwarn")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Inw)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("inw");

                entity.Property(e => e.Iwidth)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("iwidth");

                entity.Property(e => e.Lastupdateowner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastupdateowner");

                entity.Property(e => e.Lastupdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdatetime");

                entity.Property(e => e.Mtype)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("mtype");

                entity.Property(e => e.Productcode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productcode");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UNIT");
            });

            modelBuilder.Entity<StockCurrent>(entity =>
            {
                entity.ToTable("STOCK_CURRENT");

                entity.HasIndex(e => new { e.Cpositioncode, e.Cinvcode }, "INDX_CP_CIN")
                    .IsUnique();

                entity.HasIndex(e => e.Cinvcode, "stock_current_cinvcode");

                entity.HasIndex(e => e.Cpositioncode, "stock_current_cpositioncode");

                entity.HasIndex(e => e.Cwarehousecode, "stock_current_cwarehousecode");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Cbarcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cbarcode");

                entity.Property(e => e.Cdatecode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cdatecode");

                entity.Property(e => e.Cdefine1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cdefine1");

                entity.Property(e => e.Cdefine2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cdefine2");

                entity.Property(e => e.Cinvcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cinvcode");

                entity.Property(e => e.Cinvname)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("cinvname");

                entity.Property(e => e.Cmemo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cmemo");

                entity.Property(e => e.Cposition)
                    .HasMaxLength(100)
                    .HasColumnName("cposition");

                entity.Property(e => e.Cpositioncode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("cpositioncode");

                entity.Property(e => e.Cstatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cstatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cunits)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cunits");

                entity.Property(e => e.Cwarehouse)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cwarehouse");

                entity.Property(e => e.Cwarehousecode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cwarehousecode");

                entity.Property(e => e.Ddefine3)
                    .HasColumnType("datetime")
                    .HasColumnName("ddefine3");

                entity.Property(e => e.Ddefine4)
                    .HasColumnType("datetime")
                    .HasColumnName("ddefine4");

                entity.Property(e => e.Idefine5)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("idefine5");

                entity.Property(e => e.Ioccupyqty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("ioccupyqty");

                entity.Property(e => e.Iplanin)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("iplanin");

                entity.Property(e => e.Iplanout)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("iplanout");

                entity.Property(e => e.Iqty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("iqty");

                entity.Property(e => e.Palletcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("palletcode");
            });

            modelBuilder.Entity<StockCurrentSn>(entity =>
            {
                entity.HasKey(e => e.Ids)
                    .HasName("STOCK_SN_PK_IDS");

                entity.ToTable("STOCK_CURRENT_SN");

                entity.HasIndex(e => e.StockId, "STOCK_SN_ID");

                entity.HasIndex(e => e.Sncode, "STOCK_SN_SNCODE");

                entity.Property(e => e.Ids)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ids");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Createuser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createuser");

                entity.Property(e => e.Cstatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cstatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Datecode)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("datecode");

                entity.Property(e => e.Default2)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("default2");

                entity.Property(e => e.Erpcode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ERPCODE");

                entity.Property(e => e.Furnaceno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("furnaceno");

                entity.Property(e => e.Lastupdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdatetime");

                entity.Property(e => e.Lastupdateuser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastupdateuser");

                entity.Property(e => e.Memo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("memo");

                entity.Property(e => e.Palletcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("palletcode");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.Rulecode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RULECODE");

                entity.Property(e => e.SnCode20)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SN_CODE20");

                entity.Property(e => e.Sncode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("sncode");

                entity.Property(e => e.Sntype)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("sntype")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StockId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("stock_id");

                entity.Property(e => e.Stocktype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("stocktype");

                entity.Property(e => e.Vendorcode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDORCODE");
            });

            modelBuilder.HasSequence("ASRS_cmdno_SEQ")
                .HasMin(1)
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_CmdSno_RGV_A")
                .HasMin(1)
                .HasMax(24999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_CmdSno_RGV_B")
                .HasMin(1)
                .HasMax(24999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_CmdSno_RGV_C")
                .HasMin(1)
                .HasMax(24999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_SEQ")
                .StartsAt(1301)
                .HasMin(1)
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_SNO_SEQ")
                .StartsAt(1003)
                .HasMin(1003)
                .HasMax(24999)
                .IsCyclic();

            modelBuilder.HasSequence("ASRS_WmsTskId_RGV")
                .HasMin(1)
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("SEQ_DATABASEERROR");

            modelBuilder.HasSequence("SEQ_SERIAL_NO").IsCyclic();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}