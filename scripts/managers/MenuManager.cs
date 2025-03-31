using Godot;
using System;
using System.Collections.Generic;
using Openesport.Structures;
using System.Linq;
using Openesport.Utils;
using Openesport.Modules;
using Openesport.Managers;

public partial class MenuManager : Control
{
    private GameManager _gameManager;
    private Node _currentMenu;
    private LogManager _logManager;
    private Dictionary<int, MenuElement> _menuElements = new Dictionary<int, MenuElement>();
    private Dictionary<string, Module> _actionHandlers = new Dictionary<string, Module>();
    private const int RETURN_BUTTON_WEIGHT = -1; // Poids spécial pour le bouton retour

    public override void _Ready()
    {
        _logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
        //_logManager.Info("[MenuManager] _Ready appelé");

        _gameManager = GetNode<GameManager>(GlobalPaths.Managers.GAME_MANAGER);
        //_logManager.Info("[MenuManager] GameManager récupéré");

        // S'abonner au signal de changement d'état
        _gameManager.GameStateChanged += OnGameStateChanged;
        //_logManager.Info("[MenuManager] Abonnement au signal GameStateChanged");

        //_logManager.Info($"[MenuManager] État initial : Visible={Visible}, ProcessMode={ProcessMode}");
    }

    private void OnGameStateChanged(int newState)
    {
        var state = (GameManager.GameState)newState;
        //_logManager.Info($"[MenuManager] État du jeu changé vers : {state}");

        switch (state)
        {
            case GameManager.GameState.MainMenu:
            case GameManager.GameState.Pause:
                //_logManager.Info("[MenuManager] Transition vers l'affichage du menu");
                ShowMainMenu();
                break;
            case GameManager.GameState.Gameplay:
                //_logManager.Info("[MenuManager] Transition vers le masquage du menu");
                HideMainMenu();
                break;
        }
    }

    private void ShowMainMenu()
    {
        //_logManager.Info($"[MenuManager] Tentative d'affichage du menu - État actuel : Visible={Visible}");
        Show();
        DisplaySubMenu(0); // Afficher le menu racine
        //_logManager.Info($"[MenuManager] Menu affiché - Nouvel état : Visible={Visible}");

        // Vérifier si le menu est bien visible
        if (!Visible)
        {
            _logManager.Warning("[MenuManager] Le menu n'est pas visible après Show()");
        }
    }

    private void HideMainMenu()
    {
        //_logManager.Info($"[MenuManager] Tentative de masquage du menu - État actuel : Visible={Visible}");
        Hide();
        //_logManager.Info($"[MenuManager] Menu masqué - Nouvel état : Visible={Visible}");
    }

    public void AddElement(MenuElement element)
    {
        //_logManager.Info($"[MenuManager] Tentative d'ajout d'un élément : {element.Name} (ID: {element.Id})");

        if (_menuElements.ContainsKey(element.Id))
        {
            _logManager.Warning($"[MenuManager] Un élément avec l'ID {element.Id} existe déjà");
            return;
        }

        _menuElements[element.Id] = element;
        //_logManager.Info($"[MenuManager] Élément ajouté avec succès : {element.Name} (ID: {element.Id})");
        //_logManager.Info($"[MenuManager] Poids : {element.Poids}");
        //_logManager.Info($"[MenuManager] Nombre total d'éléments : {_menuElements.Count}");

        // Créer et ajouter l'élément visuel dans le menu
        var container = GetNode<VBoxContainer>("MenuCenterContainer/MenuVBoxContainer/ButtonsContainer");
        if (container != null)
        {
            Node uiElement = CreateUIElement(element);
            if (uiElement != null)
            {
                container.AddChild(uiElement);
                //_logManager.Info($"[MenuManager] Élément créé et ajouté pour l'élément : {element.Name}");
            }
        }
        else
        {
            _logManager.Error("[MenuManager] Container non trouvé");
        }
    }

