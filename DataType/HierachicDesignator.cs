using System;
using System.Xml.Linq;
namespace HL7V2.DataType {
  /// <summary>
  /// HD. <para />
  /// [namespace id (IS)]^[universal ID (ST)]^[universal ID type (ID)]
  /// </summary>
  public struct HierachicDesignator {
    public HierachicDesignator(string value) {
      if (string.IsNullOrWhiteSpace(value)) {
        NamespaceID = string.Empty;
        UniversalID = string.Empty;
        UniversalIDType = string.Empty;
      } else {
        string[] splits = value.Split('^');
        NamespaceID = splits[0];
        UniversalID = splits.Length > 1 ? splits[1] : string.Empty;
        UniversalIDType = splits.Length > 2 ? splits[2] : string.Empty;
      }
    }

    #region Variables
    /// <summary>
    /// The namespace identifier (ID) Table 0300 User defined table.
    /// <para>User defined table.</para>
    /// </summary>
    public string NamespaceID;
    /// <summary>
    /// The universal identifier (ST).
    /// </summary>
    public string UniversalID;
    /// <summary>
    /// The universal IDT ype (ID) Table 0301.
    /// </summary>
    public string UniversalIDType;
    #endregion
  }
}
