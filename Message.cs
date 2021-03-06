﻿using System;
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
    /// Process whole message.
    /// </summary>
    /// <returns>Result flag</returns>
    public bool Process(){
      if (string.IsNullOrWhiteSpace(content)) return false;
      // MSH must at the begining of the messge
      bool ok = false;
			foreach (string s in content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) {
        ok |= s.StartsWith("MSH", StringComparison.OrdinalIgnoreCase);

				Segments.Add(new Segment(s, Version));
			}

      foreach(string s in content.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)){
        Segments.Add(new Segment(s, Version));
      }

      if (!ok) throw new Exception("Incorrect message header");
      throw new NotImplementedException();
    }

    public Segment AddSegment(string s) {
      Segment segment;
      if (s.Substring(0, 3).Equals("MSH", StringComparison.InvariantCultureIgnoreCase)) {
        EncodingCharacter.FieldSeparator = s[3];
      }

      string[] fields = s.Split(EncodingCharacter.FieldSeparator);
      if (fields.Length > 0) {
        switch (s.Substring(0, 3)) {
          case "MSH":
            segment = new Segments.MSH(this, s);
            break;
          case "NTE":
            segment = new Segments.NTE(s);
            break;
          default:
            throw new Exception("Invalid Segment Type: " + s);
        }
      } else segment = new Segment();

      return segment;
    }

    public override string ToString() {
      return string.Format("[Message: Version={0}]", Version);
    }

    #region Variables
    public DataType.EncodingCharacter EncodingCharacter = new DataType.EncodingCharacter();
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