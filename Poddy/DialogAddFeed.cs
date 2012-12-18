using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poddy
{
  public partial class DialogAddFeed : Form
  {
    public DialogAddFeed()
    {
      InitializeComponent();
    }

    private void btAdd_Click(object sender, EventArgs e)
    {
      Url = this.tbUrl.Text;
    }

    public string Url { get; set; }

    private void btCancel_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