    public void RemoveElement(int id)
    {
        //_logManager.Info($"[MenuManager] Tentative de suppression de l'élément ID: {id}");

        if (!_menuElements.ContainsKey(id))
        {
            _logManager.Warning($"[MenuManager] Aucun élément trouvé avec l'ID {id}");
            return;
        }

        var elementName = _menuElements[id].Name;
        _menuElements.Remove(id);
        //_logManager.Info($"[MenuManager] Élément supprimé avec succès : {elementName} (ID: {id})");
        //_logManager.Info($"[MenuManager] Nombre total d'éléments : {_menuElements.Count}");
    }

    public void ClearElements()
    {
        //_logManager.Info($"[MenuManager] Tentative de suppression de tous les éléments (actuellement {_menuElements.Count})");
        _menuElements.Clear();
        //_logManager.Info("[MenuManager] Tous les éléments ont été supprimés");
    }

    public void UpdateElement(MenuElement element)
    {
        //_logManager.Info($"[MenuManager] Tentative de mise à jour de l'élément : {element.Name} (ID: {element.Id})");

        if (!_menuElements.ContainsKey(element.Id))
        {
            _logManager.Warning($"[MenuManager] Aucun élément trouvé avec l'ID {element.Id} pour la mise à jour");
            return;
        }

        var oldName = _menuElements[element.Id].Name;
        _menuElements[element.Id] = element;
        //_logManager.Info($"[MenuManager] Élément mise à jour avec succès : {oldName} -> {element.Name} (ID: {element.Id})");
    }

    public MenuElement? GetElement(int id)
    {
        //_logManager.Info($"[MenuManager] Tentative de récupération de l'élément ID: {id}");

        if (_menuElements.ContainsKey(id))
        {
            //_logManager.Info($"[MenuManager] Élément trouvé : {_menuElements[id].Name} (ID: {id})");
            return _menuElements[id];
        }

        _logManager.Warning($"[MenuManager] Aucun élément trouvé avec l'ID {id}");
        return null;
    }

    public void RegisterActionHandler(string action, Module module)
    {
        //_logManager.Info($"[MenuManager] Enregistrement du module {module.ModuleName} pour l'action {action}");
        _actionHandlers[action] = module;
    }

    public void ExecuteAction(string action)
    {
        //_logManager.Info($"[MenuManager] Tentative d'exécution de l'action : {action}");

        if (string.IsNullOrEmpty(action))
        {
            _logManager.Warning("[MenuManager] Action vide");
            return;
        }

        try
        {
            if (action == "GetTree().Quit()")
            {
                //_logManager.Info("[MenuManager] Exécution de l'action de fermeture");
                GetTree().Quit();
            }
            else
            {
                //_logManager.Info($"[MenuManager] Action handlers disponibles : {string.Join(", ", _actionHandlers.Keys)}");
                if (_actionHandlers.TryGetValue(action, out var module))
                {
                    //_logManager.Info($"[MenuManager] Exécution de l'action {action} par le module {module.ModuleName}");
                    module.ExecuteAction(action);
                }
                else
                {
                    _logManager.Warning($"[MenuManager] Aucun module trouvé pour l'action : {action}");
                }
            }
        }
        catch (Exception ex)
        {
            _logManager.Error($"[MenuManager] Erreur lors de l'exécution de l'action {action}: {ex.Message}");
        }
    }

    public void SaveMenuState()
    {
        //_logManager.Info("[MenuManager] Tentative de sauvegarde de l'état du menu");
        // TODO: Implémenter la sauvegarde de l'état
        //_logManager.Info("[MenuManager] État du menu sauvegardé");
    }

    public void RestoreMenuState()
    {
        //_logManager.Info("[MenuManager] Tentative de restauration de l'état du menu");
        // TODO: Implémenter la restauration de l'état
        //_logManager.Info("[MenuManager] État du menu restauré");
    }

    public void ResetMenu()
    {
        //_logManager.Info("[MenuManager] Tentative de réinitialisation du menu");
        ClearElements();
        //_logManager.Info("[MenuManager] Menu réinitialisé");
    }

    public override void _ExitTree()
    {
        //_logManager.Info("[MenuManager] _ExitTree appelé");
        // Se désabonner du signal quand le nœud est supprimé
        if (_gameManager != null)
        {
            _gameManager.GameStateChanged -= OnGameStateChanged;
            //_logManager.Info("[MenuManager] Désabonnement du signal GameStateChanged");
        }
    }

