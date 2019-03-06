using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Native.Csharp.Business.Model
{
    public class JingCaiWinRateInfo
    {
        public int code { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string[] idListRed { get; set; }
        public float[] chartDataList { get; set; }
        public string[] nameListRed { get; set; }
        public string[] nameListBlue { get; set; }
        public float[] winRateListBlue { get; set; }
        public bool result { get; set; }
        public int[] winTimesListBlue { get; set; }
        public string[] idListBlue { get; set; }
        public int[] loseTimesListRed { get; set; }
        public int[] loseTimesListBlue { get; set; }
        public float[] winRateListRed { get; set; }
        public int[] winTimesListRed { get; set; }
        public string lastUpdateTime { get; set; }
    }

}
