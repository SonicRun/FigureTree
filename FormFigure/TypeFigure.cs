namespace FormFigure
{
  public class TypeFigure
  {
    public int ID { get; set; }
    public string NameTypeFigure { get; set; }

    public TypeFigure(int id, string nameTypeFigure)
    {
      ID = id;
      NameTypeFigure = nameTypeFigure;
    }
  }
}