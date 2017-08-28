using System.Collections.Generic;
namespace HL7V2.DataType {
	/// <summary>
	/// SAD - Street address.
	/// <para>Introduced in version 2.3. Only in XAD data type</para>
	/// </summary>
	public struct StreetAddress : IDataType {

    public StreetAddress(string value) {
      string[] s = value.Split(new string[] { "" }, System.StringSplitOptions.None);
      StreetOrMailingAddress = new TextString(s[0]);
      StreetName = new TextString(s[1]);
      DwellingNumber = s.Length > 2 ? new TextString(s[2]) : new TextString();
     }

    public string ToString(HL7Table.HL7Version version){
      switch(version) {
        case HL7Table.HL7Version.V20:
        case HL7Table.HL7Version.V20D:
        case HL7Table.HL7Version.V21:
        case HL7Table.HL7Version.V22:
          return StreetOrMailingAddress.ToString(version);
        default:
          List<string> lst = new List<string> {
            StreetOrMailingAddress.ToString(version),
            StreetName.ToString(version),
            DwellingNumber.ToString(version)
          };
          return string.Join("&", lst);
      }
    }

    #region Variables
    /// <summary>
    /// The street or mailing address of a person or institution. When referencing an institution, this first component is used to specify the institution name.
    /// When used in connection with a person, this component specifies the first line of the address.
    /// </summary>
    public TextString StreetOrMailingAddress;
    /// <summary>
    /// The name of the street.
    /// </summary>
    public TextString StreetName;
    /// <summary>
    /// The dwelling number.
    /// </summary>
    public TextString DwellingNumber;
    #endregion
  }
}
