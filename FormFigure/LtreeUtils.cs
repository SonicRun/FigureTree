using System.Text;
using Npgsql;

namespace FormFigure
{
  public class LtreeUtils
  {
    protected static string GetQuereToAddNote(StringBuilder path)
    {
      return $"INSERT INTO woodFigure VALUES('{path}')";
    }

    public static void AddNode(StringBuilder path)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand commandInsert = new NpgsqlCommand(GetQuereToAddNote(path), nc);
        commandInsert.ExecuteScalar();
      }
    }

    protected static string GetQuereToDelNode(StringBuilder path)
    {
      return $"DELETE FROM woodFigure WHERE path='{path}'";
    }

    public static void DelNode(StringBuilder path)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand commandInsert = new NpgsqlCommand($"DELETE FROM woodFigure WHERE path='{path}'", nc);
        commandInsert.ExecuteScalar();
      }
    }
  }
}