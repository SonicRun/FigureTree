using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormFigure
{
  class DataUtils
  {
    public static int CreateNewFigure(int typeId, double a, double b = default)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand commandInsert =
          new NpgsqlCommand($"INSERT INTO Figure (TypeFigureID, A, B) VALUES ({typeId}, {a}, {b}) RETURNING id", nc);
        Object res = commandInsert.ExecuteScalar();
        if (res != null) return Int32.Parse(res.ToString());
        return 0;
      }
    }

    public static List<string> GetParentSquareAndChildCircle()
    {
      List<string> listBox1 = new List<string>();
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        int id1, id2;

        nc.Open();
        NpgsqlCommand command = new NpgsqlCommand(
          $@"select fig1.typefigureid,node.children,node.parent,fig2.typefigureid from 
          (select
        cast(CAST(subpath(path, -1, 1) AS text) as int) as children,
        cast(split_part(CAST(subpath(path, 0, -1) as text), '.', nlevel(path) - 1) as int) as parent
        from woodfigure
        where nlevel(path) > 1 ) node
          join figure as fig1 on node.children = fig1.id
        join figure as fig2 on node.parent = fig2.id
        where fig1.typefigureid = 1 and fig2.typefigureid = 2
        ", nc);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          id1 = Convert.ToInt32((reader.GetValue(1).ToString()));
          id2 = Convert.ToInt32((reader.GetValue(2).ToString()));
          Figure figureByIdChild = DataUtils.GetFigureById(Convert.ToInt32(id1));
          Figure figureByIdParent = DataUtils.GetFigureById(Convert.ToInt32(id2));
          listBox1.Add(
            $"ID={figureByIdChild.ID}, Тип = {figureByIdChild.GetTypeId()}, Площадь = {figureByIdChild.GetSpace()} у него родитель: ID={figureByIdParent.ID}, Тип = {figureByIdParent.GetTypeId()}, Площадь = {figureByIdParent.GetSpace()} ");
        }
      }

      return listBox1;
    }

    public static List<string> GetAllTree()
    {
      List<string> listTable = new List<string>();
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select CAST(path AS text) from woodFigure", nc);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listTable.Add(reader.GetValue(0).ToString());
        }
      }

      return listTable;
    }

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="id">id удаления</param>
    public static void DeleteFigure(int id)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand commandInsert = new NpgsqlCommand($@"DELETE FROM Figure WHERE ID = {id}", nc);
        commandInsert.ExecuteNonQuery();
      }
    }

    /// <summary>
    /// Редактирование
    /// </summary>
    public static void EditFigure(int id, int typeId, double a, double b = default)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand commandInsert =
          new NpgsqlCommand($"UPDATE Figure SET TypeFigureID = {typeId}, A ={a} ,B = {b} WHERE ID ={id}", nc);
        commandInsert.ExecuteNonQuery();
      }
    }


    public static List<StringBuilder> GetTree()
    {
      List<StringBuilder> result = new List<StringBuilder>();
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        List<string> row = new List<string>();
        nc.Open();
        NpgsqlCommand command =
          new NpgsqlCommand($"select CAST(path AS text) from woodfigure order by subpath(path,0,nlevel(path) - 1)", nc);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          row.Add(reader.GetValue(0).ToString());
        }

        if (row.Count > 0)
        {
          foreach (string s in row)
          {
            StringBuilder sAdd = new StringBuilder();
            sAdd.Clear();
            string[] item = s.Split('.');
            foreach (string s1 in item)
            {
              Figure figureById = DataUtils.GetFigureById(Convert.ToInt32(s1));
              sAdd.Append($"ID={figureById.ID}, Тип = {figureById.GetTypeId()}, Площадь = {figureById.GetSpace()}.");
            }

            result.Add(sAdd);
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Получение фигуры из БД по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Figure GetFigureById(int id)
    {
      using (NpgsqlConnection nc = new NpgsqlConnection(Form1.ConnString))
      {
        nc.Open();
        NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM Figure  WHERE ID = {id}", nc);
        NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          int fieldsCount = reader.FieldCount;
          int a, b, typeId;
          typeId = Int32.Parse(reader.GetValue(1).ToString());
          a = Int32.Parse(reader.GetValue(2).ToString());
          b = Int32.Parse(reader.GetValue(3).ToString());

          return new Figure(id, a, b, typeId);
        }
      }


      return null;
    }
  }
}