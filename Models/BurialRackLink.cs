using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BurialRackLink
    {
        public double StorageId { get; set; }
        public double? RackShelfId { get; set; }
        public string BurialId { get; set; }

        public virtual BurialData Burial { get; set; }
        public virtual RackData RackShelf { get; set; }
    }
}
