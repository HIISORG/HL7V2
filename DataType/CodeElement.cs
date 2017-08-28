using System;
namespace HL7V2.DataType {
  /// <summary>
  /// CE - Code element.
  /// </summary>
  public struct CodeElement {

    public string Identifier;
    public string Text;
    public string CodingSystem;
    public string AlternateIdentifier;
    public string AlternateText;
    public string AlternateCodingSystem;
  }
}
