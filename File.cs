using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using HL7V2.Segments;
namespace HL7V2 {
  /// <summary>
  /// File.
  /// </summary>
  public class File : IDisposable {

    public File(string content) {
      this.content = content;
      Process();
    }
    public File(Stream stream) {
      StreamReader sr = new StreamReader(stream);
      content = sr.ReadToEnd();
      Process();
    }
    public File(FileInfo file) {
      content = file.OpenText().ReadToEnd();
      Process();
    }

    public void Process() {
      bool ok = false;
      // Process each line
      foreach (string s in content.Split(SegmentTerminator, StringSplitOptions.RemoveEmptyEntries)) {
        if (!ok) {
          // Process only start after the file type has been identified
          switch (s.Substring(0, 4)) {
            case "FHS":
              Type = FileType.File;
              #region Process FHS segment
              if (s.Length < 10) return;
              EncodingCharacters.FieldSeparator = s[3];
              #endregion
              break;
            case "BHS":
              Type = FileType.Batch;
              Segments.Add(new Segment(s));
              ok = true;
              break;
            case "MSH":
              Type = FileType.Message;
              Batchs.Add(new Batch());
              Batchs.Last().Messages.Add(new Message(s));
              ok = true;
              break;
            default:
              // Proces segment
              Messages.Last().Segments.Add(new Segment(s));
              break;
          }
        } else {
          Segments.Add(new Segment(s));
        }
      }
    }

    public override string ToString() {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach(Segment s in Segments) {
        sb.Append(s.ToString());
      }
      return sb.ToString();
    }

    public void Dispose() {
      GC.SuppressFinalize(this);
    }

		#region Variables
    /// <summary>
    /// The delimiters to seperate each segment. This value cannot be changed by implementors.
    /// </summary>
		readonly string[] SegmentTerminator = {
		  Environment.NewLine,
		  "\n",
		  "\r"
		};
    /// <summary>
    /// File content in text format.
    /// </summary>
    string content = string.Empty;
    public FileType Type = FileType.None;
    /// <summary>
    /// FHS-2 File encoding characters (ST) 00068.
    /// </summary>
    public DataType.EncodingCharacter EncodingCharacters { get; set; }
    /// <summary>
    /// FHS-3 File sending application (ST) 00069.
    /// </summary>
    public string SendingApplication { get; set; }
    /// <summary>
    /// FHS-4 File sending facility (ST) 00070.
    /// </summary>
    public string SendingFacility { get; set; }
    /// <summary>
    /// FHS-5 File receiving application (ST) 00071.
    /// </summary>
    public string ReceivingApplication { get; set; }
    /// <summary>
    /// FHS-6 File receiving facility (ST) 00072
    /// </summary>
    public string ReceivingFacility { get; set; }
    /// <summary>
    /// FHS-7 File reation date/time (TS) 00073
    /// </summary>
    public string CreationDateTime { get; set; }
    /// <summary>
    /// FHS-8 File security (ST) 00074.
    /// <para /> In some applications of HL7 this field is used to implement security features. Its use is not yet further specified.
    /// </summary>
    public string Security { get; set; }
    /// <summary>
    /// FHS-9 File name/ID/type (ST) 00075.
    /// <para />This field can be used by the application processing the batch. It can have extra components is needed.
    /// </summary>
    public string NameID { get; set; }
    /// <summary>
    /// FHS-10 File comment (ST) 00076.
    /// 
    /// </summary>
    /// <value>The comment.</value>
    public string Comment { get; set; }
    /// <summary>
    /// FHS-11 File control ID (ST) 00077
    /// </summary>
		public string ControlID { get; set; }
    /// <summary>
    /// FHS-12 Reference field control ID (ST) 00078
    /// </summary>
		public string ReferenceID { get; set; }
    /// <summary>
    /// SH-13 File sending network address (HD).
    /// </summary>
    public string SendingAddress { get; set; }
    /// <summary>
    /// FHS-14 File receiving network address (HD).
    /// </summary>
    public string ReceivingAddress { get; set; }

    public List<Batch> Batchs = new List<Batch>();
    List<Message> Messages = new List<Message>();
    List<Segment> Segments = new List<Segment>();
    #endregion
  }

  public enum FileType {
    None,
    File,
    Batch,
    Message
  }
}
