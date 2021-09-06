using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FormFigure
{
  public partial class Form1 : Form
  {
    public static string ConnString = "Host=localhost;Username=postgres;Password=12345;Database=Figure";

    public Form1()
    {
      InitializeComponent();
    }


    //a. Все объекты дерева, упорядоченные от корня,
    //select * from woodfigure order by subpath(path,0,nlevel(path) - 1)

    //b. Все объекты типа круг, у которых родителем является квадрат
    //select fig1.typefigureid, node.children, node.parent, fig2.typefigureid from
    //(select
    //  cast(CAST(subpath(path, -1, 1) AS text) as int) as children,
    //cast(split_part(CAST(subpath(path, 0, -1) as text), '.',nlevel(path)-1) as int) as parent
    //  from woodfigure
    //  where nlevel(path) >1 ) node
    //  join figure as fig1 on node.children = fig1.id
    //  join figure as fig2 on node.parent = fig2.id
    //  where fig1.typefigureid = 1 and fig2.typefigureid =2

    private void Form1_Load(object sender, EventArgs e)
    {
      openFormToTreeView(treeView1);
    }

    private void openFormToTreeView(TreeView treeview)
    {
      List<string> listTable = DataUtils.GetAllTree();
      if (listTable.Count > 0)
      {
        foreach (string s in listTable)
        {
          string[] item = s.Split('.');
          if (item.Length == 1)
          {
            addTreeForTreeView(item[0]);
          }
          else if (item.Length > 1)
          {
            addTreeForTreeView(item[item.Length - 1], item[item.Length - 2]);
          }
        }
      }
    }

    private void addTreeForTreeView(string addNode, string parentNode = null)
    {
      if (parentNode == null)
      {
        Figure figureById = DataUtils.GetFigureById(Convert.ToInt32(addNode));
        string nameFigureNew = "";
        foreach (TypeFigure consTypesFigureType in FigureTypes.ConsTypesFigureTypes)
        {
          if (consTypesFigureType.ID == figureById.TypeFigureId)
          {
            nameFigureNew = consTypesFigureType.NameTypeFigure;
          }
        }

        TreeNode treeNode = new TreeNode {Name = addNode, Text = nameFigureNew};

        treeView1.Nodes.Add(treeNode);
      }
      else
      {
        Figure figureById = DataUtils.GetFigureById(Convert.ToInt32(addNode));
        string nameFigureNew = "";
        foreach (TypeFigure consTypesFigureType in FigureTypes.ConsTypesFigureTypes)
        {
          if (consTypesFigureType.ID == figureById.TypeFigureId)
          {
            nameFigureNew = consTypesFigureType.NameTypeFigure;
            break;
          }
        }

        TreeNode treeNode = new TreeNode {Name = addNode, Text = nameFigureNew};
        TreeNode[] treeNodes = treeView1.Nodes.Find(parentNode, true);
        treeNodes[0].Nodes.Add(treeNode);
      }
    }

    /// <summary>
    /// Новая фигура
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
      if (treeView1.Nodes.Count == 0)
      {
        NewOrEditFigure figure = new NewOrEditFigure();
        if (figure.ShowDialog(this) == DialogResult.OK)
        {
          TreeNode treeNode = addTree(figure);
          treeView1.Nodes.Add(treeNode);
          StringBuilder treeNodeFullPath = createPath(treeNode);
          LtreeUtils.AddNode(treeNodeFullPath);
        }
      }
      else
      {
        if (treeView1.SelectedNode == null)
        {
          MessageBox.Show("Не выбран родительский объект для добавления");
        }
        else //добавление нового элемента
        {
          NewOrEditFigure figure = new NewOrEditFigure();
          if (figure.ShowDialog(this) == DialogResult.OK)
          {
            TreeNode treeNode = addTree(figure);
            treeView1.SelectedNode.Nodes.Add(treeNode);
            StringBuilder treeNodeFullPath = createPath(treeNode);
            LtreeUtils.AddNode(treeNodeFullPath);
          }
        }
      }
    }

    private StringBuilder createPath(TreeNode item)
    {
      StringBuilder path = new StringBuilder(item.Name);
      var parent = item.Parent as TreeNode;
      if (parent != null)
        path.Insert(0, createPath(parent).ToString() + ".");
      return path;
    }

    public TreeNode addTree(NewOrEditFigure form)
    {
      string nameFigureNew = "";
      double b = form.GetB();
      double a = form.GetA();
      int id = DataUtils.CreateNewFigure(form.GetTypeID(), a, b);
      foreach (TypeFigure consTypesFigureType in FigureTypes.ConsTypesFigureTypes)
      {
        if (consTypesFigureType.ID == form.GetTypeID())
        {
          nameFigureNew = consTypesFigureType.NameTypeFigure;
          break;
        }
      }

      TreeNode add = new TreeNode {Name = id.ToString(), Text = nameFigureNew};
      return add;
    }

    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button3_Click(object sender, EventArgs e)
    {
      TreeNode selectedNode = treeView1.SelectedNode;
      if (selectedNode != null)
      {
        if (selectedNode.Nodes.Count != 0)
        {
          MessageBox.Show("Удалять можно только листы дерева");
          return;
        }

        if (MessageBox.Show($@"Точно хотите удалить объект {selectedNode.Text}", "Предупреждение",
          MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          selectedNode.Remove();
          DataUtils.DeleteFigure(Convert.ToInt32(selectedNode.Name));
          StringBuilder stringBuilder = createPath(selectedNode);
          LtreeUtils.DelNode(stringBuilder);
        }
      }
      else
      {
        MessageBox.Show("Не выбран  объект для удаления");
      }
    }

    /// <summary>
    /// Редактировать
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button2_Click(object sender, EventArgs e)
    {
      TreeNode selectedNode = treeView1.SelectedNode;
      if (selectedNode != null)
      {
        string selectedNodeText = selectedNode.Text;
        int id = Convert.ToInt32(selectedNode.Name);
        NewOrEditFigure figure = new NewOrEditFigure(id);
        if (figure.ShowDialog(this) == DialogResult.OK)
        {
          string nameFigureNew = "";
          double b = figure.GetB();
          double a = figure.GetA();

          DataUtils.EditFigure(id, figure.GetTypeID(), a, b);
          foreach (TypeFigure consTypesFigureType in FigureTypes.ConsTypesFigureTypes)
          {
            if (consTypesFigureType.ID == figure.GetTypeID())
            {
              nameFigureNew = consTypesFigureType.NameTypeFigure;
              break;
            }
          }

          selectedNode.Text = nameFigureNew;
        }
      }
      else
      {
        MessageBox.Show("Не выбран объект для редактирования");
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      foreach (string s in DataUtils.GetParentSquareAndChildCircle())
      {
        listBox1.Items.Add(s);
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      foreach (StringBuilder s in DataUtils.GetTree())
      {
        listBox1.Items.Add(s);
      }
    }
  }
}