using Godot;
using System;
 // Pour accéder à la classe Character

namespace Openesport.Interfaces
{
	public interface IModule
	{
		// Propriétés essentielles
		string ModuleName { get; }
		bool IsInitialized { get; }
		bool IsActive { get; set; }

		// Méthodes essentielles
		void Initialize();        
		void Cleanup();
		void Process(double delta);
	}
} 
