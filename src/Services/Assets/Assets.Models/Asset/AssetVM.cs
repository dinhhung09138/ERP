using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models.Asset
{
    public class AssetVM
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime DateBy { get; set; }

        public DateTime? WantityDate { get; set; }
    }
}
