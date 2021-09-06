using System.Collections.Generic;

namespace FormFigure
{
  public class FigureTypes
  {
    public static List<TypeFigure> ConsTypesFigureTypes = new List<TypeFigure>();

    public static TypeFigure TypeFigureСircle = addConstType(FigureTypeConsts.Circle, FigureTypeConsts.CircleText);
    public static TypeFigure TypeFigureSqure = addConstType(FigureTypeConsts.Square, FigureTypeConsts.SquareText);
    public static TypeFigure TypeFigureRectangle = addConstType(FigureTypeConsts.Rectangle, FigureTypeConsts.RectangleText);

    private static TypeFigure addConstType(int i, string name)
    {
      TypeFigure temp = new TypeFigure(i, name);
      ConsTypesFigureTypes.Add(temp);
      return temp;
    }
  }
}