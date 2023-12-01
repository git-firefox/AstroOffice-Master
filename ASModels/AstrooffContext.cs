﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASModels.Astrooff;

namespace ASModels
{
    public partial class AstrooffContext : DbContext
    {
        public AstrooffContext()
        {
        }

        public AstrooffContext(DbContextOptions<AstrooffContext> options)
            : base(options)
        {
        }

        public virtual DbSet<A35year> A35years { get; set; } = null!;
        public virtual DbSet<AAam> AAams { get; set; } = null!;
        public virtual DbSet<AAdditionalrule> AAdditionalrules { get; set; } = null!;
        public virtual DbSet<AAppointment> AAppointments { get; set; } = null!;
        public virtual DbSet<AAstro> AAstros { get; set; } = null!;
        public virtual DbSet<AAstroLf> AAstroLves { get; set; } = null!;
        public virtual DbSet<AAstroNfe> AAstroNves { get; set; } = null!;
        public virtual DbSet<AAstroPhf> AAstroPhfs { get; set; } = null!;
        public virtual DbSet<AAstroPrdf> AAstroPrdfs { get; set; } = null!;
        public virtual DbSet<AAstroRelation> AAstroRelations { get; set; } = null!;
        public virtual DbSet<AAstroUpay> AAstroUpays { get; set; } = null!;
        public virtual DbSet<AAstroupayMay20> AAstroupayMay20s { get; set; } = null!;
        public virtual DbSet<ABangla> ABanglas { get; set; } = null!;
        public virtual DbSet<ABanglaBak> ABanglaBaks { get; set; } = null!;
        public virtual DbSet<ABasicRule> ABasicRules { get; set; } = null!;
        public virtual DbSet<ABasicRulesOld> ABasicRulesOlds { get; set; } = null!;
        public virtual DbSet<ACallorder> ACallorders { get; set; } = null!;
        public virtual DbSet<ACcavenueTransaction> ACcavenueTransactions { get; set; } = null!;
        public virtual DbSet<AChangelog> AChangelogs { get; set; } = null!;
        public virtual DbSet<ACity> ACities { get; set; } = null!;
        public virtual DbSet<ACodeLang> ACodeLangs { get; set; } = null!;
        public virtual DbSet<ACountry> ACountries { get; set; } = null!;
        public virtual DbSet<ACountryMaster> ACountryMasters { get; set; } = null!;
        public virtual DbSet<ADashafal> ADashafals { get; set; } = null!;
        public virtual DbSet<ADashafalChain> ADashafalChains { get; set; } = null!;
        public virtual DbSet<ADatum> AData { get; set; } = null!;
        public virtual DbSet<ADddetail> ADddetails { get; set; } = null!;
        public virtual DbSet<AEk> AEks { get; set; } = null!;
        public virtual DbSet<AEmpty> AEmpties { get; set; } = null!;
        public virtual DbSet<AEng> AEngs { get; set; } = null!;
        public virtual DbSet<AEng1> AEng1s { get; set; } = null!;
        public virtual DbSet<AEngMini> AEngMinis { get; set; } = null!;
        public virtual DbSet<AExtra> AExtras { get; set; } = null!;
        public virtual DbSet<AExtraRule> AExtraRules { get; set; } = null!;
        public virtual DbSet<AGatha> AGathas { get; set; } = null!;
        public virtual DbSet<AGochar> AGochars { get; set; } = null!;
        public virtual DbSet<AGoodbad> AGoodbads { get; set; } = null!;
        public virtual DbSet<AGujarati> AGujaratis { get; set; } = null!;
        public virtual DbSet<AHindi> AHindis { get; set; } = null!;
        public virtual DbSet<AHindi2> AHindi2s { get; set; } = null!;
        public virtual DbSet<AHindiMini> AHindiMinis { get; set; } = null!;
        public virtual DbSet<AHindiMobile> AHindiMobiles { get; set; } = null!;
        public virtual DbSet<AHindiMobileTranslate> AHindiMobileTranslates { get; set; } = null!;
        public virtual DbSet<AHindiOld> AHindiOlds { get; set; } = null!;
        public virtual DbSet<AHindifeb282013> AHindifeb282013s { get; set; } = null!;
        public virtual DbSet<AHouseDetail> AHouseDetails { get; set; } = null!;
        public virtual DbSet<AIAstroUpaye> AIAstroUpayes { get; set; } = null!;
        public virtual DbSet<AKannadum> AKannada { get; set; } = null!;
        public virtual DbSet<AKaryesh> AKaryeshes { get; set; } = null!;
        public virtual DbSet<AKp> AKps { get; set; } = null!;
        public virtual DbSet<AKpCusp> AKpCusps { get; set; } = null!;
        public virtual DbSet<AKpDashaChain> AKpDashaChains { get; set; } = null!;
        public virtual DbSet<AKpDashaHouseSwami> AKpDashaHouseSwamis { get; set; } = null!;
        public virtual DbSet<AKpDashaMahantar> AKpDashaMahantars { get; set; } = null!;
        public virtual DbSet<AKpDashaRashi> AKpDashaRashis { get; set; } = null!;
        public virtual DbSet<AKpDashafalChain> AKpDashafalChains { get; set; } = null!;
        public virtual DbSet<AKpKaryeshPred> AKpKaryeshPreds { get; set; } = null!;
        public virtual DbSet<AKpNak> AKpNaks { get; set; } = null!;
        public virtual DbSet<AKpPlanetChain> AKpPlanetChains { get; set; } = null!;
        public virtual DbSet<AKpPlanetPred> AKpPlanetPreds { get; set; } = null!;
        public virtual DbSet<AKpRemedy> AKpRemedies { get; set; } = null!;
        public virtual DbSet<AKpRinnPitri> AKpRinnPitris { get; set; } = null!;
        public virtual DbSet<AKpSublordPred> AKpSublordPreds { get; set; } = null!;
        public virtual DbSet<AKpUpay> AKpUpays { get; set; } = null!;
        public virtual DbSet<AKundali> AKundalis { get; set; } = null!;
        public virtual DbSet<AKundli> AKundlis { get; set; } = null!;
        public virtual DbSet<AKundliMapping> AKundliMappings { get; set; } = null!;
        public virtual DbSet<AKundlisOld> AKundlisOlds { get; set; } = null!;
        public virtual DbSet<ALagna> ALagnas { get; set; } = null!;
        public virtual DbSet<AManglik> AMangliks { get; set; } = null!;
        public virtual DbSet<AMarathi> AMarathis { get; set; } = null!;
        public virtual DbSet<AMarathiMini> AMarathiMinis { get; set; } = null!;
        public virtual DbSet<AMixDasha> AMixDashas { get; set; } = null!;
        public virtual DbSet<AOnline> AOnlines { get; set; } = null!;
        public virtual DbSet<APlaceMaster> APlaceMasters { get; set; } = null!;
        public virtual DbSet<APlanet> APlanets { get; set; } = null!;
        public virtual DbSet<APlanetBimari> APlanetBimaris { get; set; } = null!;
        public virtual DbSet<APlanetDetail> APlanetDetails { get; set; } = null!;
        public virtual DbSet<APlanetGrehphal> APlanetGrehphals { get; set; } = null!;
        public virtual DbSet<APlanetKismat> APlanetKismats { get; set; } = null!;
        public virtual DbSet<APlanetMandeghar> APlanetMandeghars { get; set; } = null!;
        public virtual DbSet<APlanetNeechghar> APlanetNeechghars { get; set; } = null!;
        public virtual DbSet<APlanetOld> APlanetOlds { get; set; } = null!;
        public virtual DbSet<APlanetPakkeghar> APlanetPakkeghars { get; set; } = null!;
        public virtual DbSet<APlanetRashiphal> APlanetRashiphals { get; set; } = null!;
        public virtual DbSet<APlanetRelation> APlanetRelations { get; set; } = null!;
        public virtual DbSet<APlanetShreshtghar> APlanetShreshtghars { get; set; } = null!;
        public virtual DbSet<APlanetUchghar> APlanetUchghars { get; set; } = null!;
        public virtual DbSet<AProduct> AProducts { get; set; } = null!;
        public virtual DbSet<AProductPred> AProductPreds { get; set; } = null!;
        public virtual DbSet<APunjabi> APunjabis { get; set; } = null!;
        public virtual DbSet<APunjabiMini> APunjabiMinis { get; set; } = null!;
        public virtual DbSet<ARashiDetail> ARashiDetails { get; set; } = null!;
        public virtual DbSet<ARashiSheet> ARashiSheets { get; set; } = null!;
        public virtual DbSet<AReceipt> AReceipts { get; set; } = null!;
        public virtual DbSet<ARule> ARules { get; set; } = null!;
        public virtual DbSet<ARulesCategory> ARulesCategories { get; set; } = null!;
        public virtual DbSet<ARulesDump> ARulesDumps { get; set; } = null!;
        public virtual DbSet<ARulesUpay> ARulesUpays { get; set; } = null!;
        public virtual DbSet<ARulesUpay1> ARulesUpay1s { get; set; } = null!;
        public virtual DbSet<AShatruPlanet> AShatruPlanets { get; set; } = null!;
        public virtual DbSet<ASoyeGrehJagao> ASoyeGrehJagaos { get; set; } = null!;
        public virtual DbSet<ASplyog> ASplyogs { get; set; } = null!;
        public virtual DbSet<AStateMaster> AStateMasters { get; set; } = null!;
        public virtual DbSet<ATamil> ATamils { get; set; } = null!;
        public virtual DbSet<ATelugu> ATelugus { get; set; } = null!;
        public virtual DbSet<ATempMap> ATempMaps { get; set; } = null!;
        public virtual DbSet<ATempMapping> ATempMappings { get; set; } = null!;
        public virtual DbSet<ATimeZone> ATimeZones { get; set; } = null!;
        public virtual DbSet<ATokenTransaction> ATokenTransactions { get; set; } = null!;
        public virtual DbSet<ATransactionStatus> ATransactionStatuses { get; set; } = null!;
        public virtual DbSet<AUpay> AUpays { get; set; } = null!;
        public virtual DbSet<AUpay1> AUpay1s { get; set; } = null!;
        public virtual DbSet<AUpayindex> AUpayindices { get; set; } = null!;
        public virtual DbSet<AUser> AUsers { get; set; } = null!;
        public virtual DbSet<AUserLog> AUserLogs { get; set; } = null!;
        public virtual DbSet<AUserTokenBalance> AUserTokenBalances { get; set; } = null!;
        public virtual DbSet<AVarshphal> AVarshphals { get; set; } = null!;
        public virtual DbSet<AVdaan> AVdaans { get; set; } = null!;
        public virtual DbSet<AVfal> AVfals { get; set; } = null!;
        public virtual DbSet<AVfalUpay> AVfalUpays { get; set; } = null!;
        public virtual DbSet<AVfalUpay1> AVfalUpay1s { get; set; } = null!;
        public virtual DbSet<AVfale> AVfales { get; set; } = null!;
        public virtual DbSet<AVfalh> AVfalhs { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Common> Commons { get; set; } = null!;
        public virtual DbSet<Female> Females { get; set; } = null!;
        public virtual DbSet<Male> Males { get; set; } = null!;
        public virtual DbSet<NewMixDasha> NewMixDashas { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductMetaData> ProductMetaDatas { get; set; } = null!;
        public virtual DbSet<ProductOrder> ProductOrders { get; set; } = null!;
        public virtual DbSet<ProductWishlist> ProductWishlists { get; set; } = null!;
        public virtual DbSet<Query> Queries { get; set; } = null!;
        public virtual DbSet<QueryEng> QueryEngs { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<TimeMaster> TimeMasters { get; set; } = null!;
        public virtual DbSet<VfalBangla> VfalBanglas { get; set; } = null!;
        public virtual DbSet<VfalKannadum> VfalKannada { get; set; } = null!;
        public virtual DbSet<VfalTamil> VfalTamils { get; set; } = null!;
        public virtual DbSet<VfalTelugu> VfalTelugus { get; set; } = null!;
        public virtual DbSet<VfalUpay> VfalUpays { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<A35year>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_35years")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AAppointment>(entity =>
            {
                entity.Property(e => e.AppType).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Apptime).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.City).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Country).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Dob).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Gender).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Kundliid).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaritalStatus).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Mobile).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PersName).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Pob).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Referenceno).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.State).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Tob).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<AAstro>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroLf>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Astro_LF_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroNfe>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Astro_NFE")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroPhf>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Astro_PHF")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroPrdf>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_astro_PRDF")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroRelation>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Astro_Relation")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroUpay>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_astroUpay")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AAstroupayMay20>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ABangla>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_bangla")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ABanglaBak>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ABasicRule>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_a_basic_rules1");

                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.ABasicRules)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_basic_rules1_a_planet");
            });

            modelBuilder.Entity<ABasicRulesOld>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_a_basic_rules");

                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.ABasicRulesOlds)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_basic_rules_a_planet");
            });

            modelBuilder.Entity<ACallorder>(entity =>
            {
                entity.Property(e => e.City).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Gender).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.MaritalStatus).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Phone).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Pob).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Product).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Refnumber).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Remarks).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.State).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Tob).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<ACcavenueTransaction>(entity =>
            {
                entity.Property(e => e.TimestampCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ATransactionStatuses)
                    .WithMany(p => p.ACcavenueTransactions)
                    .HasForeignKey(d => d.ATransactionStatusesId)
                    .HasConstraintName("FK__A_CCAvenu__A_Tra__292D09F3");

                entity.HasOne(d => d.AUserSnoNavigation)
                    .WithMany(p => p.ACcavenueTransactions)
                    .HasForeignKey(d => d.AUserSno)
                    .HasConstraintName("FK__A_CCAvenu__A_Use__2838E5BA");
            });

            modelBuilder.Entity<AChangelog>(entity =>
            {
                entity.Property(e => e.Columname).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Newval).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Oldaval).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Tablename).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<ACity>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_a_city")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ACodeLang>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_A_code_lang_1")
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_code_lang")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ACountry>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_a_coutry");
            });

            modelBuilder.Entity<ACountryMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_country_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ADashafal>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ADashafalChain>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_dashafal_chain")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ADddetail>(entity =>
            {
                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ADddetails)
                    .HasForeignKey(d => d.Receiptid)
                    .HasConstraintName("FK_a_DDdetail_a_DDdetail");
            });

            modelBuilder.Entity<AEng>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_eng")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AEng1>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AEngMini>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_eng_mini")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AGochar>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_gochar")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AGujarati>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_gujarati")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_hindi_2")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindi2>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindiMini>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindiMobile>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_hindi_mobile_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindiOld>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_hindi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHindifeb282013>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AHouseDetail>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKannadum>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Kannada_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKaryesh>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_Karyesh_2")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AKp>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_1")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AKpCusp>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_cusp_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpDashaChain>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_dasha_chain")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpDashaHouseSwami>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_dasha_house_swami")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpDashaMahantar>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_dasha_mahantar_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpDashaRashi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_dasha_rashi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpDashafalChain>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_dashafal_chain")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AKpKaryeshPred>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_karyesh_pred")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpNak>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_Kp_Nak")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AKpPlanetPred>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_planet_pred")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpRinnPitri>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_rinn_pitri")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpSublordPred>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);
            });

            modelBuilder.Entity<AKpUpay>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_kp_upay")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKundali>(entity =>
            {
                entity.Property(e => e.CheckMfal).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckSahasaneLogic).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckSalaChakkar).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckShowRef).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPaid).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSaved).HasDefaultValueSql("((0))");

                entity.Property(e => e.ViewDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AUserSnoNavigation)
                    .WithMany(p => p.AKundalis)
                    .HasForeignKey(d => d.AUserSno)
                    .HasConstraintName("FK__A_Kundali__A_Use__33AA9866");
            });

            modelBuilder.Entity<AKundli>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_kundlis")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AKundliMapping>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKundlisOld>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ALagna>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AManglik>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_manglik1")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AMarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AMarathiMini>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<APlaceMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_place_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<APlanet>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_planet")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<APlanetBimari>(entity =>
            {
                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.APlanetBimaris)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_planet_bimari_a_planet");
            });

            modelBuilder.Entity<APlanetDetail>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<APlanetMandeghar>(entity =>
            {
                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.APlanetMandeghars)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_planet_mandeghar_a_planet");
            });

            modelBuilder.Entity<APlanetNeechghar>(entity =>
            {
                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.APlanetNeechghars)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_planet_neechghar_a_planet");
            });

            modelBuilder.Entity<APlanetOld>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_a_planets");
            });

            modelBuilder.Entity<APlanetPakkeghar>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedNever();
            });

            modelBuilder.Entity<APlanetRelation>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedNever();
            });

            modelBuilder.Entity<APlanetShreshtghar>(entity =>
            {
                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.APlanetShreshtghars)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_planet_shreshtghar_a_planet");
            });

            modelBuilder.Entity<APlanetUchghar>(entity =>
            {
                entity.HasOne(d => d.PlanetNavigation)
                    .WithMany(p => p.APlanetUchghars)
                    .HasForeignKey(d => d.Planet)
                    .HasConstraintName("FK_a_planet_uchghar_a_planet");
            });

            modelBuilder.Entity<AProduct>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__A_Produc__CA1FE4644F9E97C5");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<APunjabi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_punjabi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<APunjabiMini>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARashiDetail>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARashiSheet>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rashi_sheet")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARule>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_rules_1")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ARulesUpay>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rules_upay_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesUpay1>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rules_upay")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ASplyog>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AStateMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_state_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ATamil>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_tamil")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ATelugu>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_telugu")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ATempMapping>(entity =>
            {
                entity.HasOne(d => d.MapNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MapNo)
                    .HasConstraintName("FK_a_temp_mappings_a_temp_map");
            });

            modelBuilder.Entity<ATokenTransaction>(entity =>
            {
                entity.Property(e => e.TimestampCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ATransactionStatuses)
                    .WithMany(p => p.ATokenTransactions)
                    .HasForeignKey(d => d.ATransactionStatusesId)
                    .HasConstraintName("FK__A_TokenTr__A_Tra__2DF1BF10");

                entity.HasOne(d => d.AUserSnoNavigation)
                    .WithMany(p => p.ATokenTransactions)
                    .HasForeignKey(d => d.AUserSno)
                    .HasConstraintName("FK__A_TokenTr__A_Use__2CFD9AD7");
            });

            modelBuilder.Entity<ATransactionStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AUpay>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_upay_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AUpay1>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_upay")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AUser>(entity =>
            {
                entity.Property(e => e.Password).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Username).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<AUserLog>(entity =>
            {
                entity.Property(e => e.Systemname).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Username).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<AUserTokenBalance>(entity =>
            {
                entity.Property(e => e.TokenBalance).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.AUserSnoNavigation)
                    .WithOne(p => p.AUserTokenBalance)
                    .HasForeignKey<AUserTokenBalance>(d => d.AUserSno)
                    .HasConstraintName("FK__A_UserTok__A_Use__246854D6");
            });

            modelBuilder.Entity<AVfalUpay>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .IsClustered(false);

                entity.HasIndex(e => e.Sno, "IX_A_vfal_upay")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AVfalUpay1>(entity =>
            {
                entity.Property(e => e.Ruleno1).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Addresse__CA1FE464EFFEEB44");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ACountrySnoNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ACountrySno)
                    .HasConstraintName("FK__Addresses__A_cou__71A7CADF");

                entity.HasOne(d => d.AUsersSnoNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AUsersSno)
                    .HasConstraintName("FK__Addresses__A_Use__70B3A6A6");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__CartItem__CA1FE464BB1EAA1C");

                entity.HasOne(d => d.AProductsSnoNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.AProductsSno)
                    .HasConstraintName("FK__CartItems__A_Pro__6359AB88");

                entity.HasOne(d => d.ShoppingCartsSnoNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ShoppingCartsSno)
                    .HasConstraintName("FK__CartItems__Shopp__6265874F");
            });

            modelBuilder.Entity<NewMixDasha>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__new_mix_dasha__4BB72C21");

                entity.Property(e => e.KamjorGrah).HasDefaultValueSql("('0')");

                entity.Property(e => e.MandaGhar).HasDefaultValueSql("('0')");

                entity.Property(e => e.ShubhGhar).HasDefaultValueSql("('0')");

                entity.Property(e => e.Sno).HasDefaultValueSql("('-1')");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__OrderIte__CA1FE464917A62CA");

                entity.HasOne(d => d.AProductsSnoNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.AProductsSno)
                    .HasConstraintName("FK__OrderItem__A_Pro__7E0DA1C4");

                entity.HasOne(d => d.ProductOrdersSnoNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductOrdersSno)
                    .HasConstraintName("FK__OrderItem__Produ__7D197D8B");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__ProductI__CA1FE464295FE454");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductIm__Produ__75785BC3");
            });

            modelBuilder.Entity<ProductMetaData>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__ProductM__CA1FE464E765B4EF");

                entity.HasOne(d => d.AProductsSnoNavigation)
                    .WithMany(p => p.ProductMetaData)
                    .HasForeignKey(d => d.AProductsSno)
                    .HasConstraintName("FK__ProductMe__A_Pro__00EA0E6F");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__ProductO__CA1FE4649A2DBF98");

                entity.HasOne(d => d.AUsersSnoNavigation)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.AUsersSno)
                    .HasConstraintName("FK__ProductOr__A_Use__7A3D10E0");

                entity.HasOne(d => d.BillingAddressSnoNavigation)
                    .WithMany(p => p.ProductOrderBillingAddressSnoNavigations)
                    .HasForeignKey(d => d.BillingAddressSno)
                    .HasConstraintName("FK__ProductOr__Billi__7948ECA7");

                entity.HasOne(d => d.ShippingAddressSnoNavigation)
                    .WithMany(p => p.ProductOrderShippingAddressSnoNavigations)
                    .HasForeignKey(d => d.ShippingAddressSno)
                    .HasConstraintName("FK__ProductOr__Shipp__7854C86E");
            });

            modelBuilder.Entity<ProductWishlist>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__ProductW__CA1FE464F1C532B2");

                entity.HasOne(d => d.AProductsSnoNavigation)
                    .WithMany(p => p.ProductWishlists)
                    .HasForeignKey(d => d.AProductsSno)
                    .HasConstraintName("FK__ProductWi__A_Pro__03C67B1A");

                entity.HasOne(d => d.AUsersSnoNavigation)
                    .WithMany(p => p.ProductWishlists)
                    .HasForeignKey(d => d.AUsersSno)
                    .HasConstraintName("FK__ProductWi__A_Use__04BA9F53");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Shopping__CA1FE4647FF08811");

                entity.HasOne(d => d.AUsersSnoNavigation)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.AUsersSno)
                    .HasConstraintName("FK__ShoppingC__A_Use__5F891AA4");
            });

            modelBuilder.Entity<TimeMaster>(entity =>
            {
                entity.Property(e => e.Begintime).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Endtime).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Interval).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<VfalBangla>(entity =>
            {
                entity.Property(e => e.Ruleno1).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VfalKannadum>(entity =>
            {
                entity.Property(e => e.Ruleno1).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VfalTamil>(entity =>
            {
                entity.Property(e => e.Ruleno1).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VfalTelugu>(entity =>
            {
                entity.Property(e => e.Ruleno1).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
