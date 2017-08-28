namespace HL7V2.DataType {
  /// <summary>
  /// Base of all HL7V2 data type
  /// </summary>
  public interface IDataType {
    /// <summary>
    /// Value this instance.
    /// </summary>
    /// <returns>The value.</returns>
    string ToString(HL7Table.HL7Version version);
  }
}