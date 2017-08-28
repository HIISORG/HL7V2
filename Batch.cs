using System;
using System.Collections.Generic;
namespace HL7V2 {
  public class Batch {
    public Batch () {}
    public Batch(string content) {
      this.content = content;
    }

    /// <summary>
    /// Process batch file.
    /// </summary>
    /// <returns>Result status.</returns>
    public bool Process() {

      return false;
    }

    public override string ToString() {
      return string.Format("[Batch: EncodingCharacters={0}, SendingApplication={1}, SendingFacility={2}, ReceivingApplication={3}, ReceivingFacility={4}, CreationDateTime={5}, Security={6}, NameIDType={7}, Comment={8}, ControlID={9}, ReferenceID={10}]", EncodingCharacters, SendingApplication, SendingFacility, ReceivingApplication, ReceivingFacility, CreationDateTime, Security, NameIDType, Comment, ControlID, ReferenceID);
    }

    #region Variables
    private string content = string.Empty;
    /// <summary>
    /// BHS-2 Batch encoding characters (ST) 0082.
    /// </summary>
    public DataType.EncodingCharacter EncodingCharacters { get; set; }
    /// <summary>
    /// BHS-3 Batch sending application (ST) 0083.
    /// </summary>
    public string SendingApplication { get; set; }
    /// <summary>
    /// BHS-4 Batch sending facility (ST) 0084.
    /// </summary>
    public string SendingFacility { get; set; }
    /// <summary>
    /// BHS-5 Batch receiving application (ST) 0085.
    /// </summary>
    public string ReceivingApplication { get; set; }
    /// <summary>
    /// BHS-6 Batch receiving facility (ST) 0086
    /// </summary>
    public string ReceivingFacility { get; set; }
    /// <summary>
    /// BHS-7 Batch reation date/time (TS) 0087
    /// </summary>
    public string CreationDateTime { get; set; }
    /// <summary>
    /// BHS-8 Batch security (ST) 0088.
    /// <para /> In some applications of HL7 this field is used to implement security features. Its use is not yet further specified.
    /// </summary>
    public string Security { get; set; }
    /// <summary>
    /// BHS-9 Batch name/ID/type (ST) 0089.
    /// <para />This field can be used by the application processing the batch. It can have extra components is needed.
    /// </summary>
    public string NameIDType { get; set; }
    /// <summary>
    /// BHS-10 Batch comment (ST) 00090.
    /// 
    /// </summary>
    /// <value>The comment.</value>
    public string Comment { get; set; }
    public string ControlID { get; set; }
    public string ReferenceID { get; set; }
    public List<Message> Messages = new List<Message>();
    #endregion
  }
}
