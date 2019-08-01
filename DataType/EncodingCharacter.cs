using System.ComponentModel;
using System.Collections.Generic;
namespace HL7V2.DataType {
  /// <summary>
  /// HL7 message delimiters
  /// </summary>
  public class EncodingCharacter {

    public EncodingCharacter() { }

    public EncodingCharacter(string value) {
      if (!string.IsNullOrWhiteSpace(value)) {
        char[] c = value.ToCharArray();
        FieldSeparator = c[0];
				ComponentSeparator = c[1];
        RepetitionSeparator = c.Length > 2 ? c[2] : '~';
        EscapeCharacter = c.Length > 3 ? c[3] : '\\';
				SubComponentSeparator = c.Length > 4 ? c[4] : '&';
      }
    }

    public override string ToString() {
      return string.Format("{0}{1}{2}{3}", 
                           ComponentSeparator, 
                           RepetitionSeparator, 
                           EscapeCharacter, 
                           SubComponentSeparator);
    }

    /// <summary>
    /// Separates two adjacent data fields within a segment. It also separates the segment ID from the first data field in each segment. Position 0
    /// </summary>
    [DisplayName("Field Separator")]
    public char FieldSeparator { get; set; } = '|';
    /// <summary>
    /// Separates adjacent components of data fields where allowed. Position 1
    /// </summary>
    [DisplayName("Component Separator")]
    public char ComponentSeparator { get; set; } = '^';
    /// <summary>
    /// Separates adjacent subcomponents of data fields where allowed. If there are no subcomponents, this character may be omitted. Position 4
    /// </summary>
    [DisplayName("Subcomponent Separator")]
    public char SubComponentSeparator { get; set; } = '&';
    /// <summary>
    /// Separates multiple occurrences of a field where allowed. Position 2
    /// </summary>
    [DisplayName("Repetition Separator")]
    public char RepetitionSeparator { get; set; } = '~';
    /// <summary>
    /// Escape character for use with any field represented by an ST, TX, or FT data type, or for use with the data (fourth) component of the ED data type. 
    /// If no escape characters are used in a message, this character may be ommitted. However, it must be present if subcomponents are used in the message.
    /// </summary>
    [DisplayName("Escape Character")]
    public char EscapeCharacter { get; set; } = '\\';
  }
}