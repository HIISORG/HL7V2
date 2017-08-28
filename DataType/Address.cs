using System;
namespace HL7V2.DataType {
  /// <summary>
  /// Represent both AD and XAD type
  /// </summary>
  public struct Address {
    public Address(string text, string version) {
      Text = text;
      if (string.IsNullOrWhiteSpace(text)) {
        StreetAddress = new StreetAddress();
        OtherDesignation = string.Empty;
        City = string.Empty;
        StateProvince = string.Empty;
        ZipOrPostalCode = string.Empty;
        Country = string.Empty;
        AddressType = HL7Table.AddressType.BA;
      } else if (text.Contains("^")) {
				string[] x = text.Split('^');
				StreetAddress = new StreetAddress(x[1]);
				OtherDesignation = x.Length > 1 ? x[1] : string.Empty;
				City = x.Length > 2 ? x[2] : string.Empty;
				StateProvince = x.Length > 3 ? x[3] : string.Empty;
				ZipOrPostalCode = x.Length > 4 ? x[4] : string.Empty;
				Country = x.Length > 5 ? x[5] : string.Empty;
				if (x.Length < 7 || !Enum.TryParse(x[6], out AddressType)) AddressType = HL7Table.AddressType.None;
			} else {
				StreetAddress = new StreetAddress();
				OtherDesignation = string.Empty;
				City = string.Empty;
				StateProvince = string.Empty;
				ZipOrPostalCode = string.Empty;
				Country = string.Empty;
        AddressType = HL7Table.AddressType.BA;
      }
      OtherGeographicDesignation = string.Empty;
      CountryParishCode = string.Empty;
      CensusTract = string.Empty;
      AddressRepresentationCode = string.Empty;
      AddressValidityRange = string.Empty;
    }

    public string Value() {
      return string.Empty;
    }

    #region Variables
    public string Text;
    /// <summary>
    /// The street address.
    /// <para /> ST or SAD (in version 2.3 or above)
    /// </summary>
    public StreetAddress StreetAddress;
    /// <summary>
    /// Second line of address. In US usage, it qualifies address. Example: Suite 555 or Fourth Floor. When referencing an institution, this component specifies the street address.
    /// </summary>
    public string OtherDesignation;
    /// <summary>
    /// This may be the name of the city, or district or place depending upon the national convention for formatting addresses for postal usage.
    /// </summary>
    public string City;
    /// <summary>
    /// State or province should be represented by the official postal service codes for that country
    /// </summary>
    public string StateProvince;
    /// <summary>
    /// Zip or postal codes should be represtend by the official codes for that country.
    /// </summary>
    public string ZipOrPostalCode;
    /// <summary>
    /// ISO 3166 three characters (alphabetic) country code.
    /// </summary>
    public string Country;
    /// <summary>
    /// Address type is optional and defined by HL7 Table 0190.
    /// </summary>
    public HL7Table.AddressType AddressType;
    /// <summary>
    /// Other geographic designation includes country, bioregion, SMSA, etc.
    /// </summary>
    public string OtherGeographicDesignation;
    /// <summary>
    /// The country parish code (IS).
    /// </summary>
    public string CountryParishCode;
    /// <summary>
    /// Census tract (IS).
    /// </summary>
    public string CensusTract;
    /// <summary>
    /// The address representation code (ID).
    /// </summary>
    public string AddressRepresentationCode;
    /// <summary>
    /// The address validity range (DR).
    /// </summary>
    public string AddressValidityRange;
    #endregion
  }
}