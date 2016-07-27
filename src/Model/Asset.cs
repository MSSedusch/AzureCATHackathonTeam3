using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Asset
    {
        public string Name { get; set; }
        public List<AssetValue> Values { get; set; }
        public AssetType Type { get; set; }
    }
}
