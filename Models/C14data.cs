using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class C14data
    {
        public double C14Id { get; set; }
        public string BurialLocNs { get; set; }
        public double? NsLow { get; set; }
        public double? NsHigh { get; set; }
        public string BurialLocEw { get; set; }
        public double? EwLow { get; set; }
        public double? EwHigh { get; set; }
        public string Subplot { get; set; }
        public double? BurialNum { get; set; }
        public double? BurialArea { get; set; }
        public double? Rack { get; set; }
        public double? TubeNum { get; set; }
        public string BurialDescription { get; set; }
        public double? SizeMl { get; set; }
        public double? Foci { get; set; }
        public double? C14Sample2017 { get; set; }
        public string LocationDetails { get; set; }
        public string Questions { get; set; }
        public double? UnknownNumbers { get; set; }
        public double? Conventional14cAgeBp { get; set; }
        public double? _14cCalendarDate { get; set; }
        public double? Calibrated95CalendarDateMax { get; set; }
        public double? Calibrated95CalendarDateMin { get; set; }
        public double? Calibrated95CalendarDateSpan { get; set; }
        public double? Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public string HeadDirection { get; set; }
        public string BurialId { get; set; }

        public virtual BurialData Burial { get; set; }
    }
}
