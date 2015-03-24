using System;

namespace Realm.Build.Tool
{
    public interface IConstantWriter
    {
        void Close();
        void WriteHeader(String value);
        void WriteFooter(String value);

        void WriteGroupHeader(ConstantGroup value);
        void WriteEnums(ConstantGroup value);
        void WriteConstants(ConstantGroup value);
        void WriteGroupFooter(ConstantGroup value);
    }
}
