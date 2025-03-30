using Godot;
using System;

public partial class LogManager : Node
{
	private bool _isDebugMode = true;

	public void SetDebugMode(bool enabled)
	{
		_isDebugMode = enabled;
	}

	public void Error(string message)
	{
		GD.PrintErr($"[ERROR] {message}");
	}

	public void Warning(string message)
	{
		GD.Print($"[WARNING] {message}");
	}

	public void Info(string message)
	{
		GD.Print($"[INFO] {message}");
	}

	public void Debug(string message)
	{
		if (_isDebugMode)
		{
			GD.Print($"[DEBUG] {message}");
		}
	}
} 
