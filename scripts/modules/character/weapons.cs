using Godot;
using System;
using Openesport.Modules;
using Openesport.Utils;

namespace Openesport.Modules
{
    public partial class Weapons : Module
    {
        private LogManager _logManager;

        public override string ModuleName => "weapons";

        protected override void SetupModule()
        {
            _logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
            _logManager.Info($"[{ModuleName}] Je suis chargé avec notre système de log");
        }

        protected override void CleanupModule()
        {
            _logManager.Info($"[{ModuleName}] Nettoyage du module");
        }

        public override void Process(double delta)
        {
            if (!IsActive) return;
        }

        public override void ExecuteAction(string action)
        {
            // À implémenter plus tard
        }
    }
} 