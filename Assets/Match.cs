using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    [Serializable()]
    class Match 
    {
        private string P1NAME;
        private string P2NAME;
        private int P1LEGSWON;
        private int P1SETSWON;
        private int P2LEGSWON;
        private int P2SETSWON;
        private DateTime date;

        public Match(string P1NAME, string P2NAME, int P1LEGSWON, int P1SETSWON, int P2LEGSWON, int P2SETSWON)
        {
            this.P1NAME = P1NAME;
            this.P2NAME = P2NAME;
            this.P1LEGSWON = P1LEGSWON;
            this.P1SETSWON = P1SETSWON;
            this.P2LEGSWON = P2LEGSWON;
            this.P2SETSWON = P2SETSWON;

            this.date = DateTime.Now;
        }

        public string getP1NAME { get { return P1NAME; } }
        public string getP2NAME { get { return P2NAME; } }
        public int getP1LEGSWON { get { return P1LEGSWON; } }
        public int getP2LEGSWON { get { return P2LEGSWON; } }
        public int getP1SETSWON { get { return P1SETSWON; } }
        public int getP2SETSWON { get { return P2SETSWON; } }
        public DateTime getDate { get { return date; } }

        public string toString()
        {
            return date.ToString()+":   "+P1NAME + ": " + P1LEGSWON + " legs " + P1SETSWON + " sets, " + P2NAME + ": " + P2LEGSWON + " legs " + P2SETSWON + " sets";
        }
    }
}
