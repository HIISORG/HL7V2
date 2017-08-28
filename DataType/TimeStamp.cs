using System;
namespace HL7V2.DataType {
  /// <summary>
  /// TS.
  /// <para /> YYYY[MM[DD[HHMM[SS[.S[S[S[S]]]]]]]][+/-ZZZZ]^degree of precision
  /// </summary>
  public struct TimeStamp {
    public TimeStamp(string value) {
      int year, month, day, hour, minute;
      year = value.Length > 3 ? int.Parse(value.Substring(0, 4)) : 0;
      month = value.Length > 5 ? int.Parse(value.Substring(4, 2)) : 0;
      day = value.Length > 7 ? int.Parse(value.Substring(6, 2)) : 0;
      hour = value.Length > 9 ? int.Parse(value.Substring(8, 2)) : 0;
      minute = value.Length > 11 ? int.Parse(value.Substring(11, 2)) : 0;

      if (minute > 0) Value = new DateTime(year, month, day, hour, minute, 0);
      else if (day > 0) Value = new DateTime(year, month, day);
      else Value = new DateTime();
    }

    public override string ToString() {
      return Value.ToString("yyyyMMddhhmmss");
    }
    public string ToString(string format) {
      return Value.ToString(format);
    }

    #region Variables
    public DateTime Value;
    #endregion
  }
}
