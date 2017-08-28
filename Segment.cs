using System;
using System.Collections.Generic;
namespace HL7V2 {
  /// <summary>
  /// HL7V2 Segment.
  /// </summary>
  public class Segment {
    public Segment() { }
    public Segment(string content) {
      this.content = content;
    }
    public Segment(string content, string version) {
      this.content = content;
      this.version = version;
    }

    public bool Process() {
      if (string.IsNullOrWhiteSpace(content)) return false;

      string[] splits = content.Split('|');
      if (splits.Length == 0) return false;
      if (!Enum.TryParse(splits[0], out HL7Table.SegmentType ID)) return false;

      return true;
    }

    #region Variables
    protected string content = string.Empty;
    protected readonly string version = string.Empty;
    /// <summary>
    /// First three characters of the segment
    /// </summary>
    public HL7Table.SegmentType ID { get; set; }
    /// <summary>
    /// Text description of the segment type
    /// </summary>
    public string Type { get { return ID.DisplayName(); } }
    /// <summary>
    /// HL7V2 Fields inside the segment
    /// </summary>
    public List<Field> Fields = new List<Field>();
    #endregion
  }
}