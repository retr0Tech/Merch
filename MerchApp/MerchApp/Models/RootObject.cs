using System;
namespace MerchApp.Models
{
    public class RootObject
    {
        public string Value { get; set; }
        public int? OptionID { get; set; }
        public string FieldName { get; set; }
        public int FieldID { get; set; }
        public int Type { get; set; }
        public int UsageType { get; set; }
        public int AccessType { get; set; }
        public bool Mandatory { get; set; }
        public int OrderByNumber { get; set; }
        public bool ShowInGrid { get; set; }
        public object SelectionComboOptions { get; set; }
    }
}
