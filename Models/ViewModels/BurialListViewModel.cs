using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class BurialListViewModel
    {
        public List<BurialData> BurialDatas { get; set; }
        public List<C14data> C14Datas { get; set; }
        public List<BioSampleData> BioSampleDatas { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string FilterString { get; set; }
    }
}