    private bool HasChildren(int parentId)
    {
        return _menuElements.Values.Any(element => element.ParentId == parentId);
    }

    private void LoadUI(string uiPath)
    {
        //_logManager.Info($"[MenuManager] Chargement de l'UI : {uiPath}");
        // TODO: Implémenter le chargement de l'UI
        // Pour l'instant, on cache juste le menu
        Hide();
    }

    private void OnElementPressed(MenuElement element)
    {
        //_logManager.Info($"[MenuManager] Élément pressé : {element.Name} (ID: {element.Id})");

        // 1. Si une action existe, l'exécuter
        if (element.Properties.TryGetValue("action", out var actionObj) && actionObj is string action)
        {
            //_logManager.Info($"[MenuManager] Exécution de l'action : {action}");
            ExecuteAction(action);
        }
        // 2. Si une UI existe, la charger
        if (!string.IsNullOrEmpty(element.UiPath))
        {
            //_logManager.Info($"[MenuManager] Chargement de l'UI : {element.UiPath}");
            LoadUI(element.UiPath);
        }
        // 3. Sinon, si des éléments ont cet élément comme parent, afficher le sous-menu
        else if (HasChildren(element.Id))
        {
            //_logManager.Info($"[MenuManager] Affichage du sous-menu pour : {element.Name}");
            DisplaySubMenu(element.Id);
        }
    }

    private void DisplaySubMenu(int parentId)
    {
        //_logManager.Info($"[MenuManager] Affichage du sous-menu (ParentId: {parentId})");

        // Nettoyer le conteneur
        var container = GetNode<VBoxContainer>("MenuCenterContainer/MenuVBoxContainer/ButtonsContainer");
        foreach (var child in container.GetChildren())
        {
            child.QueueFree();
        }

        // Récupérer et trier les éléments par poids
        var elements = _menuElements.Values
            .Where(element => element.ParentId == parentId)
            .OrderByDescending(element => element.Poids)
            .ToList();

        // Afficher tous les éléments du niveau
        foreach (var element in elements)
        {
            Node uiElement = CreateUIElement(element);
            if (uiElement != null)
            {
                container.AddChild(uiElement);
            }
        }

        // Si on n'est pas au niveau racine, ajouter le bouton retour en dernier
        if (parentId != 0)
        {
            var backButton = CreateBackButton();
            backButton.Pressed += () => DisplaySubMenu(_menuElements[parentId].ParentId);
            container.AddChild(backButton);
        }
    }

    private Node CreateUIElement(MenuElement element)
    {
        switch (element.Type)
        {
            case MenuElementType.Button:
                return CreateStyledButton(element);
            case MenuElementType.Label:
                return CreateStyledLabel(element);
            case MenuElementType.VBoxContainer:
                return CreateStyledVBoxContainer(element);
            case MenuElementType.HBoxContainer:
                return CreateStyledHBoxContainer(element);
            case MenuElementType.Select:
                return CreateStyledSelect(element);
            default:
                _logManager.Warning($"[MenuManager] Type d'élément non supporté : {element.Type}");
                return null;
        }
    }

