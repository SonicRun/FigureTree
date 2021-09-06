using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFigure
{
  interface IFigure
  {
    int ID { get; set; }

    double A { get; set; }
    double B { get; set; }
    double GetSpace();
  }
}
