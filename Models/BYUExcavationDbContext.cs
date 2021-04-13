using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BYUExcavationDbContext : DbContext
    {
        public BYUExcavationDbContext()
        {
        }

        public BYUExcavationDbContext(DbContextOptions<BYUExcavationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BioSampleData> BioSampleData { get; set; }
        public virtual DbSet<BurialData> BurialData { get; set; }
        public virtual DbSet<BurialRackLink> BurialRackLink { get; set; }
        public virtual DbSet<C14data> C14data { get; set; }
        public virtual DbSet<RackData> RackData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BYUExcavationDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BioSampleData>(entity =>
            {
                entity.HasKey(e => e.BioSampleId)
                    .HasName("PK_BioSampleData_BioSampleID");

                entity.Property(e => e.BioSampleId).HasColumnName("bio_sample_id");

                entity.Property(e => e.BagNum)
                    .HasColumnName("bag_num")
                    .HasMaxLength(255);

                entity.Property(e => e.BioSampleDate)
                    .HasColumnName("bio_sample_date")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .HasMaxLength(225);

                entity.Property(e => e.BurialItemId).HasColumnName("burial_item_id");

                entity.Property(e => e.BurialLocEw)
                    .HasColumnName("burial_loc_ew")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLocNs)
                    .HasColumnName("burial_loc_ns")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialNum).HasColumnName("burial_num");

                entity.Property(e => e.ClusterNum)
                    .HasColumnName("cluster_num")
                    .HasMaxLength(255);

                entity.Property(e => e.EwHigh).HasColumnName("ew_high");

                entity.Property(e => e.EwLow).HasColumnName("ew_low");

                entity.Property(e => e.Initials)
                    .HasColumnName("initials")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.NsHigh).HasColumnName("ns_high");

                entity.Property(e => e.NsLow).HasColumnName("ns_low");

                entity.Property(e => e.PrevSampled).HasColumnName("prev_sampled");

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.Property(e => e.Subplot)
                    .HasColumnName("subplot")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BioSampleData)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__BioSample__buria__6EF57B66");
            });

            modelBuilder.Entity<BurialData>(entity =>
            {
                entity.HasKey(e => e.BurialId);

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .HasMaxLength(225);

                entity.Property(e => e.AgeAtDeath)
                    .HasColumnName("age_at_death")
                    .HasMaxLength(255);

                entity.Property(e => e.AgeCode)
                    .HasColumnName("age_code")
                    .HasMaxLength(255);

                entity.Property(e => e.AgeMethod)
                    .HasColumnName("age_method")
                    .HasMaxLength(255);

                entity.Property(e => e.AgeSkull2018)
                    .HasColumnName("age_skull2018")
                    .HasMaxLength(255);

                entity.Property(e => e.ArcGisRefNum).HasColumnName("arc_gis_ref_num");

                entity.Property(e => e.AreaHillBurials)
                    .HasColumnName("area_hill_burials")
                    .HasMaxLength(255);

                entity.Property(e => e.ArtifactDescription)
                    .HasColumnName("artifact_description")
                    .HasMaxLength(255);

                entity.Property(e => e.ArtifactFound)
                    .HasColumnName("artifact_found")
                    .HasMaxLength(255);

                entity.Property(e => e.B1uSample).HasColumnName("b1u_sample");

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.BasionBregmaHeight)
                    .HasColumnName("basion_bregma_height")
                    .HasMaxLength(255);

                entity.Property(e => e.BasionNasion)
                    .HasColumnName("basion_nasion")
                    .HasMaxLength(255);

                entity.Property(e => e.BasionProsthionLength)
                    .HasColumnName("basion_prosthion_length")
                    .HasMaxLength(255);

                entity.Property(e => e.BizygomaticDiameter)
                    .HasColumnName("bizygomatic_diameter")
                    .HasMaxLength(255);

                entity.Property(e => e.BodyAnalysis).HasColumnName("body_analysis");

                entity.Property(e => e.BoneTaken)
                    .HasColumnName("bone_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialAdultChild)
                    .HasColumnName("burial_adult_child")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialDirection)
                    .HasColumnName("burial_direction")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialHairColor)
                    .HasColumnName("burial_hair_color")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLength).HasColumnName("burial_length");

                entity.Property(e => e.BurialLocEw)
                    .HasColumnName("burial_loc_ew")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLocNs)
                    .HasColumnName("burial_loc_ns")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialMaterials)
                    .HasColumnName("burial_materials")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialNum).HasColumnName("burial_num");

                entity.Property(e => e.BurialPreservation)
                    .HasColumnName("burial_preservation")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialSampleTaken).HasColumnName("burial_sample_taken");

                entity.Property(e => e.BurialSituationNotes)
                    .HasColumnName("burial_situation_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialWrapping)
                    .HasColumnName("burial_wrapping")
                    .HasMaxLength(255);

                entity.Property(e => e.ButtonOsteoma)
                    .HasColumnName("button_osteoma")
                    .HasMaxLength(255);

                entity.Property(e => e.ClusterNum)
                    .HasColumnName("cluster_num")
                    .HasMaxLength(255);

                entity.Property(e => e.ClusterYn)
                    .HasColumnName("cluster_yn")
                    .HasMaxLength(255);

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.CribraOrbitala)
                    .HasColumnName("cribra_orbitala")
                    .HasMaxLength(255);

                entity.Property(e => e.DateExcav)
                    .HasColumnName("date_excav")
                    .HasMaxLength(255);

                entity.Property(e => e.DateOnSkull)
                    .HasColumnName("date_on_skull")
                    .HasMaxLength(255);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.DorsalPitting)
                    .HasColumnName("dorsal_pitting")
                    .HasMaxLength(255);

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(255);

                entity.Property(e => e.EstimateLivingStature)
                    .HasColumnName("estimate_living_stature")
                    .HasMaxLength(255);

                entity.Property(e => e.EwHigh).HasColumnName("ew_high");

                entity.Property(e => e.EwLow).HasColumnName("ew_low");

                entity.Property(e => e.ExcavRecorder)
                    .HasColumnName("excav_recorder")
                    .HasMaxLength(255);

                entity.Property(e => e.FaceBundle)
                    .HasColumnName("face_bundle")
                    .HasMaxLength(255);

                entity.Property(e => e.FemurHead)
                    .HasColumnName("femur_head")
                    .HasMaxLength(255);

                entity.Property(e => e.FemurLength)
                    .HasColumnName("femur_length")
                    .HasMaxLength(255);

                entity.Property(e => e.FieldBook)
                    .HasColumnName("field_book")
                    .HasMaxLength(255);

                entity.Property(e => e.FieldBookPg)
                    .HasColumnName("field_book_pg")
                    .HasMaxLength(255);

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasMaxLength(255);

                entity.Property(e => e.GeFunctionTotal)
                    .HasColumnName("GE_function_total")
                    .HasMaxLength(255);

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasMaxLength(255);

                entity.Property(e => e.Gonian)
                    .HasColumnName("gonian")
                    .HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasColumnName("goods")
                    .HasMaxLength(255);

                entity.Property(e => e.HairColorCode)
                    .HasColumnName("hair_color_code")
                    .HasMaxLength(255);

                entity.Property(e => e.HairPresent)
                    .HasColumnName("hair_present")
                    .HasMaxLength(255);

                entity.Property(e => e.HairTaken)
                    .HasColumnName("hair_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(255);

                entity.Property(e => e.HumerusHead)
                    .HasColumnName("humerus_head")
                    .HasMaxLength(255);

                entity.Property(e => e.HumerusLength)
                    .HasColumnName("humerus_length")
                    .HasMaxLength(255);

                entity.Property(e => e.InterorbitalBreadth)
                    .HasColumnName("interorbital_breadth")
                    .HasMaxLength(255);

                entity.Property(e => e.LengthOfRemains)
                    .HasColumnName("length_of_remains")
                    .HasMaxLength(255);

                entity.Property(e => e.LinearHypolasiaEnamel)
                    .HasColumnName("linear_hypolasia_enamel")
                    .HasMaxLength(255);

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasColumnName("maximum_cranial_breadth")
                    .HasMaxLength(255);

                entity.Property(e => e.MaximumCranialLength)
                    .HasColumnName("maximum_cranial_length")
                    .HasMaxLength(255);

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasColumnName("maximum_nasal_breadth")
                    .HasMaxLength(255);

                entity.Property(e => e.MedialIpRamus)
                    .HasColumnName("medial_IP_ramus")
                    .HasMaxLength(255);

                entity.Property(e => e.MetopicSuture)
                    .HasColumnName("metopic_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.MonthExcav)
                    .HasColumnName("month_excav")
                    .HasMaxLength(255);

                entity.Property(e => e.MonthOnSkull)
                    .HasColumnName("month_on_skull")
                    .HasMaxLength(255);

                entity.Property(e => e.NasionProsthion)
                    .HasColumnName("nasion_prosthion")
                    .HasMaxLength(255);

                entity.Property(e => e.NsHigh).HasColumnName("ns_high");

                entity.Property(e => e.NsLow).HasColumnName("ns_low");

                entity.Property(e => e.NuchalCrest)
                    .HasColumnName("nuchal_crest")
                    .HasMaxLength(255);

                entity.Property(e => e.OrbitEdge)
                    .HasColumnName("orbit_edge")
                    .HasMaxLength(255);

                entity.Property(e => e.OsteologyNotes).HasColumnName("osteology_notes");

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasColumnName("osteology_unknown_comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(255);

                entity.Property(e => e.ParietalBossing)
                    .HasColumnName("parietal_bossing")
                    .HasMaxLength(255);

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(255);

                entity.Property(e => e.PoroticHyperostosis)
                    .HasColumnName("porotic_hyperostosis")
                    .HasMaxLength(255);

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasColumnName("porotic_hyperostosis_locations")
                    .HasMaxLength(255);

                entity.Property(e => e.Postcra0iaAtMagazi0e)
                    .HasColumnName("postcra0ia_at_magazi0e")
                    .HasMaxLength(255);

                entity.Property(e => e.Postcra0iaTrauma)
                    .HasColumnName("postcra0ia_trauma")
                    .HasMaxLength(255);

                entity.Property(e => e.PreaurSulcus)
                    .HasColumnName("preaur_sulcus")
                    .HasMaxLength(255);

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(255);

                entity.Property(e => e.PubicBone)
                    .HasColumnName("pubic_bone")
                    .HasMaxLength(255);

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasMaxLength(255);

                entity.Property(e => e.Robust)
                    .HasColumnName("robust")
                    .HasMaxLength(255);

                entity.Property(e => e.SampleNumber)
                    .HasColumnName("sample_number")
                    .HasMaxLength(255);

                entity.Property(e => e.SciaticNotch)
                    .HasColumnName("sciatic_notch")
                    .HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(255);

                entity.Property(e => e.SexMethod)
                    .HasColumnName("sex_method")
                    .HasMaxLength(255);

                entity.Property(e => e.SexSkull2018)
                    .HasColumnName("sex_skull2018")
                    .HasMaxLength(255);

                entity.Property(e => e.SkullAtMagazi0e).HasColumnName("skull_at_magazi0e");

                entity.Property(e => e.SkullTrauma)
                    .HasColumnName("skull_trauma")
                    .HasMaxLength(255);

                entity.Property(e => e.SoftTissueTaken)
                    .HasColumnName("soft_tissue_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.Subplot)
                    .HasColumnName("subplot")
                    .HasMaxLength(255);

                entity.Property(e => e.SubpubicAngle)
                    .HasColumnName("subpubic_angle")
                    .HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges)
                    .HasColumnName("supraorbital_ridges")
                    .HasMaxLength(255);

                entity.Property(e => e.TextileTaken)
                    .HasColumnName("textile_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.TibiaLength)
                    .HasColumnName("tibia_length")
                    .HasMaxLength(255);

                entity.Property(e => e.TimeExcav)
                    .HasColumnName("time_excav")
                    .HasMaxLength(255);

                entity.Property(e => e.TmjOa)
                    .HasColumnName("tmj_oa")
                    .HasMaxLength(255);

                entity.Property(e => e.ToBeCo0firmed)
                    .HasColumnName("to_be_co0firmed")
                    .HasMaxLength(255);

                entity.Property(e => e.Tomb)
                    .HasColumnName("tomb")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothTaken)
                    .HasColumnName("tooth_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.VentralArc)
                    .HasColumnName("ventral_arc")
                    .HasMaxLength(255);

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.Property(e => e.YearExcav).HasColumnName("year_excav");

                entity.Property(e => e.YearOnSkull).HasColumnName("year_on_skull");

                entity.Property(e => e.ZygomaticCrest)
                    .HasColumnName("zygomatic_crest")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BurialRackLink>(entity =>
            {
                entity.HasKey(e => e.StorageId)
                    .HasName("PK_BurialRackLink_StorageID");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .HasMaxLength(225);

                entity.Property(e => e.RackShelfId).HasColumnName("rack_shelf_id");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BurialRackLink)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__BurialRac__buria__693CA210");

                entity.HasOne(d => d.RackShelf)
                    .WithMany(p => p.BurialRackLink)
                    .HasForeignKey(d => d.RackShelfId)
                    .HasConstraintName("FK__BurialRac__rack___59FA5E80");
            });

            modelBuilder.Entity<C14data>(entity =>
            {
                entity.HasKey(e => e.C14Id)
                    .HasName("PK_C14Data_C14ID");

                entity.ToTable("C14Data");

                entity.Property(e => e.C14Id).HasColumnName("c14_id");

                entity.Property(e => e.BurialArea).HasColumnName("burial_area");

                entity.Property(e => e.BurialDescription)
                    .HasColumnName("burial_description")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .HasMaxLength(225);

                entity.Property(e => e.BurialLocEw)
                    .HasColumnName("burial_loc_ew")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLocNs)
                    .HasColumnName("burial_loc_ns")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialNum).HasColumnName("burial_num");

                entity.Property(e => e.C14Sample2017).HasColumnName("c14_sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg).HasColumnName("calibrated_95_calendar_date_avg");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95_calendar_date_max");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95_calendar_date_min");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("calibrated_95_calendar_date_span");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(255);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14c_age_bp");

                entity.Property(e => e.EwHigh).HasColumnName("ew_high");

                entity.Property(e => e.EwLow).HasColumnName("ew_low");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(255);

                entity.Property(e => e.LocationDetails)
                    .HasColumnName("location_details")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.NsHigh).HasColumnName("ns_high");

                entity.Property(e => e.NsLow).HasColumnName("ns_low");

                entity.Property(e => e.Questions)
                    .HasColumnName("questions")
                    .HasMaxLength(255);

                entity.Property(e => e.Rack).HasColumnName("rack");

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.Subplot)
                    .HasColumnName("subplot")
                    .HasMaxLength(255);

                entity.Property(e => e.TubeNum).HasColumnName("tube_num");

                entity.Property(e => e.UnknownNumbers).HasColumnName("unknown_numbers");

                entity.Property(e => e._14cCalendarDate).HasColumnName("14c_calendar_date");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.C14data)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__C14Data__burial___6E01572D");
            });

            modelBuilder.Entity<RackData>(entity =>
            {
                entity.HasKey(e => e.RackShelfId)
                    .HasName("PK_RackData_RackShelfID");

                entity.Property(e => e.RackShelfId).HasColumnName("rack_shelf_id");

                entity.Property(e => e.RackId)
                    .HasColumnName("rack_id")
                    .HasMaxLength(255);

                entity.Property(e => e.ShelfId).HasColumnName("shelf_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
