using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Poddy;

namespace TestProject
{
  /// <summary>
  ///Dies ist eine Testklasse für "ControllerTest" und soll
  ///alle ControllerTest Komponententests enthalten.
  ///</summary>
  [TestClass()]
  public class ControllerTest
  {
    private TestContext testContextInstance;
    private static string rssFile;

    /// <summary>
    ///Ruft den Testkontext auf, der Informationen
    ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Zusätzliche Testattribute

    //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:

    //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
      string tempFile = System.IO.Path.GetTempFileName();
      string tempFolder = testContext.TestDir;

      // write RSS sourcefile
      rssFile = Path.Combine(tempFolder, Path.GetFileName(tempFile));
      System.IO.File.WriteAllText(rssFile, Properties.Resources.RssFeed);
    }

    //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
    [ClassCleanup()]
    public static void MyClassCleanup()
    {
      if (System.IO.File.Exists(rssFile))
      {
        System.IO.File.Delete(rssFile);
      }
    }

    //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
    [TestInitialize()]
    public void MyTestInitialize()
    {
    }

    //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
    [TestCleanup()]
    public void MyTestCleanup()
    {
      //string folder = testContextInstance.TestDir;

      //if (Directory.Exists(folder))
      //{
      //  Directory.Delete(folder, true);
      //}
    }

    #endregion


    /// <summary>
    ///Ein Test für "GetDirectoryOfFeed"
    ///</summary>
    [TestMethod()]
    public void GetDirectoryOfFeedTest()
    {
      string rssUrl = @"file://" + rssFile;
      Podcast expected = new Podcast();
      expected.Title = "CRE: Technik, Kultur, Gesellschaft";
      expected.Description = "Der Interview-Podcast mit Tim Pritlove";
      expected.Url = rssUrl;
      expected.Items = new List<Item>();

      Item item1 = new Item();
      item1.FileName = "cre197-ipv6.mp3";
      item1.Title = "CRE197 IPv6";
      item1.Url = @"http://feedproxy.google.com/~r/cre-podcast/~5/vFEBFGH8_qQ/cre197-ipv6.mp3";
      item1.Status = Status.New;
      expected.Items.Add(item1);

      Item item2 = new Item();
      item2.FileName = "cre166_segeln.mp3";
      item2.Title = "CRE166 Segeln";
      item2.Url = @"http://feedproxy.google.com/~r/cre-podcast/~5/zzCLAjsGg5Q/cre166_segeln.mp3";
      item2.Status = Status.New;
      expected.Items.Add(item2);

      Podcast actual;
      actual = Controller.GetCatalogOfFeed(rssUrl);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///Ein Test für "AddFeed"
    ///</summary>
    [TestMethod()]
    public void AddFeedTest()
    {
      string rssUrl = @"file://" + rssFile;
      Assert.IsTrue(Model.Instance.Podcasts.Count == 0);
      Controller.AddFeed(rssUrl);
      Assert.IsTrue(Model.Instance.Podcasts.Count == 1);
    }

    /// <summary>
    ///Ein Test für "DeleteFeed"
    ///</summary>
    [TestMethod()]
    public void DeleteFeedTest()
    {
      string rssUrl = @"file://" + rssFile;
      Assert.IsTrue(Model.Instance.Podcasts.Count == 0);
      Controller.AddFeed(rssUrl);
      Assert.IsTrue(Model.Instance.Podcasts.Count == 1);
      Controller.DeleteFeed(rssUrl);
      Assert.IsTrue(Model.Instance.Podcasts.Count == 0);
    }

    /// <summary>
    ///Ein Test für "TargetFolder"
    ///</summary>
    [TestMethod()]
    public void TargetFolderTest()
    {
      string tempFolder = Path.GetTempPath();
      string expected = tempFolder;
      string actual;
      Controller.TargetFolder = expected;
      actual = Controller.TargetFolder;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///Ein Test für "DownloadFile"
    ///</summary>
    [TestMethod()]
    public void DownloadFileTest()
    {
      Item item = new Item();
      item.Url = @"http://www.jonline.de/main/media/background_header.png";
      item.Title = "TestTitle";
      string targetPath = testContextInstance.TestDir;
      string targetFilename = Tools.CreateFilenameFromUrl(item.Url);
      string targetFile = Path.Combine(targetPath, targetFilename);
      Assert.IsFalse(File.Exists(targetFile));
      Controller.DownloadItem(item, targetPath);
      Assert.IsTrue(File.Exists(targetFile));
    }
  }
}
