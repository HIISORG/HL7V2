namespace HL7V2 {
  public static class StringExtension {
    public static object NullIfEmpty(this string value) {
      if (string.IsNullOrWhiteSpace(value)) return null;
      return value;
    }

    public static string Value(this string value) {
      if (string.IsNullOrWhiteSpace(value)) return "";
      return value;
    }
  }
}