    /// <summary>
    /// Crée un bouton stylisé.
    /// - Si une icône est fournie (IconPath non vide), le bouton sera carré et affichera uniquement l'icône en remplissant tout l'espace.
    /// - Sinon, le bouton affichera le texte de l'élément.
    /// </summary>
    private Button CreateStyledButton(MenuElement element)
    {
        Button button = new Button();
        // Taille minimale du bouton pour afficher texte et icône
        button.CustomMinimumSize = new Vector2(250, 50);
        // Utiliser la traduction pour le texte
        button.Text = LocalizationManager.GetTranslation(element.Name);

        // Si une icône est fournie, on la charge ; sinon, on utilise l'icône par défaut
        string iconPath = !string.IsNullOrEmpty(element.IconPath) ? element.IconPath : "res://assets/textures/Menu/boutons/default_icon.png";
        var icon = GD.Load<Texture2D>(iconPath);
        if (icon != null)
        {
            button.Icon = icon;
            button.ExpandIcon = false;

            // Padding autour de l'icône
            button.AddThemeConstantOverride("icon_margin_left", 8);
            button.AddThemeConstantOverride("icon_margin_top", 4);
            button.AddThemeConstantOverride("icon_margin_right", 12);
            button.AddThemeConstantOverride("icon_margin_bottom", 4);

            // Limiter la taille de l'icône à 1/15 de la largeur visible
            float maxIconWidth = GetViewport().GetVisibleRect().Size.X / 15f;
            float maxIconHeight = 48;

            button.AddThemeConstantOverride("icon_max_width", (int)maxIconWidth);
            button.AddThemeConstantOverride("icon_max_height", (int)maxIconHeight);
        }
        else
        {
            _logManager.Warning($"[MenuManager] Icône non trouvée pour {element.Name} : {iconPath}");
        }

        // Style pour l'état normal
        var normalStyle = new StyleBoxFlat();
        normalStyle.BgColor = new Color(0.15f, 0.15f, 0.15f);
        normalStyle.BorderColor = new Color(0.8f, 0.8f, 0.8f);
        normalStyle.BorderWidthLeft = 2;
        normalStyle.BorderWidthTop = 2;
        normalStyle.BorderWidthRight = 2;
        normalStyle.BorderWidthBottom = 2;
        normalStyle.CornerRadiusTopLeft = 8;
        normalStyle.CornerRadiusTopRight = 8;
        normalStyle.CornerRadiusBottomLeft = 8;
        normalStyle.CornerRadiusBottomRight = 8;
        button.AddThemeStyleboxOverride("normal", normalStyle);

        // Style pour l'état au survol
        var hoverStyle = new StyleBoxFlat();
        hoverStyle.BgColor = new Color(0.25f, 0.25f, 0.25f);
        hoverStyle.BorderColor = new Color(1, 1, 1);
        hoverStyle.BorderWidthLeft = 2;
        hoverStyle.BorderWidthTop = 2;
        hoverStyle.BorderWidthRight = 2;
        hoverStyle.BorderWidthBottom = 2;
        hoverStyle.CornerRadiusTopLeft = 8;
        hoverStyle.CornerRadiusTopRight = 8;
        hoverStyle.CornerRadiusBottomLeft = 8;
        hoverStyle.CornerRadiusBottomRight = 8;
        button.AddThemeStyleboxOverride("hover", hoverStyle);

        // Style pour l'état pressé
        var pressedStyle = new StyleBoxFlat();
        pressedStyle.BgColor = new Color(0.1f, 0.1f, 0.1f);
        pressedStyle.BorderColor = new Color(0.7f, 0.7f, 0.7f);
        pressedStyle.BorderWidthLeft = 2;
        pressedStyle.BorderWidthTop = 2;
        pressedStyle.BorderWidthRight = 2;
        pressedStyle.BorderWidthBottom = 2;
        pressedStyle.CornerRadiusTopLeft = 8;
        pressedStyle.CornerRadiusTopRight = 8;
        pressedStyle.CornerRadiusBottomLeft = 8;
        pressedStyle.CornerRadiusBottomRight = 8;
        button.AddThemeStyleboxOverride("pressed", pressedStyle);

        button.Pressed += () => OnElementPressed(element);

        return button;
    }

    private Label CreateStyledLabel(MenuElement element)
    {
        Label label = new Label();
        label.Text = element.Name;
        ApplyCommonStyles(label, element);
        return label;
    }

    private VBoxContainer CreateStyledVBoxContainer(MenuElement element)
    {
        VBoxContainer container = new VBoxContainer();
        ApplyCommonStyles(container, element);
        return container;
    }

    private HBoxContainer CreateStyledHBoxContainer(MenuElement element)
    {
        HBoxContainer container = new HBoxContainer();
        ApplyCommonStyles(container, element);
        return container;
    }

    private Button CreateBackButton()
    {
        Button button = new Button();
        button.CustomMinimumSize = new Vector2(250, 50);
        button.Text = LocalizationManager.GetTranslation("MENU_BACK");
        ApplyCommonStyles(button, new MenuElement(-1, "MENU_BACK", MenuElementType.Button));
        return button;
    }

