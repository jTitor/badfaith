/**
Contains terminal-specific operations.
*/
using System;
using System.Collections.Generic;
using BadFaith.Ui;
using BadFaith.Ui.Terminals.Palettes;

namespace BadFaith.Ui.Terminals
{
	public class Terminal
	{
		private CursesInterface curses;
		private Window mainWindow;
		public Window MainWindow{get{return mainWindow;}}
		private List<Window> windows;
		private DefaultPalette palette;
		public DefaultPalette Palette {get{return palette;} set{palette = value;}}
		/**
		Set this to true ensure all windows are resized
		and refreshed.
		*/
		public bool NeedsLayout { get; set; }

		#region Constants
		private readonly String kDefaultTitle = "Game Title";
		#endregion
		/**
		Initializes the console this terminal is connected to.
		*/
		private void initConsole()
		{
			Console.Title = "WolfCurses Console Application";
			Console.WriteLine("Starting...");
			Console.CursorVisible = false;
			//Have the console respond to Ctrl+C.
			Console.CancelKeyPress += Console_CancelKeyPress;
		}

		private void handleInput()
		{
			// Check if a key is being pressed, without blocking thread.
			if (Console.KeyAvailable)
			{
				// Get the key that was pressed, without printing it to console.
				var key = Console.ReadKey(true);

				// If enter is pressed, pass whatever we have to simulation.
				// ReSharper disable once SwitchStatementMissingSomeCases
				switch (key.Key)
				{
					case ConsoleKey.Enter:
						ConsoleSimulationApp.Instance.InputManager.SendInputBufferAsCommand();
						break;
					case ConsoleKey.Backspace:
						ConsoleSimulationApp.Instance.InputManager.RemoveLastCharOfInputBuffer();
						break;
					default:
						ConsoleSimulationApp.Instance.InputManager.AddCharToInputBuffer(key.KeyChar);
						break;
				}
			}
		}

		#region Public Methods
		/**
		Manages the terminal display and input.
		*/
		public Terminal(CursesWindowHandle window)
		{
			//Set this or you end up with a totally black screen
			curses.use_default_colors();
			mainWindow = new Window(window, true);
			//We also don't really need to highlight the cursor.
			curses.curs_set(0);
			windows = new List<Window>() { mainWindow };
			NeedsLayout = true;
			//Initialize palettes.
			palette = new DefaultPalette();
			foreach (PaletteColor p in palette.All)
			{
				curses.init_pair(p.PaletteCode, p.CursesForeground, p.CursesBackground);
				p.CursesCode = curses.color_pair(p.PaletteCode);
			}
		}

		/**
		Redraws the screen.
		'layoutFunction' is a callback you provide that
		takes the terminal as its only parameter;
		it should rearrange and resize the windows as you desire.
		if you don't provide one, a no-op dummy is used instead.
		*/
		public void Refresh(layoutFunction= _noLayout)
		{
			//Check for size changes.
			bool screenResized = mainWindow.RefreshExtents();
			//Don't actually lazy redraw
			//right now since you have to redraw
			//on screen change, and the screen's supposed to be dynamic.
			NeedsLayout = screenResized || NeedsLayout;
			//if needsLayout:
			foreach (Window w in windows)
			{ w.Clear(); }
			layoutFunction();
			foreach (Window w in windows)
			{ w.RequestRefresh(); }
			curses.doupdate();
			NeedsLayout = false;
		}

		/**
		Gets a single character from
		standard input. Can be any positive value;
		you can trust that ASCII values corespond as
		expected.
		Returns -1 when there's no input.

		To test for characters, do equality against ord(),
		or test equality against the curses constants for
		keys such as curses.KEY_LEFT.
		*/
		public int GetCh()
		{
			return mainWindow.GetCh();
		}

		/**
		Creates the backend elements needed for a subwindow.
		Returns the handle of the subwindow.
		 */
		private int implementationSubWindow(Vector2I originYX, Vector2I extentsYX)
		{ return curses.newwin(extentsYX.X, extentsYX.Y, originYX.X, originYX.Y); }

		private int implementationSubWindow(Vector2I originYX)
		{ return implementationSubWindow(originYX, Vector2I.One); }

		private int implementationSubWindow()
		{ return implementationSubWindow(Vector2I.Zero, Vector2I.One); }

		/**
		Makes a subwindow at the given screen
		coordinates and extents, returning
		the Window object used to manipulate it.
		*/
		public Window SubWindow(Vector2I originYX, Vector2I extentsYX, bool isStatic)
		{
			CursesWindow subWindowHandle = implementationSubWindow(originYX, extentsYX);
			Window result = new Window(subWindowHandle, isStatic);
			windows.Add(result);
			return result;
		}

		public Window SubWindow(Vector2I originYX, Vector2I extentsYX)
		{
			return SubWindow(originYX, extentsYX, false);
		}

		public Window SubWindow(Vector2I originYX)
		{
			return SubWindow(originYX, Vector2I.One, false);
		}

		public Window SubWindow()
		{
			return SubWindow(Vector2I.Zero, Vector2I.One, false);
		}

		/**
		Removes a window from rendering.
		The main window can't be removed this way,
		however.
		*/
		public void RemoveWindow(int windowId)
		{
			if (windowId != mainWindow.Id)
			{
				Window windowToRemove = null;
				foreach (Window w in windows)
				{
					if (w.Id == windowId)
					{
						windowToRemove = w;
					}
				}
				if (windowToRemove != null)
				{
					windows.Remove(windowToRemove);
				}
			}
		}
	}
	#endregion
}