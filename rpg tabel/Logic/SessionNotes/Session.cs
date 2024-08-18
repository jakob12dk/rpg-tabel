using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.SessionNotes
{
    public class Session
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public List<SessionNote> Notes { get; set; } = new List<SessionNote>();
    }

}
