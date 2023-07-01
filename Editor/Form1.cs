using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
  public partial class Form1 : Form
  {
    String Archivo;
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Clear();
      Archivo = null;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Texto|*.txt";
      if(openFileDialog.ShowDialog() == DialogResult.OK)
      {
        Archivo = openFileDialog.FileName;
        using (StreamReader A =new StreamReader(Archivo))
        {
          rTxtMessage.Text = A.ReadToEnd();
        }
      }
    }

    private void rTxtMessage_TextChanged(object sender, EventArgs e)
    {
   
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {

    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFile = new SaveFileDialog();
      saveFile.Filter = "Text|*.txt";
      if (Archivo != null)
      {
        using (StreamWriter writer = new StreamWriter(Archivo))
        {
          writer.Write(rTxtMessage.Text);
        }
      }
      else
      {
        if (saveFile.ShowDialog() == DialogResult.OK)
        {
          Archivo = saveFile.FileName;
          using (StreamWriter swriter = new StreamWriter(saveFile.FileName))
          {
            swriter.Write(rTxtMessage.Text);
          }
        }
      }
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Undo();
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Redo();
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Copy();
    }

    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Cut();
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.Paste();
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rTxtMessage.SelectAll();
    }

    private void stylesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      if(colorDialog.ShowDialog() == DialogResult.OK)
      {
        rTxtMessage.ForeColor = colorDialog.Color;
      }
    }

    private void fontToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FontDialog fontDialog = new FontDialog();
      if (fontDialog.ShowDialog() == DialogResult.OK)
      {
        rTxtMessage.Font = fontDialog.Font;
      }
    }
  }
}
