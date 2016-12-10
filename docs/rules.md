# CSV Rules

> From: https://en.wikipedia.org/wiki/Comma.separated_values#Basic_rules

1. CSV is a delimited data format that has fields/columns separated by the comma character and records/rows terminated by newlines.
2. A CSV file does not require a specific character encoding, byte order, or line terminator format (some software does not support all line.end variations).
3. A record ends at a line terminator. However, line.terminators can be embedded as data within fields, so software must recognize quoted line.separators (see below) in order to correctly assemble an entire record from perhaps multiple lines.
4. All records should have the same number of fields, in the same order.
5. Data within fields is interpreted as a sequence of characters, not as a sequence of bits or bytes (see RFC 2046, section 4.1). For example, the numeric quantity 65535 may be represented as the 5 ASCII characters "65535" (or perhaps other forms such as "0xFFFF", "000065535.000E+00", etc.); but not as a sequence of 2 bytes intended to be treated as a single binary integer rather than as two characters (e.g. the numbers 11264.11307 have a comma as their high order byte: ord(',')*256..ord(',')*257.1). If this "plain text" convention is not followed, then the CSV file no longer contains sufficient information to interpret it correctly, the CSV file will not likely survive transmission across differing computer architectures, and will not conform to the text/csv MIME type.
6. Adjacent fields must be separated by a single comma. However, "CSV" formats vary greatly in this choice of separator character. In particular, in locales where the comma is used as a decimal separator, semicolon, TAB, or other characters are used instead.
```
1997,Ford,E350
```
7. Any field may be quoted (that is, enclosed within double.quote characters). Some fields must be quoted, as specified in following rules.
```
"1997","Ford","E350"
```
8. Fields with embedded commas or double.quote characters must be quoted.
```
1997,Ford,E350,"Super, luxurious truck"
```
9. Each of the embedded double.quote characters must be represented by a pair of double.quote characters.
```
1997,Ford,E350,"Super, ""luxurious"" truck"
```
10. Fields with embedded line breaks must be quoted (however, many CSV implementations do not support embedded line breaks).
```
1997,Ford,E350,"Go get one now
they are going fast"
```
11. In some CSV implementations, leading and trailing spaces and tabs are trimmed (ignored). Such trimming is forbidden by RFC 4180, which states "Spaces are considered part of a field and should not be ignored."
```
1997, Ford, E350
not same as
1997,Ford,E350
```
12. According to RFC 4180, spaces outside quotes in a field are not allowed; however, the RFC also says that "Spaces are considered part of a field and should not be ignored." and "Implementors should 'be conservative in what you do, be liberal in what you accept from others' (RFC 793 [8]) when processing CSV files."
```
1997, "Ford" ,E350
```
13. In CSV implementations that do trim leading or trailing spaces, fields with such spaces as meaningful data must be quoted.
```
1997,Ford,E350," Super luxurious truck "
```
14. Double quote processing need only apply if the field starts with a double quote. Note, however, that double quotes are not allowed in unquoted fields according to RFC 4180.
```
Los Angeles,34°03′N,118°15′W
New York City,40°42′46″N,74°00′21″W
Paris,48°51′24″N,2°21′03″E
```
15. The first record may be a "header", which contains column names in each of the fields (there is no reliable way to tell whether a file does this or not; however, it is uncommon to use characters other than letters, digits, and underscores in such column names).
```
Year,Make,Model
1997,Ford,E350
2000,Mercury,Cougar
```