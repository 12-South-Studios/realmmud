using System;

namespace Realm.Build.Tool
{
    public class GenericConstantWriter : IConstantWriter 
    {
        private readonly IConstantWriter _writer;

        public GenericConstantWriter(String connectionString, String value, bool stringArrays)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value", "Parameter is null or empty");

            if (value.EndsWith(".as"))
            {
                //_writer = new ASConstantWriter(aFilename);
            }
            else if (value.EndsWith(".java"))
            {
                //_writer = new JavaConstantWriter(aFilename);
            }
            else if (value.EndsWith(".cs"))
            {
                _writer = new CSharpConstantWriter(connectionString, value, stringArrays);
            }
            else if (value.EndsWith(".py"))
            {
                //_writer = new PythonConstantWriter(aFilename);
            }
            else if (value.EndsWith(".lua"))
            {
                //_writer = new LUAConstantWriter(aFilename);
            }
            else if (value.EndsWith(".js"))
            {
                //_writer = new JavaScriptConstantWriter(aFilename);
            }
            else if (value.EndsWith(".cpp") || value.EndsWith(".hpp"))
            {
                //_writer = new CPPConstantWriter(aFilename);
            }
            else if (value.EndsWith(".h"))
            {
                //_writer = new CConstantWriter(aFilename);
            }
            else {
                _writer = null;
            }
        }

        public void Close()
        {
            _writer.Close();
        }

        public void WriteHeader(String value) 
        {
            _writer.WriteHeader(value);
        }

        public void WriteFooter(String value)
        {
            _writer.WriteFooter(value);
        }

        public void WriteGroupHeader(ConstantGroup value)
        {
            _writer.WriteGroupHeader(value);
        }

        public void WriteEnums(ConstantGroup value) 
        {
            _writer.WriteEnums(value);
        }

        public void WriteConstants(ConstantGroup value)
        {
            _writer.WriteConstants(value);
        }

        public void WriteGroupFooter(ConstantGroup value)
        {
            _writer.WriteGroupFooter(value);
        }
    }
}