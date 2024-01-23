using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace felveteli
{

    public interface IFelvetelizo
    {

        String OM_Azonosito { get; set; }
        String Neve { get; set; }
        String ErtesitesiCime { get; set; }
        String Email { get; set; }
        DateTime SzuletesiDatum { get; set; }
        int Matematika { get; set; }
        int Magyar { get; set; }

        String CSVSortAdVissza();

        void ModositCSVSorral(String csvString);
    }
}
