using System;
namespace HL7V2.DataType {
  /// <summary>
  /// XON - Extended composite name and identification number for organizations
  /// </summary>
  public struct Organization {

    /// <summary>
    /// XON.1 Organization name (ST). Optional.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// XON.2 Organization name type code (CWE). HL7 Table 0204. Optioanl.
    /// </summary>
    public HL7Table.OrganizationalNameType NameTypeCode { get; set; }
    /// <summary>
    /// XON.3 Id Number (ST). W.
    /// </summary>
    public string IDNumber { get; set; }
    /// <summary>
    /// XON.4 Identifier Check Digit (NM). Optional.
    /// </summary>
    public string CheckDigit { get; set; }
    /// <summary>
    /// XON.5 Check Digit Scheme (ID) HL7 Table 0061. Optional.
    /// </summary>
    public HL7Table.CheckDigitScheme CheckDigitScheme { get; set; }
    /// <summary>
    /// XON.6 Assigning Authority (HD) HL7 Table 0363. Optional.
    /// </summary>
    public string AssigningAuthority { get; set; }
    /// <summary>
    /// XON.7 Identifier Type Code (ID) HL7 Table 0203. Optioanl.
    /// </summary>
    public HL7Table.IdentifierType IdentifierTypeCode { get; set; }
    /// <summary>
    /// XON.8 Assigning Facility (HD). Optional.
    /// </summary>
    public string AssigningFacility { get; set; }
    /// <summary>
    /// XON.9 Name Representation Code (ID). Optional.
    /// </summary>
    public HL7Table.NameAddressRepresentation NameRepresentationCode { get; set; }
    /// <summary>
    /// XON.10 Organization Identifier (ST). Optional.
    /// </summary>
    public string OrganizationIdentifier { get; set; }
  }
}
