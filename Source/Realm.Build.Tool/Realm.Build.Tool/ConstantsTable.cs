namespace Realm.Build.Tool
{
    public class ConstantsTable
    {
        public string TableName { get; set; }
        public string ConstantName { get; set; }
        public string KeyName { get; set; }
        public string ValueName { get; set; }
        public string AdditionalWhere { get; set; }
        public string Prefix { get; set; }
        public string DescriptionField { get; set; }
        public string CommentField { get; set; }
        public string Comment { get; set; }
        public bool IsEnum { get; set; }
        public bool HasFlagsAttribute { get; set; }
        public bool SuppressCA1008 { get; set; }
    }
}
