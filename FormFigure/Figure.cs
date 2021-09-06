using System;

namespace FormFigure
{
  public class Figure : IFigure
  {
    public Figure(int id, double a, double b, int typeFigureId)
    {
      ID = id;
      A = a;
      B = b;
      TypeFigureId = typeFigureId;
    }

    public int ID { get; set; }
    public double A { get; set; }
    public double B { get; set; }
    public int TypeFigureId { get; set; }


    public string GetTypeId()
    {
      string result = "";

      switch (TypeFigureId)
      {
        case FigureTypeConsts.Rectangle:
          result = FigureTypeConsts.RectangleText;
          break;
        case FigureTypeConsts.Square:
          result = FigureTypeConsts.SquareText;
          break;
        case FigureTypeConsts.Circle:
          result = FigureTypeConsts.CircleText;
          break;
      }

      return result;
    }

    public double GetSpace()
    {
      double result = 0;


      switch (TypeFigureId)
      {
        case FigureTypeConsts.Rectangle:
          result = A * B;
          break;
        case FigureTypeConsts.Square:
          result = A * A;
          break;
        case FigureTypeConsts.Circle:
          result = A * A * Math.PI;
          break;
        default:
          result = 0;
          break;
      }

      return result;
    }
  }
}