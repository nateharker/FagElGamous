using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class RackData
    {
        public RackData()
        {
            BurialRackLink = new HashSet<BurialRackLink>();
        }

        public double RackShelfId { get; set; }
        public string RackId { get; set; }
        public double? ShelfId { get; set; }

        public virtual ICollection<BurialRackLink> BurialRackLink { get; set; }
    }
}
