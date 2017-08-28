using System;
namespace HL7V2 {
  public class Field {
    public Field(string version) {
      this.version = version;
    }
    public Field(string content, string version) {
      this.content = content;
      this.version = version;
    }

    #region Variables
    string content;
    readonly string version;
    public int Sequence;
    #endregion
  }
}
