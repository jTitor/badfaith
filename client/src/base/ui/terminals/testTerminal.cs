using System.Collections.Generic;
using BadFaith.UI.Terminals.Constants;

namespace BadFaith.UI.Terminals
{
	public class TestTerminal
	{
		class ManualTest
		{
			private Window worldStatus, responseLine, commandLine;
			private Terminal terminal;
			public ManualTest(CursesInterface stdscr)
			{
				print("In init");
				//Make a terminal with stdscr.
				terminal = new Terminal(stdscr);
				Palettes.DefaultPalette palette = terminal.Palette;
				//Display a world status section
				worldStatus = terminal.SubWindow();
				//in red,
				worldStatus.SetColor(palette.WhiteOnRed);
				//An interpreter response section
				responseLine = terminal.SubWindow();
				//in green,
				responseLine.SetColor(palette.WhiteOnGreen, FormatFlags.Bold);
				//and the interpreter command section
				commandLine = terminal.SubWindow();
				commandLine.SetColor(palette.WhiteOnBlue, FormatFlags.Reverse);
				//in blue.
				print("Extents are: {0}").format(terminal.MainWindow.Extents);
			}

			private void manualTestLayout()
			{//The command line should snap to the bottom left first
			 //and fill right first. It should be 1 row high.
				Vector2I screenExtents = terminal.MainWindow.Extents;
				commandLine.SetOrigin(new Vector2I(screenExtents.X - 1, 0));
				commandLine.SetExtents(new Vector2I(1, screenExtents.Y));
				//The response line should snap to the bottom left second
				//and fill right second. It should be 1 row high.
				responseLine.SetOrigin(new Vector2I(screenExtents.X - 2, 0));
				responseLine.SetExtents(new Vector2I(1, screenExtents.Y));
				//The world status should snap to the upper left last
				//and fill bottom right last.
				worldStatus.SetOrigin(Vector2I.Zero);
				worldStatus.SetExtents(new Vector2I(screenExtents.X - 2, screenExtents.Y));
				//Optionally draw a border.
				// for window in terminal.windows[1:]:
				// 	window.window.border()
				//Add a message indicating the different windows.
				worldStatus.PrintString("The world status window! Should be white on red.");
				worldStatus.PrintString("(press 'Q' to end test)", new Vector2I(1, 0));
				responseLine.PrintString("The response line! Should be white on green and bold.");
				commandLine.PrintString("The command line! Should be blue on white.");
			}

			public void Run()
			{
				print("Entering run loop");
				//While we haven't hit Q:
				bool shouldQuit = false;
				while (!shouldQuit)
				{
					//refresh the window.
					terminal.Refresh(_manualTestLayout);
					int lastChar = terminal.GetCh();
					shouldQuit = lastChar == ord('q') || lastChar == ord('Q');
				}
			}
		}

		private void manualTest(CursesInterface stdscr)
		{
			print("Running test");
			new ManualTest(stdscr).Run();
		}

		public void Main()
		{
			curses.wrapper(_manualTest);
		}
	}
}