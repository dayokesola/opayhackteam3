using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Threading;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;

namespace HackOpay.Core.Common
{

    public static class Util
    {
        public static string GetString(object k)
        {
            if (k == null) return "";
            return k.ToString();
        }
        public static byte[] ReadBytesOfFile(string fle, bool delete = false)
        {
            byte[] bytes = new byte[1];
            try
            {
                using (FileStream fsSource = new FileStream(fle, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n2 = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                        if (n2 == 0)
                        {
                            fsSource.Close();
                            fsSource.Dispose();
                            break;
                        }
                        numBytesRead += n2;
                        numBytesToRead -= n2;
                    }
                }
                if (delete)
                {
                    FileInfo fi = new FileInfo(fle);
                    fi.Delete();
                }
            }
            catch
            {
            }
            return bytes;
        }

        /// <summary>
        /// Shape a list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static object ShapeList<TSource>(this IList<TSource> obj, string fields)
        {
            List<string> lstOfFields = new List<string>();
            if (string.IsNullOrEmpty(fields))
            {
                return obj;
            }
            lstOfFields = fields.Split(',').ToList();
            List<string> lstOfFieldsToWorkWith = new List<string>(lstOfFields);

            List<System.Dynamic.ExpandoObject> lsobjectToReturn = new List<System.Dynamic.ExpandoObject>();
            if (!lstOfFieldsToWorkWith.Any())
            {
                return obj;
            }
            else
            {
                foreach (var kj in obj)
                {
                    System.Dynamic.ExpandoObject objectToReturn = new System.Dynamic.ExpandoObject();

                    foreach (var field in lstOfFieldsToWorkWith)
                    {
                        try
                        {
                            var fieldValue = kj.GetType()
                            .GetProperty(field.Trim(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            .GetValue(kj, null);
                            ((IDictionary<String, Object>)objectToReturn).Add(field.Trim(), fieldValue);
                        }
                        catch
                        {
                        }
                    }

                    lsobjectToReturn.Add(objectToReturn);
                }
            }
            return lsobjectToReturn;
        }

        public static object Shape<T>(T obj, string fields)
        {
            List<string> lstOfFields = new List<string>();
            if (string.IsNullOrEmpty(fields))
            {
                return obj;
            }
            lstOfFields = fields.Split(',').ToList();
            List<string> lstOfFieldsToWorkWith = new List<string>(lstOfFields);
            if (!lstOfFieldsToWorkWith.Any())
            {
                return obj;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in lstOfFieldsToWorkWith)
                {
                    try
                    {
                        var fieldValue = obj.GetType()
                        .GetProperty(field.Trim(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(obj, null);
                        ((IDictionary<String, Object>)objectToReturn).Add(field.Trim(), fieldValue);
                    }
                    catch
                    {
                        //Log.Error(ex);
                    }

                }
                return objectToReturn;
            }
        }

        

        public static string MaskAccount(string accountNumber)
        {
            if (accountNumber.Length > 10)
            {
                //accountNumber =  accountNumber.Substring(0,)
            }
            return accountNumber;
        }

        public static string GenerateRndNumber(int cnt)
        {
            string[] key2 = new string[]
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };
            Random rand = new Random();
            string txt = "";
            for (int i = 0; i < cnt; i++)
            {
                txt += key2[rand.Next(0, 9)];
            }
            return txt;
        }
        public static string HTMLEncode(string value)
        {
            return WebUtility.HtmlEncode(value);
        }

        public static decimal ToDecimal(object p)
        {
            decimal resp = 0;
            try
            {
                resp = Convert.ToDecimal(p.ToString());
            }
            catch { }
            return resp;
        }
        public static decimal ToDecimal(string p)
        {
            decimal resp = 0;
            try
            {
                resp = Convert.ToDecimal(p);
            }
            catch { }
            return resp;
        }

        public static DateTime CurrentDateTime()
        {
            return DateTime.UtcNow;
        }

        public static DateTime DefaultDateTime()
        {
            return new DateTime(1970, 1, 1);
        }

        public static DateTime ToDateTime(object v)
        {
            return Convert.ToDateTime(v);
        }
        public static DateTime ToDateTime(string v)
        {
            var a = DateTime.MinValue;
            var b = DateTime.TryParse(v, out a);
            return a;
        }
        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new string(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        public static string ToString(object v)
        {
            return Convert.ToString(v);
        }

        private static string HexStrFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
        public static string Hash512(string text)
        {
            string hash = "";
            using (SHA512 alg = new SHA512Managed())
            {
                byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = HexStrFromBytes(result).ToUpper();
            }
            return hash;
        }

        public static string Hash256(string text)
        {
            string hash = "";
            using (SHA256 alg = new SHA256Managed())
            {
                byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = HexStrFromBytes(result).ToUpper();
            }
            return hash;
        }

        public static string ToMoney(decimal amt)
        {
            return amt.ToString("#,##0.00");
        }

        public static string ToMoney(string amt)
        {
            return ToDecimal(amt).ToString("#,##0.00");
        }
        public static T DeserializeJSON<T>(string objectData)
        {
            return JsonConvert.DeserializeObject<T>(objectData);
        }

        public static DateTime CheckDate(string dob)
        {
            if (dob.Length != 8) throw new Exception("Invalid Date format");
            int d = ToInt32(dob.Substring(0, 2));
            int m = ToInt32(dob.Substring(2, 2));
            int y = ToInt32(dob.Substring(4, 4));
            return new DateTime(y, m, d);
        }

        public static T DeserializeXML<T>(string objectData)
        {
            objectData = objectData.Replace("\n", "");
            var serializer = new XmlSerializer(typeof(T));
            object result;
            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }
            return (T)result;

        }

        public static string MobileFrom234(string customerMobile)
        {
            customerMobile = CleanMobile(customerMobile);

            if (customerMobile.StartsWith("234"))
            {
                if (customerMobile.Length == 13)
                {
                    customerMobile = "0" + customerMobile.Substring(3, 10);
                }
            }
            return customerMobile;
        }

        public static string[] Explode(string txt, string delim = ",", int opt = 1)
        {
            string[] arr = null;
            txt = txt.Trim();
            if (txt == "") return arr;
            if (delim.Length != 1) return arr;
            char[] sep = delim.ToCharArray();
            try
            {
                if (opt == 1)
                    arr = txt.Split(sep, StringSplitOptions.None);
                else
                    arr = txt.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                //Log.Write("StringSplit: " + txt + " " + delim + " " + ex.Message);
            }
            return arr;
        }

        public static string GetDifferenceInData(object newObject, object oldObject, object id)
        {
            string resp = id.ToString() + " || ";
            PropertyInfo[] properties = newObject.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string oldpp = GetPropValue(oldObject, pi.Name);
                string newpp = GetPropValue(newObject, pi.Name);

                if (newpp != oldpp)
                {
                    resp += pi.Name + ": " + oldpp + " => " + newpp + "; " + " ~ ";
                }

            }
            return resp;
        }

        public static string GetPropValue(object src, string propName)
        {
            string resp = "";
            try
            {
                resp = src.GetType().GetProperty(propName).GetValue(src, null).ToString();
            }
            catch
            {
                resp = "";

            }
            return resp;
        }

        public static string MobileBase(string mobile)
        {
            return mobile.Substring(mobile.Length - 10, 10);
        }

        public static bool IsEmail(string emailAddress)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                 + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                 + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                 + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                 + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;
        }

