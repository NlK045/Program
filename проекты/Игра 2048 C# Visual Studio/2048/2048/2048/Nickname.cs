using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    [Serializable]
    public class Nickname
    {
        public string Log { get; set; }
        public string Rec { get; set; }
        public string Aktiv { get; set; }
        public Nickname()
        { }
        public Nickname(string log, string rec, string aktiv)
        {
            Log = log;
            Rec = rec;
            Aktiv = aktiv;
        }
    }
    [Serializable]
    public class Record
    {
        public string Log { get; set; }
        public string Tip { get; set; }
        public string Exp { get; set; }
        public string Time { get; set; }
        public Record()
        { }
        public Record(string log, string tip, string exp, string time)
        {
            Log = log;
            Tip = tip;
            Exp = exp;
            Time = time;
        }
    }
}
