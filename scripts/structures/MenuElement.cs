using System;
using System.Collections.Generic;

namespace Openesport.Structures
{
    public enum MenuElementType
    {
        // Conteneurs
        VBoxContainer,
        HBoxContainer,
        GridContainer,
        TabContainer,
        ScrollContainer,
        
        // Éléments UI
        Button,
        Label,
        TextInput,
        Select,
        CheckBox,
        Separator
    }

    public struct MenuElement
    {
        // Propriétés communes
        public int Id { get; set; }
        public string Name { get; set; }
        public MenuElementType Type { get; set; }
        public int ParentId { get; set; }
        public int Poids { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public string UiPath { get; set; }
        public string IconPath { get; set; }
        
        // Propriétés de style
        public Dictionary<string, object> Style { get; set; }
        
        // Propriétés spécifiques
        public Dictionary<string, object> Properties { get; set; }

        // Constructeur par défaut
        public MenuElement(int id, string name, MenuElementType type, int parentId = 0, int poids = 0, string uiPath = "", string iconPath = "")
        {
            Id = id;
            Name = name;
            Type = type;
            ParentId = parentId;
            Poids = poids;
            Visible = true;
            Enabled = true;
            UiPath = uiPath;
            IconPath = iconPath;
            Style = new Dictionary<string, object>();
            Properties = new Dictionary<string, object>();
        }
    }
} 