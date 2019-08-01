using System;
namespace HL7V2.Segments {
  public class NTE : Segment {
    public NTE() {
    }
    public NTE(string s) {
      content = s;
    }

    #region Variables
    /// <summary>
    /// NTE-1 Set ID (SI) 00096. Optional.
    /// <para /> This field may be used where multiple NTE segments are included in a message. Their numbering must be described in the application message definition.
    /// </summary>
    public int SetID { get; set; } = 1;
    /// <summary>
    /// NTE-2 Source of comment (ID) 00097. Optional.
    /// <para /> Refer to HL7 Table 0105.
    /// </summary>
    public HL7Table.SourceOfComment SourceOfComment { get; set; } = HL7Table.SourceOfComment.None;
    /// <summary>
    /// NTE-3 Comment (FT) 00098. Optional.
    /// </summary>
    public string Comment { get; set; } = string.Empty;
    /// <summary>
    /// NTE-4 Comment type (CE) 01318.
    /// Use HL7 Table 0364 Comment Type for name of code
    /// </summary>
    public DataType.CodeElement CommentType { get; set; }
    #endregion
  }
}
