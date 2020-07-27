using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Player
    {
        public int PlayerNumber { get; set; }
        public string PlayerType { get; set; }
        public List<Card> Cards { get; set; }
    }
}