        public static string JavaScriptSafeText(string txt)
        {
            return txt;
        }

        public static bool MatchPattern(string pattern, string text)
        {
            Regex reStrict = new Regex(pattern);
            bool isStrictMatch = reStrict.IsMatch(text);
            return isStrictMatch;
        }

        public static string ObjectToString(object obj)
        {
            string resp = "";
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string oldpp = GetPropValue(obj, pi.Name);
                resp += pi.Name + ": " + oldpp + Environment.NewLine;
            }
            return resp;
        }

        public static string SerializeJSON(object objectInstance)
        {
            return JsonConvert.SerializeObject(objectInstance);
        }

        public static string CleanMobile(string mobile)
        {
            return mobile.Replace("+", "");
        }

        public static string SerializeXML(object objectInstance, string _prefix = "", string _namespace = "", bool _header = false)
        {
            string txt = "";
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            if (!string.IsNullOrEmpty(_prefix))
            {
                emptyNamepsaces = new XmlSerializerNamespaces();
                emptyNamepsaces.Add(_prefix, _namespace);
            }
            var serializer = new XmlSerializer(objectInstance.GetType());
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = _header;
            settings.Encoding = new UTF8Encoding(false);
            settings.ConformanceLevel = ConformanceLevel.Document;
            var memoryStream = new MemoryStream();
            using (var writer = XmlWriter.Create(memoryStream, settings))
            {
                serializer.Serialize(writer, objectInstance, emptyNamepsaces);
                txt = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return txt;
        }

        public static string TimeStampCode(string prefix = "")
        {
            Thread.Sleep(1);
            string stamp = DateTime.Now.ToString("yyMMddHHmmssffffff");
            long num = long.Parse(stamp);
            var g = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            return prefix + DecimalToArbitrarySystem(num, 36) + g;
        }

        public static string TimeStampCode(DateTime dtm, string prefix = "")
        {
            Thread.Sleep(1);
            string stamp = dtm.ToString("yyMMddHHmmssffffff");
            long num = long.Parse(stamp);
            var g = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            return prefix + DecimalToArbitrarySystem(num, 36) + g;
        }

        public static double ToDouble(object v)
        {
            double resp = 0;
            try
            {
                resp = Convert.ToDouble(v.ToString());
            }
            catch { }
            return resp;
        }
        public static int ToInt32(object p)
        {
            int resp = 0;
            try
            {
                resp = Convert.ToInt32(p.ToString());
            }
            catch { }
            return resp;
        }

        public static long ToInt64(object p)
        {
            long resp = 0;
            try
            {
                resp = Convert.ToInt64(p.ToString());
            }
            catch { }
            return resp;
        }
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }


        /// <summary>
        /// Tries to convert the supplied string to +234... phone format
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static string StandardizeNigerianPhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return phoneNumber;
            }

            // remove non-numerals
            phoneNumber = new String(phoneNumber.ToCharArray().Where(x => char.IsNumber(x)).ToArray());

            if (phoneNumber.Length < 10)
            {
                return phoneNumber;
            }

            string phoneNumberPrefix = "234";
            return $"{phoneNumberPrefix}{phoneNumber.Substring(phoneNumber.Length - 10)}";
        }
    }

}