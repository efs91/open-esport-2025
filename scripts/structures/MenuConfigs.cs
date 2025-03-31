using System.Collections.Generic;

namespace Openesport.Structures
{
    public class ButtonConfig
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string action { get; set; }
        public int parentId { get; set; }
        public string uiPath { get; set; }
        public int poids { get; set; }
    }

    public class SelectOption
    {
        public string value { get; set; }
        public string label { get; set; }
        public string iconPath { get; set; }
    }

    public class SelectConfig
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int parentId { get; set; }
        public string uiPath { get; set; }
        public int poids { get; set; }
        public string action { get; set; }
        public List<SelectOption> options { get; set; }
    }
} 