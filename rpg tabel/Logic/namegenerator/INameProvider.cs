using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.namegenerator
{
    public interface INameProvider
    {
        List<string> GetFirstNames();
        List<string> GetLastNames();
    }
}
