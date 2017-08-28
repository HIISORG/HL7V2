using System;
using System.Collections.Generic;

namespace HL7V2 {
  /// <summary>
  /// HL7V2 message
  /// </summary>
  public class Message {
    public Message() { }
    public Message(string msg) {
      content = msg;
    }

    /// <summary>
    /// Process message.
    /// </summary>
    /// <returns>Result flag</returns>
    public bool Process(){
      if (string.IsNullOrWhiteSpace(content)) return false;
      // MSH must at the begining of the messge
      bool ok = false;
			foreach (string s in content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) {
        if ( s.StartsWith("MSH", StringComparison.OrdinalIgnoreCase)) {
          ok = true;
        }

				Segments.Add(new Segment(s, Version));
			}

      foreach(string s in content.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)){
        Segments.Add(new Segment(s, Version));
      }

      throw new NotImplementedException();
    }

    public override string ToString() {
      return string.Format("[Message: Version={0}]", Version);
    }

    #region Variables
    /// <summary>
    /// Text string of the message content
    /// </summary>
    protected string content { get; set; }
    /// <summary>
    /// Message version number
    /// </summary>
    public string Version { get; set; }
    /// <summary>
    /// Message header segment.
    /// </summary>
    public Segments.MSH MSH { get; set; }
    /// <summary>
    /// Segment list inside the message
    /// </summary>
    public List<Segment> Segments = new List<Segment>();
    #endregion
  }
}