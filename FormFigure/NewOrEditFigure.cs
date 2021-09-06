using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFigure
{
  public partial class NewOrEditFigure : Form
  {
    public NewOrEditFigure()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Констркутор для редактирования
    /// </summary>
    /// <param name="id"></param>
    public NewOrEditFigure(int id)
    {
      InitializeComponent();
      Figure figure = DataUtils.GetFigureById(id);
      visibleControls(figure.TypeFigureId);
      textBox1.Text = figure.A.ToString();
      textBox2.Text = figure.B.ToString();
      foreach (TypeFigure consTypesFigureType in FigureTypes.ConsTypesFigureTypes)
      {
        if (consTypesFigureType.ID == figure.TypeFigureId)
        {
          comboBox1.SelectedItem = consTypesFigureType;
          break;
        }
      }
      
    }

    private void NewOrEditFigure_Load(object sender, EventArgs e)
    {
      comboBox1.DataSource = FigureTypes.ConsTypesFigureTypes;
      comboBox1.ValueMember = "ID";
      comboBox1.DisplayMember = "NameTypeFigure";
      setVisivle(comboBox1.SelectedIndex + 1);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      visibleControls(comboBox1.SelectedIndex + 1);
    }

    private void visibleControls(int id)
    {
      
      if (id == FigureTypes.TypeFigureSqure.ID)
      {
        label2.Text = "Сторона квадрата";
        label2.Visible = true;
        label3.Visible = false;
        textBox1.Visible = true;
        textBox2.Visible = false;
      }
      else if (id == FigureTypes.TypeFigureСircle.ID)
      {
        label2.Text = "Радиус";
        label2.Visible = true;
        label3.Visible = false;
        textBox1.Visible = true;
        textBox2.Visible = false;
      }
      else if (id == FigureTypes.TypeFigureRectangle.ID)
      {
        label2.Text = "Длина";
        label3.Text = "Ширина";
        label2.Visible = true;
        label3.Visible = true;
        textBox1.Visible = true;
        textBox2.Visible = true;
      }

    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char number = e.KeyChar;
      if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
      {
        e.Handled = true;
      }
    }

    public int GetTypeID()
    {
      return comboBox1.SelectedIndex + 1;
    }

    public double GetA()
    {
      return double.Parse(textBox1.Text);
    }

    public double GetB()
    {
      if (textBox2.Text == "")
      {
        return default;
      }
      else if (double.Parse(textBox2.Text) is double d)
      {
        return d;
      }

      return default;
    }

   

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      setVisivle(comboBox1.SelectedIndex + 1);
    }

    private void setVisivle(int id)
    {
      if (id == FigureTypes.TypeFigureSqure.ID)
      {
        button1.Visible = textBox1.Text != "";
      }
      else if (id == FigureTypes.TypeFigureСircle.ID)
      {
        button1.Visible = textBox1.Text != "";
      }
      else if (id == FigureTypes.TypeFigureRectangle.ID)
      {
        button1.Visible = textBox1.Text == "" && textBox2.Text == "";
      }
    }
  }
}