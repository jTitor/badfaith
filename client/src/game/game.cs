/**
	game.cs
	public voidines high-level game runner.
 */
// try:
// 	import curses
// except ImportError:
// 	print "Platform doesn't appear to support Curses! Can't setup terminal!"
// 	import sys
// 	sys.exit(1)
// from .src.game import Game
// from .src.terminal import Terminal
using System.Collections.Generic;

namespace BadFaith
{
	public class Game
	{
		private static float kMinUpdatableTimeSeconds = 0.01f;
		private bool shouldQuit = false;
		private World world = null;
		// //All the players in the game, basically.
		// //update() is called on these elements
		// //to update the world state.
		private List<IActorView> views = new List<IActorView>();
		private CommandList commandList = new CommandList();
		private float wallTimeSeconds = 0.0f;
		private float minUpdatableTimeSeconds = kMinUpdatableTimeSeconds;
		private Terminal terminal = null;

		void Game(Terminal inTerminal)
		{
			terminal = inTerminal;
			// //Prime the data tables!
			TableOps.setup();
		}

		public void RunWithNewWorld()
		{
			//TODO: These are Log entries!!!
			print("Generating world...");
			world = WorldGen.generateWorld();
			//Add one view for the player.
			views.Add(PlayerView(this));
			Actor.RandomSpawnsForViews(views);
			gameLoop();
		}

		/**
		Updates the game world. This also calls all views'
		update() method.
		*/
		protected void update()
		{
			//Update views so we get world commands
			//for this frame.
			foreach (View v in views)
			{
				//TODO: make this DOD
				v.update(this);
			}
			//Actually execute those world commands.
			commandList.update(this);
		}

		protected void render()
		{
			//Render all views.
			foreach (View v in views)
			{
				v.render()}
		}

		private void gameLoop()
		{//Prep the command list.
		 //commandList.generateFieldChannels()
		 //Connect the player and AIs to their actors.
			float currTimeSeconds = CurrentTime();
			float accumulator = 0.0f;
			while (!shouldQuit)
			{
				float newTimeSeconds = CurrentTime();
				float elapsedTimeSeconds = newTimeSeconds - currTimeSeconds;
				accumulator += elapsedTimeSeconds;

				//Enter the main game loop:
				//	Get player commands.
				//	Get AI commands.
				//	Validate commands.
				//	Update game world given all valid commands.
				while (accumulator >= minUpdatableTimeSeconds)
				{
					update();
					accumulator -= minUpdatableTimeSeconds
					wallTimeSeconds += minUpdatableTimeSeconds;
				}

				//	Display state to player and AI.
				render();
			}
		}

		public void Quit()
		{
			shouldQuit = true;
		}
		// public void startGame(stdscr):
		// 	game = Game(Terminal(stdscr))
		// 	//There's no save/load,
		// 	//so for now we just generate a new world each time.
		// 	game.runWithNewWorld()
	}

	// public void main():
	// 	curses.wrapper(startGame)

	// if __name__ == "__main__":
	// 	main()
}