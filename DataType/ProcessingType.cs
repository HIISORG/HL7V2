using System;
namespace HL7V2.DataType {
  public struct ProcessingType {
    public ProcessingType(string value) {
      if (string.IsNullOrWhiteSpace(value)) {
        ProcessingID = HL7Table.ProcessingID.None;
        ProcessingMode = HL7Table.ProcessingMode.None;
      } else {
        string[] s = value.Split('^');
        try {
          ProcessingID = (HL7Table.ProcessingID)Enum.Parse(typeof(HL7Table.ProcessingID), s[0], true);
        } catch {
          ProcessingID = HL7Table.ProcessingID.None;
        }
        if (s.Length > 1) {
          try {
            ProcessingMode = (HL7Table.ProcessingMode)Enum.Parse(typeof(HL7Table.ProcessingMode), s[1], true);
          } catch {
            ProcessingMode = HL7Table.ProcessingMode.None;
          }
        } else ProcessingMode = HL7Table.ProcessingMode.None;
      }
    }

    public override string ToString() {
      if (ProcessingMode == HL7Table.ProcessingMode.None) {
        return ProcessingID.Value();
      }
      return ProcessingID.Value() + "^" + ProcessingMode.Value();
    }

    public HL7Table.ProcessingID ProcessingID;
    public HL7Table.ProcessingMode ProcessingMode;
  }
}
