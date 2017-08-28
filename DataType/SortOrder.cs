using System;
using System.Collections.Generic;
namespace HL7V2.DataType {
  /// <summary>
  /// SRT - Sort Order.
  /// <para>[Sort-by field/parameter (varies)]^[sequencing(ID)]</para>
  /// </summary>
  public struct SortOrder : IDataType {

    public string ToString(HL7Table.HL7Version version) {
      List<string> lst = new List<string>() {
        SortBy.ToString(version),
        Sequencing.Value()
      };

      return string.Join("^", lst);
    }

    /// <summary>
    /// Sort-by field/parameter (varies)
    /// </summary>
    public TextString SortBy;
    /// <summary>
    /// Sequencing (ID)
    /// <para>Identifies how the field or parameter will be sorted; and, if sorted, whether the sort will be case sensitive (the default) or not. Refer to HL7 Table 0397</para>
    /// </summary>
    public HL7Table.Sequencing Sequencing;
  }
}
