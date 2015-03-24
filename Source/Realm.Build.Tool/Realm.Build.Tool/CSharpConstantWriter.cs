using System;
using System.Reflection;
using Realm.Library.Common;

namespace Realm.Build.Tool
{
    public class CSharpConstantWriter : BaseConstantWriter, IConstantWriter
    {
        private readonly bool _writeStringArrays;
        private static readonly char[] InvalidChars = new[] { ' ', ';', ',', '\r', '\t', '\n', '-', '_' };

        public CSharpConstantWriter(string connectionString, string value, bool stringArrays)
            : base(value)
        {
            _writeStringArrays = stringArrays;
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }

        public void WriteHeader(String value)
        {
            Stream.WriteLine("// This file is generated from various Reference tables.");
            Stream.WriteLine("// Do not modify, change the values in the DB and");
            Stream.WriteLine("// build the server project instead.");
            Stream.WriteLine("//{0}", Environment.NewLine);
            Stream.WriteLine("using System;");
            Stream.WriteLine("using System.CodeDom.Compiler;");
            Stream.WriteLine("using System.Diagnostics.CodeAnalysis;");
            Stream.WriteLine("using Realm.Library.Common;{0}", Environment.NewLine);
            Stream.WriteLine("namespace {0}", value);
            Stream.WriteLine("{");
            Stream.WriteLine("    [ExcludeFromCodeCoverage]");
            Stream.WriteLine("    [GeneratedCode(\"{0}\", \"{1}\")]", Assembly.GetExecutingAssembly().GetName().Name, 
                Assembly.GetExecutingAssembly().GetName().Version);
            Stream.WriteLine("    public static class Globals");
            Stream.WriteLine("    {");
        }

        public void WriteFooter(String value)
        {
            Stream.WriteLine("    } // Globals");
            Stream.WriteLine("} // " + value + "\n\r");
        }

        public void WriteGroupHeader(ConstantGroup value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Parameter is null");

            Stream.WriteLine("{0}        // Globals generated from {1}", Environment.NewLine, value.ConstantSource);
            if (!string.IsNullOrEmpty(value.Comment))
                Stream.WriteLine("        // {0}\n\r", value.Comment);
        }

        public void WriteGroupFooter(ConstantGroup value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Parameter is null");

        }

        public void WriteEnums(ConstantGroup value) 
        {
            if (value == null)
                throw new ArgumentNullException("value", "Parameter is null");

            var enumName = value.ConstantName;

            // Enum values can be combined into bit-fields
            if (value.HasFlagsAttribute)
                Stream.WriteLine("        [Flags]");

            // Code Analysis should not report the need for a None=0 Enum value
            if (value.SuppressCA1008)
                Stream.WriteLine("        [SuppressMessage(\"Microsoft.Design\", \"CA1008:EnumsShouldHaveZeroValue\")]");

            Stream.WriteLine("        public enum {0}", enumName.RemoveAll(InvalidChars));
            Stream.WriteLine("        {");

            var i = 0;
            foreach (var cv in value.Values)
            {
                if (!String.IsNullOrEmpty(cv.Description)) 
                    Stream.WriteLine("            // {0}", cv.Description);
                
                if (!String.IsNullOrEmpty(cv.EnumString))
                    Stream.WriteLine("            {0}", cv.EnumString);
                else
                    Stream.WriteLine("            [Enum(\"{0}\", {1})]", cv.Name, cv.Value);

                Stream.Write("            {0}", cv.Name.RemoveAll(InvalidChars));

                if (i != value.Values.Count - 1) 
                    Stream.Write(",{0}", Environment.NewLine);
                
                Stream.Write("{0}", Environment.NewLine);

                i++;
            }
            Stream.WriteLine("        };");

            if (_writeStringArrays)
            {
            }
        }

        public void WriteConstants(ConstantGroup value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Parameter is null");

            bool isConstant = value.ConstantName.Equals("Game Constants");
            var dal = new RealmDal(ConnectionString);

            foreach (var cv in value.Values)
            {
                var varName = value.Prefix.Trim() + "_" + cv.Name.RemoveAll(InvalidChars);
                if (cv.ValueType == null 
                    || cv.ValueType.Equals("int", StringComparison.OrdinalIgnoreCase) 
                    || cv.ValueType.Equals("integer", StringComparison.OrdinalIgnoreCase))
                {
                    Stream.WriteLine("        public static int {0} = {1};", varName, 
                                      isConstant ? dal.GetGameConstant(cv.Value, 0) : Convert.ToInt32(cv.Value));
                }
                else if (cv.ValueType.Equals("float", StringComparison.OrdinalIgnoreCase) 
                    || cv.ValueType.Equals("double", StringComparison.OrdinalIgnoreCase))
                {
                    Stream.WriteLine("        public static float {0} = {1}f;", varName,
                                      isConstant ? dal.GetGameConstant(cv.Value, 0.0f) : Convert.ToSingle(cv.Value));
                }
                else if (cv.ValueType.Equals("double", StringComparison.OrdinalIgnoreCase) 
                    || cv.ValueType.Equals("double", StringComparison.OrdinalIgnoreCase))
                {
                    Stream.WriteLine("        public static double {0} = {1}D;", varName,
                                      isConstant ? dal.GetGameConstant(cv.Value, 0.0f) : Convert.ToDouble(cv.Value));
                }
                else if (cv.ValueType.Equals("string", StringComparison.OrdinalIgnoreCase) 
                    || cv.ValueType.Equals("str", StringComparison.OrdinalIgnoreCase))
                {
                    string varValue = Convert.ToString(cv.Value).Replace("\"", "\\\"");
                    Stream.WriteLine("        public static string {0} = \"{1}\";", varName,
                                      isConstant ? dal.GetGameConstant(cv.Value, string.Empty) : varValue);
                }
            }
            /*if (_writeStringArrays)
            {
                Stream.Write("    public static string[] STRING_VALUES_" + group.Prefix.Trim() + " = {\n");
                var i = 0;
                foreach (var cv in group.Values)
                {
                    if (cv.ValueType.Equals("int", StringComparison.OrdinalIgnoreCase)
                        || cv.ValueType.Equals("integer", StringComparison.OrdinalIgnoreCase)) 
                    {
                        var varName = group.Prefix.Trim() + "_" + cv.Name.Trim();
                        Stream.Write("        \"" + varName + "\"");
                    }
                    if (i != group.Values.Count-1) 
                    {
                        Stream.Write(",");
                    }
                    Stream.Write("\n");
                    i++;
                }
                Stream.Write("    };\n");
                Stream.Write("    public static int[] STRING_MAP_" + group.Prefix.Trim() + " = {\n");
            
                i = 0;
                foreach (var cv in group.Values) 
                {
                    if (cv.ValueType.Equals("int", StringComparison.OrdinalIgnoreCase)
                        || cv.ValueType.Equals("integer", StringComparison.OrdinalIgnoreCase))
                    {
                        Stream.Write("        " + cv.Value + "");
                    }
                    if (i != group.Values.Count-1)
                    {
                        Stream.Write(",");
                    }
                    Stream.Write("\n");
                    i++;
                }
                Stream.Write("    };\n");
            }*/
        }
    }
}