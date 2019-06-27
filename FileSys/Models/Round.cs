using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSys.Models {
    public class Round {
        public string Object { get; set; }
        public int All { get; set; }
        public int Used { get; set; }
        public int  Notused { get; set; }
        public string Percentage { get; set; }
        public int Percentageshow { get; set; }
    }

    public class RoundManager {
        public static Round GetRound() {
            var Rounds = new Round();
            Rounds.Object = "C";
            Rounds.All = 579;
            Rounds.Used = 123;
            Rounds.Notused = 456;
            Rounds.Percentage = "18,1000";
            Rounds.Percentageshow = 30;
            return Rounds;
        }
    }
}
