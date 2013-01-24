using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

namespace Poddy
{

  public partial class View : Form
  {
    private ListViewColumnSorter lvwColumnSorter;
    
    public View()
    {
      InitializeComponent();

      lvwColumnSorter = new ListViewColumnSorter();
      this.listView.ListViewItemSorter = lvwColumnSorter;
    }

    private void View_Load(object sender, EventArgs e)
    {
      LoadView();

      Controller.LoadModel();

      FillUiWithData();
    }

    private void View_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveView();

      Controller.SaveModel();

      Properties.Settings.Default.Save();
    }

    private void SaveView()
    {
      if (this.WindowState == FormWindowState.Normal)
      {
        Properties.Settings.Default.NormalLeft = this.Left;
        Properties.Settings.Default.NormalTop = this.Top;
        Properties.Settings.Default.NormalWidth = this.Width;
        Properties.Settings.Default.NormalHeight = this.Height;
        Properties.Settings.Default.WindowState = this.WindowState.ToString();
        Properties.Settings.Default.SplitterDistance = this.splitContainer.SplitterDistance;
      }
      else if (this.WindowState == FormWindowState.Maximized)
      {
        Properties.Settings.Default.WindowState = this.WindowState.ToString();
        Properties.Settings.Default.SplitterDistance = this.splitContainer.SplitterDistance;
      }
    }

