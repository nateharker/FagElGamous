using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BioSampleData
    {
        public double BioSampleId { get; set; }
        public double? RackNum { get; set; }
        public string BagNum { get; set; }
        public string BurialLocNs { get; set; }
        public double? NsLow { get; set; }
        public double? NsHigh { get; set; }
        public string BurialLocEw { get; set; }
        public double? EwLow { get; set; }
        public double? EwHigh { get; set; }
        public string Subplot { get; set; }
        public double? BurialNum { get; set; }
        public double? BurialItemId { get; set; }
        public string BioSampleDate { get; set; }
        public double? PrevSampled { get; set; }
        public string ClusterNum { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }
        public string BurialId { get; set; }

        public virtual BurialData Burial { get; set; }
    }
}
