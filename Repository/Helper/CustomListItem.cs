using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Helper
{
    public class CustomListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
   
        public int ID_Drzava { get; set; }
        public int ID_Drzavljanstvo { get; set; }
        public int ID_DrzavaRodjenja { get; set; }
        public int ID_DrzavaStanovanja { get; set; }
        public string DrzavaName { get; set; }
        public string JezikName { get; set; }
        public int ID_StraniJezikAktivno { get; set; }
        public int ID_StraniJezikPasivno { get; set; }
        public int ID_ClanstvoU { get; set; }
        public string ClanstvoName { get; set; }
        public int ID_StrucnaSprema { get; set; }
        public string StrucnaSpremaName { get; set; }
        public int ID_Spol { get; set; }
        public string SpolName { get; set; }
       
        


    }
}
