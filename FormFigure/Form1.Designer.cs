﻿namespace FormFigure
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(13, 13);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(351, 520);
      this.treeView1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(13, 539);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(139, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Новая фигура";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(13, 568);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(139, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Редактировать фигуру";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(13, 597);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(139, 23);
      this.button3.TabIndex = 3;
      this.button3.Text = "Удалить фигуру";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button4.Location = new System.Drawing.Point(1114, 948);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(347, 23);
      this.button4.TabIndex = 4;
      this.button4.Text = "Все объекты типа круг, у которых родителем является квадрат";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button5
      // 
      this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button5.Location = new System.Drawing.Point(1114, 977);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(347, 23);
      this.button5.TabIndex = 5;
      this.button5.Text = "Все объекты дерева, упорядоченные от корня";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(394, 15);
      this.listBox1.MultiColumn = true;
      this.listBox1.Name = "listBox1";
      this.listBox1.ScrollAlwaysVisible = true;
      this.listBox1.Size = new System.Drawing.Size(1067, 927);
      this.listBox1.TabIndex = 6;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1473, 1012);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.treeView1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.ListBox listBox1;
  }
}

