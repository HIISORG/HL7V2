using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace HL7V2.Segments {
  public class MSH : Segment {
    public MSH(string content) { this.content = content; Process(); }

    public new bool Process() {
      if (content.Length < 20) return false;
      EncodingCharacters = new DataType.EncodingCharacter(){
        FieldSeparator = content[3]
      };

      string[] s = content.Split(EncodingCharacters.FieldSeparator);

      SendingApplication = s.Length > 2 ? new DataType.HierachicDesignator(s[2]) : new DataType.HierachicDesignator();
      SendingFacility = s.Length > 3 ? new DataType.HierachicDesignator(s[3]) : new DataType.HierachicDesignator();
      ReceivingApplication = s.Length > 4 ? new DataType.HierachicDesignator(s[4]) : new DataType.HierachicDesignator();
      ReceivingFacility = s.Length > 5 ? new DataType.HierachicDesignator(s[5]) : new DataType.HierachicDesignator();
      DateTime = s.Length > 6 ? new DataType.TimeStamp(s[6]) : new DataType.TimeStamp();
      Security = s.Length > 7 ? s[7] : string.Empty;
      MessageType = s.Length > 8 ? new DataType.Composite(s[7]) : new DataType.Composite();
      MessageControlID = s.Length > 9 ? s[8] : string.Empty;
      ProcessingID = s.Length > 10 ? new DataType.ProcessingType(s[9]) : new DataType.ProcessingType();
      VersionID = s.Length > 11 ? new DataType.VersionIdentifier(s[11]) : new DataType.VersionIdentifier();
      SequenceNumber = s.Length > 12 ? s[12] : string.Empty;
      ContinuationPointer = s.Length > 13 ? s[13] : string.Empty;
      //AcceptAcknowledgmentType = s.Length > 14 ?  : Table.AcknowledgementCondition.None;
      //TODO: Complete the rest of fields
      return false;
    }

    public override string ToString() {
      List<string> lst = new List<string>() {
        "MSH",
        EncodingCharacters.ToString(),
        SendingApplication.ToString(),
        SendingFacility.ToString(),
        ReceivingApplication.ToString(),
        ReceivingFacility.ToString(),
        DateTime.ToString(),
        Security,
        MessageType.ToString(),
        MessageControlID,
        ProcessingID.ToString(),
        VersionID.ToString()
      };
      return string.Join(EncodingCharacters.FieldSeparator.ToString(), lst);
    }
    
    #region Variables
    /// <summary>
    /// MSH-2 Encoding Characters (ST) 00002.
    /// </summary>
    public DataType.EncodingCharacter EncodingCharacters { get; set; } = new DataType.EncodingCharacter("^~\\&");
    /// <summary>
    /// MSH-3 Sending application (HD) 00003.
    /// </summary>
    public DataType.HierachicDesignator SendingApplication { get; set; }
    /// <summary>
    /// MSH-4 Sending facility (HD) 00004.
    /// </summary>
    public DataType.HierachicDesignator SendingFacility { get; set; }
    /// <summary>
    /// MSH-5 Receving application (HD) 00005.
    /// </summary>
    public DataType.HierachicDesignator ReceivingApplication { get; set; }
    /// <summary>
    /// MSH-6 Receiving facility (HD) 00006.
    /// </summary>
    public DataType.HierachicDesignator ReceivingFacility { get; set; }
    /// <summary>
    /// MSH-7 Date/time of message (TS) 00007.
    /// </summary>
    public DataType.TimeStamp DateTime { get; set; }
    /// <summary>
    /// MSH-8 Security (ST) 00008.
    /// </summary>
    public string Security { get; set; } = string.Empty;
    /// <summary>
    /// MSH-9 Message type (CM) 00009.
    /// <para /> [message type (ID)]^[trigger event (ID)]^[message structure (ID)]
    /// </summary>
    public DataType.Composite MessageType { get; set; }
    /// <summary>
    /// MSH-10 Message control ID (ST) 00010.
    /// </summary>
    public string MessageControlID { get; set; } = string.Empty;
    /// <summary>
    /// MSH-11 Processing ID (PT) 00011.
    /// </summary>
    /// <value>The processing identifier.</value>
    public DataType.ProcessingType ProcessingID { get; set; }
    /// <summary>
    /// MSH-12 Version ID (VID) 00012.
    /// </summary>
    public DataType.VersionIdentifier VersionID { get; set; }
    /// <summary>
    /// MSH-13 Sequence number (NM) 00013.
    /// </summary>
    public string SequenceNumber { get; set; } = string.Empty;
    /// <summary>
    /// MSH-14 Continuation pointer (ST) 00014.
    /// </summary>
    public string ContinuationPointer { get; set; } = string.Empty;
		/// <summary>
		/// MSH-15 Accept acknowledgment type (ID) 00015.
		/// </summary>
		public HL7Table.AcknowledgementCondition AcceptAcknowledgmentType { get; set; } = HL7Table.AcknowledgementCondition.None;
		/// <summary>
		/// MSH-16 Application acknowledgment type (ID) 00016.
		/// </summary>
		public HL7Table.AcknowledgementCondition ApplicationAcknowledgmentType { get; set; } = HL7Table.AcknowledgementCondition.None;
    /// <summary>
    /// MSH-17 Country code (ID) 00017.
    /// </summary>
    public HL7Table.Country CountryCode { get; set; } = HL7Table.Country.None;
    /// <summary>
    /// MSH-18 Character set (ID) 00692.
    /// </summary>
    public string CharacterSet { get; set; } = "ASCII";
    /// <summary>
    /// MSH-19 Principal language of message (CE) 00693.
    /// </summary>
    public DataType.CodeElement PrincipalLanaguage { get; set; }
    /// <summary>
    /// MSH-20 Alternate character set handling scheme (ID) 01317.
    /// </summary>
    public string AlternateCharacterSetHandlingScheme { get; set; } = string.Empty;
    /// <summary>
    /// MSH-21 Conformance statement ID (ID) 01598.
    /// </summary>
    public string ConformanceStatementID { get; set; } = string.Empty;
    /// <summary>
    /// MSH-22 Sending responsible Organization (XON). Optional.
    /// </summary>
    public DataType.Organization SendingResponsibleOrganization { get; set; }
    /// <summary>
    /// MSH-23 Receving Responsible Organization (XON). Optional.
    /// </summary>
    public DataType.Organization RecevingResponsibleOrganization { get; set; }
    /// <summary>
    /// MSH-24 Sending network address (HD). Optional.
    /// </summary>
    public string SendingNetworkAddress { get; set; }
    /// <summary>
    /// MSH-25 Receiving Network Address (HD). Optioanl.
    /// </summary>
    public string ReceivingNetworkAddress { get; set; }
    #endregion
  }
}
