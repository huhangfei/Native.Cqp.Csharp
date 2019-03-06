using System.Collections.Generic;

namespace Native.Csharp.Business.Model
{
    public class JingCaiInfo
    {
        public List<ShiShenInfo> HongFang { get; set; }
        public List<ShiShenInfo> LanFang { get; set; }

        public float HongDeFen { get; set; }

        public float LanDeFen { get; set; }


        public string LastUpdate { get; set; }
    }

    public class ShiShenInfo
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int ShengChang { get; set; }

        public int FuChang { get; set; }

        public float WinRate { get ;set;  }
    }
}
