using System;

namespace Openesport.Structures
{
    public struct MenuEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconPath { get; set; }
        public string Action { get; set; }
        public int ParentId { get; set; }
        public string UiPath { get; set; }
        public int Poids { get; set; }
    }
} 