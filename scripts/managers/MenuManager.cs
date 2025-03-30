using Godot;
using System;
using System.Collections.Generic;
using Openesport.Structures;
using System.Linq;
using Openesport.Utils;
using Openesport.Modules;

public partial class MenuManager : Control
{
    private GameManager _gameManager;
    private Node _currentMenu;
    private LogManager _logManager;
    private Dictionary<int, MenuEntry> _menuEntries = new Dictionary<int, MenuEntry>();
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

    public void AddMenuEntry(MenuEntry entry)
    {
        //_logManager.Info($"[MenuManager] Tentative d'ajout d'une entrée : {entry.Name} (ID: {entry.Id})");

        if (_menuEntries.ContainsKey(entry.Id))
        {
            _logManager.Warning($"[MenuManager] Une entrée avec l'ID {entry.Id} existe déjà");
            return;
        }

        _menuEntries[entry.Id] = entry;
        //_logManager.Info($"[MenuManager] Entrée ajoutée avec succès : {entry.Name} (ID: {entry.Id})");
        //_logManager.Info($"[MenuManager] Poids : {entry.Poids}");
        //_logManager.Info($"[MenuManager] Nombre total d'entrées : {_menuEntries.Count}");

        // Créer et ajouter le bouton visuel dans le menu principal
        var buttonsContainer = GetNode<VBoxContainer>("MenuCenterContainer/MenuVBoxContainer/ButtonsContainer");
        if (buttonsContainer != null)
        {
            Button button = CreateStyledButton(entry);
            button.Pressed += () => OnButtonPressed(entry);
            buttonsContainer.AddChild(button);
            //_logManager.Info($"[MenuManager] Bouton créé et ajouté pour l'entrée : {entry.Name}");
        }
        else
        {
            _logManager.Error("[MenuManager] ButtonsContainer non trouvé");
        }
    }

    public void RemoveMenuEntry(int id)
    {
        //_logManager.Info($"[MenuManager] Tentative de suppression de l'entrée ID: {id}");

        if (!_menuEntries.ContainsKey(id))
        {
            _logManager.Warning($"[MenuManager] Aucune entrée trouvée avec l'ID {id}");
            return;
        }

        var entryName = _menuEntries[id].Name;
        _menuEntries.Remove(id);
        //_logManager.Info($"[MenuManager] Entrée supprimée avec succès : {entryName} (ID: {id})");
        //_logManager.Info($"[MenuManager] Nombre total d'entrées : {_menuEntries.Count}");
    }

    public void ClearMenuEntries()
    {
        //_logManager.Info($"[MenuManager] Tentative de suppression de toutes les entrées (actuellement {_menuEntries.Count})");
        _menuEntries.Clear();
        //_logManager.Info("[MenuManager] Toutes les entrées ont été supprimées");
    }

    public void UpdateMenuEntry(MenuEntry entry)
    {
        //_logManager.Info($"[MenuManager] Tentative de mise à jour de l'entrée : {entry.Name} (ID: {entry.Id})");

        if (!_menuEntries.ContainsKey(entry.Id))
        {
            _logManager.Warning($"[MenuManager] Aucune entrée trouvée avec l'ID {entry.Id} pour la mise à jour");
            return;
        }

        var oldName = _menuEntries[entry.Id].Name;
        _menuEntries[entry.Id] = entry;
        //_logManager.Info($"[MenuManager] Entrée mise à jour avec succès : {oldName} -> {entry.Name} (ID: {entry.Id})");
    }

    public MenuEntry? GetMenuEntry(int id)
    {
        //_logManager.Info($"[MenuManager] Tentative de récupération de l'entrée ID: {id}");

        if (_menuEntries.ContainsKey(id))
        {
            //_logManager.Info($"[MenuManager] Entrée trouvée : {_menuEntries[id].Name} (ID: {id})");
            return _menuEntries[id];
        }

        _logManager.Warning($"[MenuManager] Aucune entrée trouvée avec l'ID {id}");
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
        ClearMenuEntries();
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
        return _menuEntries.Values.Any(entry => entry.ParentId == parentId);
    }

    private void LoadUI(string uiPath)
    {
        //_logManager.Info($"[MenuManager] Chargement de l'UI : {uiPath}");
        // TODO: Implémenter le chargement de l'UI
        // Pour l'instant, on cache juste le menu
        Hide();
    }

    private void OnButtonPressed(MenuEntry entry)
    {
        //_logManager.Info($"[MenuManager] Bouton pressé : {entry.Name} (ID: {entry.Id})");

        // 1. Si une action existe, l'exécuter
        if (!string.IsNullOrEmpty(entry.Action))
        {
            //_logManager.Info($"[MenuManager] Exécution de l'action : {entry.Action}");
            ExecuteAction(entry.Action);
        }
        // 2. Si une UI existe, la charger
        if (!string.IsNullOrEmpty(entry.UiPath))
        {
            //_logManager.Info($"[MenuManager] Chargement de l'UI : {entry.UiPath}");
            LoadUI(entry.UiPath);
        }
        // 3. Sinon, si des boutons ont ce bouton comme parent, afficher le sous-menu
        else if (HasChildren(entry.Id))
        {
            //_logManager.Info($"[MenuManager] Affichage du sous-menu pour : {entry.Name}");
            DisplaySubMenu(entry.Id);
        }
    }

    private void DisplaySubMenu(int parentId)
    {
        //_logManager.Info($"[MenuManager] Affichage du sous-menu (ParentId: {parentId})");

        // Nettoyer le conteneur
        var buttonsContainer = GetNode<VBoxContainer>("MenuCenterContainer/MenuVBoxContainer/ButtonsContainer");
        foreach (var child in buttonsContainer.GetChildren())
        {
            child.QueueFree();
        }

        // Récupérer et trier les entrées par poids
        var entries = _menuEntries.Values
            .Where(entry => entry.ParentId == parentId)
            .OrderByDescending(entry => entry.Poids)
            .ToList();

        // Afficher tous les boutons du niveau
        foreach (var entry in entries)
        {
            Button button = CreateStyledButton(entry);
            button.Pressed += () => OnButtonPressed(entry);
            buttonsContainer.AddChild(button);
        }

        // Si on n'est pas au niveau racine, ajouter le bouton retour en dernier
        if (parentId != 0)
        {
            Button backButton = CreateStyledBackButton();
            backButton.Pressed += () => DisplaySubMenu(_menuEntries[parentId].ParentId);
            buttonsContainer.AddChild(backButton);
        }
    }

    /// <summary>
    /// Crée un bouton stylisé.
    /// - Si une icône est fournie (IconPath non vide), le bouton sera carré et affichera uniquement l'icône en remplissant tout l'espace.
    /// - Sinon, le bouton affichera le texte de l'entrée.
    /// </summary>
    private Button CreateStyledButton(MenuEntry entry)
	{
		Button button = new Button();
		// Taille minimale du bouton pour afficher texte et icône
		button.CustomMinimumSize = new Vector2(250, 50);
		// Toujours afficher le texte de l'entrée
		button.Text = entry.Name;

		// Si une icône est fournie, on la charge ; sinon, on utilise l'icône par défaut
		string iconPath = !string.IsNullOrEmpty(entry.IconPath) ? entry.IconPath : "res://assets/textures/Menu/boutons/default_icon.png";
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
			_logManager.Warning($"[MenuManager] Icône non trouvée pour {entry.Name} : {iconPath}");
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

		return button;
	}

	private Button CreateStyledBackButton()
	{
		Button button = new Button();
		button.CustomMinimumSize = new Vector2(250, 50);
		button.Text = "Retour";

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

		return button;
	}

}
