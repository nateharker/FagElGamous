using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BurialData
    {
        public BurialData()
        {
            BioSampleData = new HashSet<BioSampleData>();
            BurialRackLink = new HashSet<BurialRackLink>();
            C14data = new HashSet<C14data>();
        }

        public string BurialId { get; set; }
        public string BurialLocNs { get; set; }
        public double? NsLow { get; set; }
        public double? NsHigh { get; set; }
        public string BurialLocEw { get; set; }
        public double? EwLow { get; set; }
        public double? EwHigh { get; set; }
        public string Subplot { get; set; }
        public double? BurialNum { get; set; }
        public string AreaHillBurials { get; set; }
        public string Tomb { get; set; }
        public double? YearExcav { get; set; }
        public string MonthExcav { get; set; }
        public string DateExcav { get; set; }
        public string TimeExcav { get; set; }
        public string ExcavRecorder { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPg { get; set; }
        public string Goods { get; set; }
        public string ArtifactFound { get; set; }
        public string ArtifactDescription { get; set; }
        public string HairPresent { get; set; }
        public string HairColorCode { get; set; }
        public string BurialHairColor { get; set; }
        public string FaceBundle { get; set; }
        public double? BurialSampleTaken { get; set; }
        public string HairTaken { get; set; }
        public string SoftTissueTaken { get; set; }
        public string BoneTaken { get; set; }
        public string ToothTaken { get; set; }
        public string TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string EstimateLivingStature { get; set; }
        public string LengthOfRemains { get; set; }
        public double? BurialLength { get; set; }
        public double? BurialDepth { get; set; }
        public string BurialSituationNotes { get; set; }
        public double? WestToHead { get; set; }
        public double? WestToFeet { get; set; }
        public double? SouthToHead { get; set; }
        public double? SouthToFeet { get; set; }
        public string SampleNumber { get; set; }
        public string PreservationIndex { get; set; }
        public string BurialPreservation { get; set; }
        public string BurialMaterials { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialDirection { get; set; }
        public string HeadDirection { get; set; }
        public string ClusterYn { get; set; }
        public string ClusterNum { get; set; }
        public string Sex { get; set; }
        public string SexMethod { get; set; }
        public string GenderGe { get; set; }
        public string GeFunctionTotal { get; set; }
        public string AgeAtDeath { get; set; }
        public string AgeCode { get; set; }
        public string AgeMethod { get; set; }
        public string BurialAdultChild { get; set; }
        public string ToBeCo0firmed { get; set; }
        public double? B1uSample { get; set; }
        public double? BodyAnalysis { get; set; }
        public double? YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public string DateOnSkull { get; set; }
        public double? SkullAtMagazi0e { get; set; }
        public string Postcra0iaAtMagazi0e { get; set; }
        public string SexSkull2018 { get; set; }
        public string AgeSkull2018 { get; set; }
        public double? ArcGisRefNum { get; set; }
        public string BasilarSuture { get; set; }
        public string VentralArc { get; set; }
        public string SubpubicAngle { get; set; }
        public string SciaticNotch { get; set; }
        public string PubicBone { get; set; }
        public string PreaurSulcus { get; set; }
        public string MedialIpRamus { get; set; }
        public string DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public string FemurHead { get; set; }
        public string HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string FemurLength { get; set; }
        public string HumerusLength { get; set; }
        public string TibiaLength { get; set; }
        public string Robust { get; set; }
        public string SupraorbitalRidges { get; set; }
        public string OrbitEdge { get; set; }
        public string ParietalBossing { get; set; }
        public string Gonian { get; set; }
        public string NuchalCrest { get; set; }
        public string ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public string MaximumCranialLength { get; set; }
        public string MaximumCranialBreadth { get; set; }
        public string BasionBregmaHeight { get; set; }
        public string BasionNasion { get; set; }
        public string BasionProsthionLength { get; set; }
        public string BizygomaticDiameter { get; set; }
        public string NasionProsthion { get; set; }
        public string MaximumNasalBreadth { get; set; }
        public string InterorbitalBreadth { get; set; }
        public string SkullTrauma { get; set; }
        public string Postcra0iaTrauma { get; set; }
        public string CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public string ButtonOsteoma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public string TmjOa { get; set; }
        public string LinearHypolasiaEnamel { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string OsteologyNotes { get; set; }

        public virtual ICollection<BioSampleData> BioSampleData { get; set; }
        public virtual ICollection<BurialRackLink> BurialRackLink { get; set; }
        public virtual ICollection<C14data> C14data { get; set; }
    }
}
