using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASModels.MatchMaking;
using System.Configuration;

namespace ASModels
{
    public partial class MatchMakingContext : DbContext
    {
        public MatchMakingContext() { }

        public MatchMakingContext(DbContextOptions<MatchMakingContext> options) : base(options) { }

        public virtual DbSet<ACity> ACities { get; set; } = null!;
        public virtual DbSet<ACountryMaster> ACountryMasters { get; set; } = null!;
        public virtual DbSet<ADatum> AData { get; set; } = null!;
        public virtual DbSet<ADrishti> ADrishtis { get; set; } = null!;
        public virtual DbSet<AKp> AKps { get; set; } = null!;
        public virtual DbSet<AKpAshtamNaklordDeath> AKpAshtamNaklordDeaths { get; set; } = null!;
        public virtual DbSet<AKpHouseNakLord> AKpHouseNakLords { get; set; } = null!;
        public virtual DbSet<AKpHouseRashi> AKpHouseRashis { get; set; } = null!;
        public virtual DbSet<AKpPanchamRashiHouse> AKpPanchamRashiHouses { get; set; } = null!;
        public virtual DbSet<AKpPlanetHouse> AKpPlanetHouses { get; set; } = null!;
        public virtual DbSet<AKpPlanetRashi> AKpPlanetRashis { get; set; } = null!;
        public virtual DbSet<AKpShashtamNaklordDisease> AKpShashtamNaklordDiseases { get; set; } = null!;
        public virtual DbSet<AKundli> AKundlis { get; set; } = null!;
        public virtual DbSet<AKundliMapping> AKundliMappings { get; set; } = null!;
        public virtual DbSet<AManglikUpay> AManglikUpays { get; set; } = null!;
        public virtual DbSet<AManglikUpay1> AManglikUpay1s { get; set; } = null!;
        public virtual DbSet<ANak> ANaks { get; set; } = null!;
        public virtual DbSet<ANakGrahDrishti> ANakGrahDrishtis { get; set; } = null!;
        public virtual DbSet<ANakGrahDrishtihindi> ANakGrahDrishtihindis { get; set; } = null!;
        public virtual DbSet<APlaceMaster> APlaceMasters { get; set; } = null!;
        public virtual DbSet<APlanet> APlanets { get; set; } = null!;
        public virtual DbSet<ARashi> ARashis { get; set; } = null!;
        public virtual DbSet<ARashiSheet> ARashiSheets { get; set; } = null!;
        public virtual DbSet<ARulesHouseDrishti> ARulesHouseDrishtis { get; set; } = null!;
        public virtual DbSet<ARulesRashiGrehDrishti> ARulesRashiGrehDrishtis { get; set; } = null!;
        public virtual DbSet<ARuleshouse> ARuleshouses { get; set; } = null!;
        public virtual DbSet<ARuleshousebangla> ARuleshousebanglas { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtibangla> ARuleshousedrishtibanglas { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtienglish> ARuleshousedrishtienglishes { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtigujarati> ARuleshousedrishtigujaratis { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtikannadum> ARuleshousedrishtikannada { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtimarathi> ARuleshousedrishtimarathis { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtipunjabi> ARuleshousedrishtipunjabis { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtitamil> ARuleshousedrishtitamils { get; set; } = null!;
        public virtual DbSet<ARuleshousedrishtitelugu> ARuleshousedrishtitelugus { get; set; } = null!;
        public virtual DbSet<ARuleshouseenglish> ARuleshouseenglishes { get; set; } = null!;
        public virtual DbSet<ARuleshousegreha> ARuleshousegrehas { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehabangla> ARuleshousegrehabanglas { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehaenglish> ARuleshousegrehaenglishes { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehagujarati> ARuleshousegrehagujaratis { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehakannadum> ARuleshousegrehakannada { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehamarathi> ARuleshousegrehamarathis { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehapunjabi> ARuleshousegrehapunjabis { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehatamil> ARuleshousegrehatamils { get; set; } = null!;
        public virtual DbSet<ARuleshousegrehatelugu> ARuleshousegrehatelugus { get; set; } = null!;
        public virtual DbSet<ARuleshousegujarati> ARuleshousegujaratis { get; set; } = null!;
        public virtual DbSet<ARuleshousekannadum> ARuleshousekannada { get; set; } = null!;
        public virtual DbSet<ARuleshousemarathi> ARuleshousemarathis { get; set; } = null!;
        public virtual DbSet<ARuleshousepunjabi> ARuleshousepunjabis { get; set; } = null!;
        public virtual DbSet<ARuleshousetamil> ARuleshousetamils { get; set; } = null!;
        public virtual DbSet<ARuleshousetelugu> ARuleshousetelugus { get; set; } = null!;
        public virtual DbSet<ARuleslagna> ARuleslagnas { get; set; } = null!;
        public virtual DbSet<ARuleslagnabangla> ARuleslagnabanglas { get; set; } = null!;
        public virtual DbSet<ARuleslagnaenglish> ARuleslagnaenglishes { get; set; } = null!;
        public virtual DbSet<ARuleslagnagujarati> ARuleslagnagujaratis { get; set; } = null!;
        public virtual DbSet<ARuleslagnakannadum> ARuleslagnakannada { get; set; } = null!;
        public virtual DbSet<ARuleslagnamarathi> ARuleslagnamarathis { get; set; } = null!;
        public virtual DbSet<ARuleslagnapunjabi> ARuleslagnapunjabis { get; set; } = null!;
        public virtual DbSet<ARuleslagnatamil> ARuleslagnatamils { get; set; } = null!;
        public virtual DbSet<ARuleslagnatelugu> ARuleslagnatelugus { get; set; } = null!;
        public virtual DbSet<ARulesnak> ARulesnaks { get; set; } = null!;
        public virtual DbSet<ARulesnakbangla> ARulesnakbanglas { get; set; } = null!;
        public virtual DbSet<ARulesnakenglish> ARulesnakenglishes { get; set; } = null!;
        public virtual DbSet<ARulesnakgujarati> ARulesnakgujaratis { get; set; } = null!;
        public virtual DbSet<ARulesnakkannadum> ARulesnakkannada { get; set; } = null!;
        public virtual DbSet<ARulesnakmarathi> ARulesnakmarathis { get; set; } = null!;
        public virtual DbSet<ARulesnakpunjabi> ARulesnakpunjabis { get; set; } = null!;
        public virtual DbSet<ARulesnaktamil> ARulesnaktamils { get; set; } = null!;
        public virtual DbSet<ARulesnaktelugu> ARulesnaktelugus { get; set; } = null!;
        public virtual DbSet<ARulesrashigreh> ARulesrashigrehs { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehbangla> ARulesrashigrehbanglas { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtibangla> ARulesrashigrehdrishtibanglas { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtienglish> ARulesrashigrehdrishtienglishes { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtigujarati> ARulesrashigrehdrishtigujaratis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtikannadum> ARulesrashigrehdrishtikannada { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtimarathi> ARulesrashigrehdrishtimarathis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtipunjabi> ARulesrashigrehdrishtipunjabis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtitamil> ARulesrashigrehdrishtitamils { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehdrishtitelugu> ARulesrashigrehdrishtitelugus { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehenglish> ARulesrashigrehenglishes { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehgujarati> ARulesrashigrehgujaratis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehkannadum> ARulesrashigrehkannada { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehmarathi> ARulesrashigrehmarathis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehpunjabi> ARulesrashigrehpunjabis { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehtamil> ARulesrashigrehtamils { get; set; } = null!;
        public virtual DbSet<ARulesrashigrehtelugu> ARulesrashigrehtelugus { get; set; } = null!;
        public virtual DbSet<AStateMaster> AStateMasters { get; set; } = null!;
        public virtual DbSet<ATempMap> ATempMaps { get; set; } = null!;
        public virtual DbSet<ATempMapping> ATempMappings { get; set; } = null!;
        public virtual DbSet<ATimeZone> ATimeZones { get; set; } = null!;
        public virtual DbSet<AUser> AUsers { get; set; } = null!;
        public virtual DbSet<BanCharan1> BanCharan1s { get; set; } = null!;
        public virtual DbSet<BanCharan2> BanCharan2s { get; set; } = null!;
        public virtual DbSet<BanCharan3> BanCharan3s { get; set; } = null!;
        public virtual DbSet<BanCharan4> BanCharan4s { get; set; } = null!;
        public virtual DbSet<BanManglikupay> BanManglikupays { get; set; } = null!;
        public virtual DbSet<BanRulesHouseDrishti> BanRulesHouseDrishtis { get; set; } = null!;
        public virtual DbSet<BanRulesHouseDrishtiMale> BanRulesHouseDrishtiMales { get; set; } = null!;
        public virtual DbSet<BanRulesLagna> BanRulesLagnas { get; set; } = null!;
        public virtual DbSet<BanRulesRashiGrehDrishti> BanRulesRashiGrehDrishtis { get; set; } = null!;
        public virtual DbSet<BanRulesRashiGrehDrishtiMale> BanRulesRashiGrehDrishtiMales { get; set; } = null!;
        public virtual DbSet<BanRuleshouse> BanRuleshouses { get; set; } = null!;
        public virtual DbSet<BanRuleshouseFemale> BanRuleshouseFemales { get; set; } = null!;
        public virtual DbSet<BanRuleshouseMale> BanRuleshouseMales { get; set; } = null!;
        public virtual DbSet<BanRuleshousedrishtiFemale> BanRuleshousedrishtiFemales { get; set; } = null!;
        public virtual DbSet<BanRuleshousegreha> BanRuleshousegrehas { get; set; } = null!;
        public virtual DbSet<BanRuleshousegrehaFemale> BanRuleshousegrehaFemales { get; set; } = null!;
        public virtual DbSet<BanRuleshousegrehaMale> BanRuleshousegrehaMales { get; set; } = null!;
        public virtual DbSet<BanRuleslagnaMale> BanRuleslagnaMales { get; set; } = null!;
        public virtual DbSet<BanRulesnak> BanRulesnaks { get; set; } = null!;
        public virtual DbSet<BanRulesnakFemale> BanRulesnakFemales { get; set; } = null!;
        public virtual DbSet<BanRulesnakMale> BanRulesnakMales { get; set; } = null!;
        public virtual DbSet<BanRulesrashigreh> BanRulesrashigrehs { get; set; } = null!;
        public virtual DbSet<BanRulesrashigrehFemale> BanRulesrashigrehFemales { get; set; } = null!;
        public virtual DbSet<BanRulesrashigrehMale> BanRulesrashigrehMales { get; set; } = null!;
        public virtual DbSet<KanManglikupay> KanManglikupays { get; set; } = null!;
        public virtual DbSet<KanRulesHouseDrishtiMale> KanRulesHouseDrishtiMales { get; set; } = null!;
        public virtual DbSet<KanRulesLagna> KanRulesLagnas { get; set; } = null!;
        public virtual DbSet<KanRulesNak> KanRulesNaks { get; set; } = null!;
        public virtual DbSet<KanRulesRashiGrehDrishtiMale> KanRulesRashiGrehDrishtiMales { get; set; } = null!;
        public virtual DbSet<KanRuleshouse> KanRuleshouses { get; set; } = null!;
        public virtual DbSet<KanRuleshouseFemale> KanRuleshouseFemales { get; set; } = null!;
        public virtual DbSet<KanRuleshouseMale> KanRuleshouseMales { get; set; } = null!;
        public virtual DbSet<KanRuleshousedrishtiFemale> KanRuleshousedrishtiFemales { get; set; } = null!;
        public virtual DbSet<KanRuleshousegrehaFemale> KanRuleshousegrehaFemales { get; set; } = null!;
        public virtual DbSet<KanRuleshousegrehaMale> KanRuleshousegrehaMales { get; set; } = null!;
        public virtual DbSet<KanRuleslagnaMale> KanRuleslagnaMales { get; set; } = null!;
        public virtual DbSet<KanRulesnakFemale> KanRulesnakFemales { get; set; } = null!;
        public virtual DbSet<KanRulesnakMale> KanRulesnakMales { get; set; } = null!;
        public virtual DbSet<KanRulesrashigrehFemale> KanRulesrashigrehFemales { get; set; } = null!;
        public virtual DbSet<KanRulesrashigrehMale> KanRulesrashigrehMales { get; set; } = null!;
        public virtual DbSet<TamManglikupay> TamManglikupays { get; set; } = null!;
        public virtual DbSet<TamRulesHouseDrishti> TamRulesHouseDrishtis { get; set; } = null!;
        public virtual DbSet<TamRulesHouseDrishtiMale> TamRulesHouseDrishtiMales { get; set; } = null!;
        public virtual DbSet<TamRulesLagna> TamRulesLagnas { get; set; } = null!;
        public virtual DbSet<TamRulesNak> TamRulesNaks { get; set; } = null!;
        public virtual DbSet<TamRulesRashiGrehDrishti> TamRulesRashiGrehDrishtis { get; set; } = null!;
        public virtual DbSet<TamRulesRashiGrehDrishtiMale> TamRulesRashiGrehDrishtiMales { get; set; } = null!;
        public virtual DbSet<TamRuleshouse> TamRuleshouses { get; set; } = null!;
        public virtual DbSet<TamRuleshouseFemale> TamRuleshouseFemales { get; set; } = null!;
        public virtual DbSet<TamRuleshouseMale> TamRuleshouseMales { get; set; } = null!;
        public virtual DbSet<TamRuleshousedrishtiFemale> TamRuleshousedrishtiFemales { get; set; } = null!;
        public virtual DbSet<TamRuleshousegreha> TamRuleshousegrehas { get; set; } = null!;
        public virtual DbSet<TamRuleshousegrehaFemale> TamRuleshousegrehaFemales { get; set; } = null!;
        public virtual DbSet<TamRuleshousegrehaMale> TamRuleshousegrehaMales { get; set; } = null!;
        public virtual DbSet<TamRuleslagnaMale> TamRuleslagnaMales { get; set; } = null!;
        public virtual DbSet<TamRulesnakFemale> TamRulesnakFemales { get; set; } = null!;
        public virtual DbSet<TamRulesnakMale> TamRulesnakMales { get; set; } = null!;
        public virtual DbSet<TamRulesrashigreh> TamRulesrashigrehs { get; set; } = null!;
        public virtual DbSet<TamRulesrashigrehFemale> TamRulesrashigrehFemales { get; set; } = null!;
        public virtual DbSet<TamRulesrashigrehMale> TamRulesrashigrehMales { get; set; } = null!;
        public virtual DbSet<TelManglikupay> TelManglikupays { get; set; } = null!;
        public virtual DbSet<TelRulesHouseDrishtiMale> TelRulesHouseDrishtiMales { get; set; } = null!;
        public virtual DbSet<TelRulesLagna> TelRulesLagnas { get; set; } = null!;
        public virtual DbSet<TelRulesNak> TelRulesNaks { get; set; } = null!;
        public virtual DbSet<TelRulesRashiGrehDrishtiMale> TelRulesRashiGrehDrishtiMales { get; set; } = null!;
        public virtual DbSet<TelRuleshouse> TelRuleshouses { get; set; } = null!;
        public virtual DbSet<TelRuleshouseFemale> TelRuleshouseFemales { get; set; } = null!;
        public virtual DbSet<TelRuleshouseMale> TelRuleshouseMales { get; set; } = null!;
        public virtual DbSet<TelRuleshousedrishtiFemale> TelRuleshousedrishtiFemales { get; set; } = null!;
        public virtual DbSet<TelRuleshousegrehaFemale> TelRuleshousegrehaFemales { get; set; } = null!;
        public virtual DbSet<TelRuleshousegrehaMale> TelRuleshousegrehaMales { get; set; } = null!;
        public virtual DbSet<TelRuleslagnaMale> TelRuleslagnaMales { get; set; } = null!;
        public virtual DbSet<TelRulesnakFemale> TelRulesnakFemales { get; set; } = null!;
        public virtual DbSet<TelRulesnakMale> TelRulesnakMales { get; set; } = null!;
        public virtual DbSet<TelRulesrashigrehFemale> TelRulesrashigrehFemales { get; set; } = null!;
        public virtual DbSet<TelRulesrashigrehMale> TelRulesrashigrehMales { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //optionsBuilder.UseSqlServer(Properties.Settings.Default.MatchMakingConnectionString);
        //        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MatchMakingConnectionString"].ConnectionString.ToString());
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<ACity>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_a_city")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ACountryMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_country_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ADatum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ADrishti>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpAshtamNaklordDeath>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_Ashtam_Naklord_Death")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpHouseNakLord>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_House_NakLord")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();

                entity.Property(e => e.Title).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<AKpHouseRashi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_House_Rashi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();

                entity.Property(e => e.Title).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<AKpPanchamRashiHouse>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_Pancham_Rashi_House_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpPlanetHouse>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KPplanet_house")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpPlanetRashi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_Planet_Rashi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKpShashtamNaklordDisease>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_KP_Shashtam_Naklord_Disease")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKundli>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_kundlis")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AKundliMapping>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_kundli_mapping_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AManglikUpay>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_manglik_upay1")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<AManglikUpay1>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_manglik_upay")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ANak>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_nak")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.English).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Hindi).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ANakGrahDrishti>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_NakGrahDrishti")
                    .IsUnique()
                    .IsClustered();

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
                entity.HasIndex(e => e.Sno, "IX_A_planet")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.English).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Hindi).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARashi>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rashi")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.English).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Hindi).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARashiSheet>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rashi_sheet")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesHouseDrishti>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_housedrishti")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesRashiGrehDrishti>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_RashiGrahDrishti")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshouse>(entity =>
            {
                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousebangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtibangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtienglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_ruleshousedrishtienglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtigujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtikannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtimarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtipunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtitamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousedrishtitelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshouseenglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_ruleshouseenglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegreha>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_housegrahphal")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehabangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehaenglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_ruleshousegrehaenglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehagujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehakannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehamarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehapunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehatamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegrehatelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousegujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousekannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousemarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousepunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousetamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleshousetelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagna>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_ruleslagna")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnabangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnaenglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_ruleslagnaenglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnagujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnakannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnamarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnapunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnatamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARuleslagnatelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnak>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rulesnak_1")
                    .IsUnique()
                    .IsClustered();
            });

            modelBuilder.Entity<ARulesnakbangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnakenglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rulesnakenglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnakgujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnakkannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnakmarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnakpunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnaktamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesnaktelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigreh>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_RashiGrah")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Pred).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Reference).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehbangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtibangla>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtienglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rulesrashigrehdrishtienglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtigujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtikannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtimarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtipunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtitamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehdrishtitelugu>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehenglish>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_A_rulesrashigrehenglish")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehgujarati>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehkannadum>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehmarathi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehpunjabi>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehtamil>(entity =>
            {
                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ARulesrashigrehtelugu>(entity =>
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

            modelBuilder.Entity<ATempMapping>(entity =>
            {
                entity.HasOne(d => d.MapNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MapNo)
                    .HasConstraintName("FK_a_temp_mappings_a_temp_map");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