    private void ApplyCommonStyles(Control control, MenuElement element)
    {
        // Style pour l'état normal
        var normalStyle = new StyleBoxFlat();
        normalStyle.BgColor = new Color(0.15f, 0.15f, 0.15f);
        normalStyle.BorderColor = new Color(0.8f, 0.8f, 0.8f);
        normalStyle.BorderWidthLeft = 2;
        normalStyle.BorderWidthTop = 2;
        normalStyle.BorderWidthRight = 2;
        normalStyle.BorderWidthBottom = 2;
        normalStyle.CornerRadiusTopLeft = 8;
        normalStyle.CornerRadiusTopRight = 8;
        normalStyle.CornerRadiusBottomLeft = 8;
        normalStyle.CornerRadiusBottomRight = 8;
        control.AddThemeStyleboxOverride("normal", normalStyle);

        // Style pour l'état au survol
        var hoverStyle = new StyleBoxFlat();
        hoverStyle.BgColor = new Color(0.25f, 0.25f, 0.25f);
        hoverStyle.BorderColor = new Color(1, 1, 1);
        hoverStyle.BorderWidthLeft = 2;
        hoverStyle.BorderWidthTop = 2;
        hoverStyle.BorderWidthRight = 2;
        hoverStyle.BorderWidthBottom = 2;
        hoverStyle.CornerRadiusTopLeft = 8;
        hoverStyle.CornerRadiusTopRight = 8;
        hoverStyle.CornerRadiusBottomLeft = 8;
        hoverStyle.CornerRadiusBottomRight = 8;
        control.AddThemeStyleboxOverride("hover", hoverStyle);

        // Style pour l'état pressé
        var pressedStyle = new StyleBoxFlat();
        pressedStyle.BgColor = new Color(0.1f, 0.1f, 0.1f);
        pressedStyle.BorderColor = new Color(0.7f, 0.7f, 0.7f);
        pressedStyle.BorderWidthLeft = 2;
        pressedStyle.BorderWidthTop = 2;
        pressedStyle.BorderWidthRight = 2;
        pressedStyle.BorderWidthBottom = 2;
        pressedStyle.CornerRadiusTopLeft = 8;
        pressedStyle.CornerRadiusTopRight = 8;
        pressedStyle.CornerRadiusBottomLeft = 8;
        pressedStyle.CornerRadiusBottomRight = 8;
        control.AddThemeStyleboxOverride("pressed", pressedStyle);
    }

