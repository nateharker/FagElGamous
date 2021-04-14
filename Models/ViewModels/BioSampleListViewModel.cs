using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class BioSampleListViewModel
    {
        public List<BioSampleData> BioSampleDatas { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
    }
}
