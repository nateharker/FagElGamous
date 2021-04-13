using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class BurialListViewModel
    {
        public List<BurialData> BurialDatas { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
    }
}