    private OptionButton CreateStyledSelect(MenuElement element)
    {
        OptionButton select = new OptionButton();
        select.CustomMinimumSize = new Vector2(250, 50);
        select.Text = element.Name;

        // Style pour l'état normal
        var normalStyle = new StyleBoxFlat();
        normalStyle.BgColor = new Color(0.15f, 0.15f, 0.15f);
        normalStyle.BorderColor = new Color(0.8f, 0.8f, 0.8f);
        normalStyle.BorderWidthLeft = 2;
        normalStyle.BorderWidthTop = 2;
        normalStyle.BorderWidthRight = 2;
        normalStyle.BorderWidthBottom = 2;
        normalStyle.CornerRadiusTopLeft = 8;
        normalStyle.CornerRadiusTopRight = 8;
        normalStyle.CornerRadiusBottomLeft = 8;
        normalStyle.CornerRadiusBottomRight = 8;
        select.AddThemeStyleboxOverride("normal", normalStyle);

        // Style pour l'état au survol
        var hoverStyle = new StyleBoxFlat();
        hoverStyle.BgColor = new Color(0.25f, 0.25f, 0.25f);
        hoverStyle.BorderColor = new Color(1, 1, 1);
        hoverStyle.BorderWidthLeft = 2;
        hoverStyle.BorderWidthTop = 2;
        hoverStyle.BorderWidthRight = 2;
        hoverStyle.BorderWidthBottom = 2;
        hoverStyle.CornerRadiusTopLeft = 8;
        hoverStyle.CornerRadiusTopRight = 8;
        hoverStyle.CornerRadiusBottomLeft = 8;
        hoverStyle.CornerRadiusBottomRight = 8;
        select.AddThemeStyleboxOverride("hover", hoverStyle);

        // Style pour l'état pressé
        var pressedStyle = new StyleBoxFlat();
        pressedStyle.BgColor = new Color(0.1f, 0.1f, 0.1f);
        pressedStyle.BorderColor = new Color(0.7f, 0.7f, 0.7f);
        pressedStyle.BorderWidthLeft = 2;
        pressedStyle.BorderWidthTop = 2;
        pressedStyle.BorderWidthRight = 2;
        pressedStyle.BorderWidthBottom = 2;
        pressedStyle.CornerRadiusTopLeft = 8;
        pressedStyle.CornerRadiusTopRight = 8;
        pressedStyle.CornerRadiusBottomLeft = 8;
        pressedStyle.CornerRadiusBottomRight = 8;
        select.AddThemeStyleboxOverride("pressed", pressedStyle);

        // Ajouter les options avec drapeaux
        if (element.Properties.TryGetValue("options", out var optionsObj) && optionsObj is List<SelectOption> options)
        {
            _logManager.Info($"[MenuManager] Langue actuelle : {Main.language}");
            int defaultIndex = 0;
            
            foreach (var option in options)
            {
                // Ajouter l'option au select
                select.AddItem(option.label, select.GetItemCount());
                
                // Si c'est la langue actuelle, on note son index
                if (option.value == Main.language)
                {
                    defaultIndex = select.GetItemCount() - 1;
                    _logManager.Info($"[MenuManager] Langue actuelle trouvée à l'index {defaultIndex}");
                }
                
                // Charger et redimensionner le drapeau
                var flag = GD.Load<Texture2D>(option.iconPath);
                if (flag != null)
                {
                    var resizedTexture = new ImageTexture();
                    var image = flag.GetImage();
                    image.Resize(24, 24);
                    resizedTexture = ImageTexture.CreateFromImage(image);
                    select.SetItemIcon(select.GetItemCount() - 1, resizedTexture);
                }
                else
                {
                    _logManager.Warning($"[MenuManager] Drapeau non trouvé : {option.iconPath}");
                }
            }
            
            // Sélectionner la langue par défaut
            select.Selected = defaultIndex;
            _logManager.Info($"[MenuManager] Langue par défaut sélectionnée : {options[defaultIndex].label}");
        }
        select.Pressed += () => {
            _logManager.Info($"[MenuManager] Le select a été pressé");
        };

        // Gérer le changement de sélection
        select.ItemSelected += (long index) => {
            _logManager.Info($"[MenuManager] La sélection a été modifiée : {index}");
            _logManager.Info($"[MenuManager] Propriétés disponibles : {string.Join(", ", element.Properties.Keys)}");
            
            if (element.Properties.TryGetValue("options", out var selectedOptionsObj) && 
                selectedOptionsObj is List<SelectOption> selectedOptions)
            {
                var selectedOption = selectedOptions[(int)index];
                _logManager.Info($"[MenuManager] Option sélectionnée : {selectedOption.label} ({selectedOption.value})");
                
                if (element.Properties.TryGetValue("action", out var actionObj) && 
                    actionObj is string action)
                {
                    _logManager.Info($"[MenuManager] Action trouvée : '{action}'");
                    if (action == "SetLanguage")
                    {
                        _logManager.Info($"[MenuManager] Exécution de l'action : {action} {selectedOption.value}");
                        _logManager.Info($"[MenuManager] Ancienne langue : {Main.language}");
                        Main.language = selectedOption.value;
                        _logManager.Info($"[MenuManager] Nouvelle langue : {Main.language}");
                    
                        
                        // Recharger les traductions avec la nouvelle langue
                        LocalizationManager.LoadLanguage(Main.language);
                        
                        // Recréer le menu pour mettre à jour les textes
                        DisplaySubMenu(0);
                    }
                    else
                    {
                        _logManager.Info($"[MenuManager] Action incorrecte : '{action}' != 'SetLanguage'");
                    }
                }
            }
        };

        return select;
    }


}
