using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Openesport.Interfaces;
using Openesport.Structures;
using Openesport.Utils;


namespace Openesport.Modules
{
	public abstract partial class Module : Node, IModule
	{
		public abstract string ModuleName { get; }
		public bool IsInitialized { get; protected set; }
		public bool IsActive { get; set; }

		protected LogManager _logManager;
		protected InputManager _inputManager;
		

		protected virtual void SetupModule() { }
		protected virtual void CleanupModule() { }

		public virtual void Initialize()
		{
			if (IsInitialized) return;
			SetupModule();
			IsInitialized = true;
			IsActive = true;
		}

		

		public virtual void Initialize( InputManager inputManager)
		{
			if (IsInitialized) return;
			
			_inputManager = inputManager;			
			SetupModule();
			IsInitialized = true;
			IsActive = true;
		}

		public virtual void Cleanup()
		{
			if (!IsInitialized) return;
			CleanupModule();
			IsActive = false;
			IsInitialized = false;
		}

		public virtual void Process(double delta) { }
		public virtual void PhysicsProcess(double delta) { }

		public virtual void ExecuteAction(string action) { }
	}
} 
