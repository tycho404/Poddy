using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;

namespace Poddy
{
  public class Controller
  {
    private static WebClient webclient;
    private const string FileSuffixForIncompleteFiles = "_incomplete";

    public static Item CurrentDownloadingItem;

    /// <summary>
    /// Download podcastitem to disk
    /// </summary>
    /// <param name="item">Podcastitem</param>
    public static void DownloadItem(Item item)
    {
      if (!Tools.CheckFolderExists(Model.Instance.TargetFolder))
        return;

      DownloadItem(item, Model.Instance.TargetFolder);
    }

    /// <summary>
    /// Download podcastitetm to target on disk
    /// </summary>
    /// <param name="item">Podcastitem</param>
    /// <param name="targetPath">Path to target</param>
    public static void DownloadItem(Item item, string targetPath)
    {
      string filename = Tools.CreateFilenameFromUrl(item.Url);
      string targetFilename = Path.Combine(targetPath, filename + FileSuffixForIncompleteFiles);
      item.TargetFileName = targetFilename;
      CurrentDownloadingItem = item;

      CurrentDownloadingItem.Status = Status.Running;
      try
      {
        webclient = new WebClient();
        webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        webclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
        webclient.DownloadFileAsync(new Uri(item.Url), targetFilename);
      }
      catch (HttpListenerException ex)
      {
        throw new WebException("Error accessing " + item.Url + " - " + ex.Message);
      }
      catch (Exception ex)
      {
        throw new WebException("Error accessing " + item.Url + " - " + ex.Message);
      }
    }

    /// <summary>
    /// Process next queued item to disk
    /// </summary>
    public static void ProcessNextQueuedDownload()
    {
      bool queueEmpty = false;

      foreach (var podcasts in Model.Instance.Podcasts)
      {
        foreach (var item in podcasts.Value.Items)
        {
          if (item.Status == Status.Queued || item.Status == Status.Incomplete)
          {
            DownloadItem(item);
            queueEmpty = true;
            break;
          }
        }

        if (queueEmpty)
          break;
      }

      if (!queueEmpty)
      {
        Controller.EnableUiHandler();
      }

    }

    public static void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
      if (!e.Cancelled)
      {
        // set new status
        SetStatusOfCurrentDownloadingItem(Status.Complete);

        // remove "incomplete" in filename
        string newFileName = CurrentDownloadingItem.TargetFileName.Substring(0, CurrentDownloadingItem.TargetFileName.Length - FileSuffixForIncompleteFiles.Length);
        File.Move(CurrentDownloadingItem.TargetFileName, newFileName);

        // update ui
        ProgressChangedHandler(CurrentDownloadingItem.Status.ToString());

        // process next queued item
        ProcessNextQueuedDownload();
      }
    }

    private static void SetStatusOfCurrentDownloadingItem(Status status)
    {
      Item item = FindItemInModel(CurrentDownloadingItem);
      item.Status = status;
    }

    private static Item FindItemInModel(Item itemToFind)
    {
      Item result = new Item();

      foreach (var podcasts in Model.Instance.Podcasts)
      {
        bool ready = false;
        foreach (var item in podcasts.Value.Items)
        {
          if (item == itemToFind)
          {
            result = item;

            ready = true;
            break;
          }
        }

        if (ready)
          break;
      }

      return result;
    }

    public static void CancelDownload()
    {
      if (webclient != null && webclient.IsBusy)
      {
        webclient.CancelAsync();

        SetStatusOfCurrentDownloadingItem(Status.Incomplete);

        if (ProgressChangedHandler != null)
        {
          ProgressChangedHandler(CurrentDownloadingItem.Status.ToString());
        }
      }
    }

    public delegate void ProgressChangedDelegate(string statusText);
    public delegate void EnableGuiDelegate();

    public static ProgressChangedDelegate ProgressChangedHandler;
    public static EnableGuiDelegate EnableUiHandler;


    private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      if (ProgressChangedHandler != null)
      {
        if (CurrentDownloadingItem.Status == Status.Incomplete)
        {
          ProgressChangedHandler(CurrentDownloadingItem.Status.ToString());
        }
        else
        {
          ProgressChangedHandler(string.Format(CultureInfo.InvariantCulture, "{0} %", e.ProgressPercentage.ToString()));
        }
      }
    }

    public static Podcast GetCatalogOfFeed(string rssUrl)
    {
      String xpathExpr = String.Empty;
      XmlNode xmlNode;
      Podcast result = null;

      // load the Podcast
      XmlDocument doc = new XmlDocument();
      try
      {
        doc.Load(rssUrl);
        result = new Podcast();

        // get meta info of feed
        xpathExpr = string.Format(CultureInfo.InvariantCulture, "/rss/channel/title");
        xmlNode = doc.SelectSingleNode(xpathExpr);
        result.Title = xmlNode.InnerText;

        xpathExpr = string.Format(CultureInfo.InvariantCulture, "/rss/channel/description");
        xmlNode = doc.SelectSingleNode(xpathExpr);
        result.Description = xmlNode.InnerText;

        result.Url = rssUrl;

        // builds a list of item nodes
        XmlNodeList items = doc.SelectNodes("//item");

        List<Item> files = new List<Item>();

        // loop through  list and write out title, URL and filename
        for (int i = 0; i < items.Count; i++)
        {
          Item file = new Item();
          file.Title = items[i].SelectSingleNode("title").InnerText;
          file.Url = items[i].SelectSingleNode("enclosure").Attributes["url"].Value;
          DateTime date = new DateTime();
          DateTime.TryParse(items[i].SelectSingleNode("pubDate").InnerText, out date);
          file.Date = date;
          //file.ItunesSummary = items[i].SelectSingleNode("itunes:summary").InnerText;
          file.Description = items[i].SelectSingleNode("description").InnerText;
          file.Status = Status.New;

          int indexOfSlash = file.Url.LastIndexOf("/");
          file.FileName = file.Url.Substring(indexOfSlash + 1, file.Url.Length - indexOfSlash - 1);

          files.Add(file);
        }

        result.Items = files;
      }
      catch (WebException)
      {
        System.Windows.Forms.MessageBox.Show("RSS-Feed cannot be read from server.");
      }

      return result;
    }

    public static void AddFeed(string rssUrl)
    {
      Podcast podcast = Controller.GetCatalogOfFeed(rssUrl);

      if (podcast == null)
        return;

      Model.Instance.Podcasts.Add(rssUrl, podcast);
    }

    public static void DeleteFeed(string rssUrl)
    {
      if (Model.Instance.Podcasts.ContainsKey(rssUrl))
      {
        Model.Instance.Podcasts.Remove(rssUrl);
      }
    }

    public static string TargetFolder
    {
      get
      {
        return Model.Instance.TargetFolder;
      }

      set
      {
        Model.Instance.TargetFolder = value;
      }
    }

    public static void SaveModel()
    {
      Properties.Settings.Default.Model = Tools.SerializeObject(Model.Instance, typeof(Model));
    }

    public static void LoadModel()
    {
      if (Properties.Settings.Default.Model != null && Properties.Settings.Default.Model != "-1")
      {
        Model model = Tools.DeserializeObject(Properties.Settings.Default.Model, typeof(Model)) as Model;
        if (model != null)
        {
          Model.Instance = model;
        }
      }
    }

    public static void OpenTargetFolder()
    {
      Tools.OpenWindowsExplorer(Model.Instance.TargetFolder);
    }

  }
}
