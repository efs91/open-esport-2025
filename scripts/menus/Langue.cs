using Godot;
using System;
using Openesport.Utils;

namespace Openesport.Menus
{
    public partial class Langue : Control
    {
        private Button _retourButton;

        public override void _Ready()
        {
            _retourButton = GetNode<Button>("CenterContainer/VBoxContainer/ButtonsContainer/RetourButton");
            _retourButton.Pressed += OnRetourPressed;
        }

        private void OnRetourPressed()
        {
            // Pour l'instant, on ne fait rien
        }

        public override void _ExitTree()
        {
            _retourButton.Pressed -= OnRetourPressed;
        }
    }
} 