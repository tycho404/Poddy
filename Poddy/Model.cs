using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Poddy
{
  public enum Status { New, Queued, Running, Incomplete, Complete }

  [Serializable()] 
  public class Model
  {
    private static Model instance;

    private Model() {}

    public static Model Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new Model();

          instance.Podcasts = new SerializableDictionary<string, Podcast>();
        }

        return instance;
      }

      set
      {
        instance = value;
      }
    }

    public string TargetFolder { get; set; }
    public SerializableDictionary<string, Podcast> Podcasts { get; set; }
    public Podcast SelectedPodcast { get; set; }
    public int WindowPosX { get; set; }
    public int WindowPosY { get; set; }
    public int WindowSizeX { get; set; }
    public int WindowSizeY { get; set; }

  }

  [Serializable()] 
  public class Podcast
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public List<Item> Items { get; set; }

    public override bool Equals(object obj)
    {
      if (obj is Podcast)
        return Equals(obj as Podcast);
      
      return base.Equals(obj);
    }

    public override string ToString()
    {
      return Title;
    }
    private bool Equals(Podcast obj)
    {
      bool result = true;
      result &=
        string.Equals(Title, obj.Title) && 
        string.Equals(Description, obj.Description) && 
        string.Equals(Url, obj.Url);

      for (int i = 0; i < Items.Count; i++)
      {
        result &= Items[i].Equals(obj.Items[i]);

        if (!result)
          break;
      }

      return result;
    }

  }

  [Serializable()]
  public class Item
  {
    public string Title { get; set; }
    public string Url { get; set; }
    public string FileName { get; set; }
    public string TargetFileName { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Status Status { get; set; }

    public override bool Equals(object obj)
    {
      if (obj is Item)
        return Equals(obj as Item);

      return base.Equals(obj);
    }

    private bool Equals(Item obj)
    {
      return (
        string.Equals(Title, obj.Title) &&
        string.Equals(Url, obj.Url) &&
        string.Equals(FileName, obj.FileName) &&
        string.Equals(Status, obj.Status)
        );
    }

  }

}
