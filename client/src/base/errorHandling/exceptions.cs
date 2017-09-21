/**
		
	exceptions.cs
	Defines exceptions used by the game.
 */

using System;

namespace BadFaith
{
	/**
		Base class for all game exceptions.
	*/
	public class GameException : InvalidOperationException
	{
		private const string kExceptionMessage = "Unspecified problem in game engine.";

		public GameException(string message = kExceptionMessage) : base(message) { }
	}

	/**
		Raised when an error occurs during gameplay.
	*/
	public class GameplayError : GameException
	{
		private const string kExceptionMessage = "Unspecified problem while running game.";

		public GameplayError(string message = kExceptionMessage) : base(message) { }
	}

	/**
		Errors during world generation.
	*/
	public class WorldGenError : GameException
	{
		private const string kExceptionMessage = "Error while generating world data.";

		public WorldGenError(string message = kExceptionMessage) : base(message) { }
	}

#pragma region Warnings
	// Warning exceptions.
	// these are unusual situations that
	// won't crash the program, but probably will
	// break the intended workflow.
	// Unless we're developing you probably want to halt
	// when these are generated,
	// so they throw
	//unless --permit-warnings is set.

	/**
		Raised when a nonfatal error occurs during gameplay.
	*/
	public class GameplayWarning : GameException
	{
		private const string kExceptionMessage = "Nonfatal error while running game; game is likely in an unstable state.";

		public GameplayWarning(string message = kExceptionMessage) : base(message) { }
	}
#pragma endregion
}