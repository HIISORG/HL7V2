using System;
using HL7Table;
namespace HL7V2.DataType {
  /// <summary>
  /// ST - String
  /// </summary>
  public struct TextString : IDataType {

    public TextString(string value) {
      Value = value;
    }

    public string ToString(HL7Version version) {
      if (string.IsNullOrEmpty(Value)) return "";
      return Value;
    }

    public string Value;
  }
}