    private void LoadView()
    {
      if (Properties.Settings.Default.NormalLeft == -1)
      {
        int width = 745;
        int height = 454;
        this.Left = (Screen.PrimaryScreen.Bounds.Width/2) - (width /2);
        this.Top = (Screen.PrimaryScreen.Bounds.Height / 2) - (height /2); 
        this.Width = width;
        this.Height = height;
        this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), Properties.Settings.Default.WindowState);
        this.splitContainer.SplitterDistance = Properties.Settings.Default.SplitterDistance;
      }
      else
      {
        this.Left = Properties.Settings.Default.NormalLeft;
        this.Top = Properties.Settings.Default.NormalTop;
        this.Width = Properties.Settings.Default.NormalWidth;
        this.Height = Properties.Settings.Default.NormalHeight;
        this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), Properties.Settings.Default.WindowState);
        this.splitContainer.SplitterDistance = Properties.Settings.Default.SplitterDistance;
      }

    }


    private void FillUiWithData()
    {
      // fill listbox
      listBox.Items.Clear();
      foreach (Podcast item in Model.Instance.Podcasts.Values)
      {
        listBox.Items.Add(item);
      }

      if (listBox.Items.Count > 0)
      {
        listBox.SelectedItem = Model.Instance.SelectedPodcast;
      }

      // fill textbox with targetfolder
      tstbTargetFolder.Text = Model.Instance.TargetFolder;
    }

    private void EnableUi()
    {
      SwitchUi(true);
    }

    private void DisableUi()
    {
      SwitchUi(false);
    }

    private void SwitchUi(bool enabled)
    {
      this.listBox.Enabled =
        this.listView.Enabled = 
        this.tsbAddFeed.Enabled =
        this.tsbDeleteFeed.Enabled = 
        this.tsbRefreshAllFeeds.Enabled = 
        this.tsbtStartDownload.Enabled = 
        enabled;
    }

    private void tsbAddFeed_Click(object sender, EventArgs e)
    {
      DialogAddFeed dlg = new DialogAddFeed();
      dlg.StartPosition = FormStartPosition.CenterParent;
      DialogResult result = dlg.ShowDialog();
      if (result == System.Windows.Forms.DialogResult.OK)
      {
        string url = dlg.Url;

        if (!string.IsNullOrEmpty(url))
        {
          Podcast podcast = Controller.GetCatalogOfFeed(url);

          if (podcast == null)
            return;

          Model.Instance.Podcasts.Add(url, podcast);
          Model.Instance.SelectedPodcast = podcast;
          FillUiWithData();
        }
      }
    }

    private void tsbDeleteFeed_Click(object sender, EventArgs e)
    {
      foreach (Podcast item in listBox.SelectedItems)
      {
        Model.Instance.Podcasts.Remove(item.Url);
      }

      if (listBox.SelectedIndex > 0)
      {
        Model.Instance.SelectedPodcast = listBox.Items[listBox.SelectedIndex-1] as Podcast;
      }

      FillUiWithData();
    }

    private void tsbRefreshAllFeeds_Click(object sender, EventArgs e)
    {
      Controller.RefreshFeeds();
      FillUiWithData();
    }

    private void tsbtBrowse_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dlg = new FolderBrowserDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        tstbTargetFolder.Text = Model.Instance.TargetFolder = dlg.SelectedPath;
      }
    }

    private void tsbtOpenTargetFolder_Click(object sender, EventArgs e)
    {
      if (!Tools.CheckFolderExists(Model.Instance.TargetFolder))
      {
        this.tstbTargetFolder.Focus();

        return;
      }

      Controller.OpenTargetFolder();
    }

    private void listBox_SelectedValueChanged(object sender, EventArgs e)
    {
      if (listBox.SelectedItems.Count > 1)
        return;

      // update Listview
      listView.BeginUpdate();
      Podcast key = (Podcast)listBox.SelectedItem;
      listView.Items.Clear();

      foreach (Item item in Model.Instance.Podcasts[key.Url].Items)
      {
        ListViewItem listViewItem = new ListViewItem();
        listViewItem.SubItems[0] = new ListViewItem.ListViewSubItem(listViewItem, item.Status.ToString());
        listViewItem.SubItems.Add(item.Title);
        ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
        subItem.Text = item.Date.ToShortDateString();
        subItem.Tag = item.Date;
        listViewItem.SubItems.Add(subItem);
        listViewItem.SubItems.Add(item.Description);
        listViewItem.Tag = item;
        listViewItem.ToolTipText = item.Description;

        listView.Items.Add(listViewItem);
      }

      // Loop through and size each column header to fit the column header text.
      foreach (ColumnHeader ch in this.listView.Columns)
      {
        ch.Width = -2;
      }


      listView.EndUpdate();

      // update Model
      Model.Instance.SelectedPodcast = key;
    }

    private void listView_DoubleClick(object sender, EventArgs e)
    {
      foreach (ListViewItem selectedItem in listView.SelectedItems)
      {
        Item item = selectedItem.Tag as Item;
        if (item.Status == Status.New || item.Status == Status.Incomplete)
        {
          item.Status = Status.Queued;
          selectedItem.Tag = item;

          selectedItem.SubItems[0].Text = item.Status.ToString();
        }
        else if (item.Status == Status.Queued)
        {
          item.Status = Status.New;
          selectedItem.Tag = item;

          selectedItem.SubItems[0].Text = item.Status.ToString();
        }
      }
    }

    private void ProgressHandler(string statusText)
    {
      foreach (ListViewItem listViewItem in listView.Items)
      {
        Item item = listViewItem.Tag as Item;

        if (item == Controller.CurrentDownloadingItem)
        {
          listViewItem.SubItems[0].Text = statusText;
          break;
        }
      }
    }

    private void tsbtStartDownload_Click(object sender, EventArgs e)
    {
      if (!Tools.CheckFolderExists(Model.Instance.TargetFolder))
      {
        this.tstbTargetFolder.Focus();
        return;
      }

      DisableUi();

      Controller.ProgressChangedHandler += ProgressHandler;
      Controller.EnableUiHandler += EnableUi;
      Controller.ProcessNextQueuedDownload();
    }

    private void tsbtStopDownload_Click(object sender, EventArgs e)
    {
      EnableUi();

      Controller.CancelDownload();
      Controller.ProgressChangedHandler -= ProgressHandler;
      Controller.EnableUiHandler -= EnableUi;

    }

    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Determine if clicked column is already the column that is being sorted.
      if (e.Column == lvwColumnSorter.SortColumn)
      {
        // Reverse the current sort direction for this column.
        if (lvwColumnSorter.Order == SortOrder.Ascending)
        {
          lvwColumnSorter.Order = SortOrder.Descending;
        }
        else
        {
          lvwColumnSorter.Order = SortOrder.Ascending;
        }
      }
      else
      {
        // Set the column number that is to be sorted; default to ascending.
        lvwColumnSorter.SortColumn = e.Column;
        lvwColumnSorter.Order = SortOrder.Ascending;
      }

      // Perform the sort with these new sort options.
      this.listView.Sort();
    }

  
  }
}
