using System.Collections.Generic;

using BadFaith.Ui.Terminals;
using BadFaith.Ui.Elements;
using BadFaith.Ui.Terminals.Constants;

namespace BadFaith.Tests.Ui.Elements
{
	public class TestAll
	{

		/**
		Tests the Ui elements.
		*/
		public class TestUi
		{
			public Terminal Terminal;
			public ScrollBox ScrollBox;
			public TextLine TextLine1;
			public TextLine TextLine2;
			public TestUi(CursesWindowHandle window)
			{
				Terminal = new Terminal(window);
				ScrollBox = new ScrollBox(Terminal);
				TextLine1 = new TextLine(this.Terminal, "Press 'A' to add a line...");
				TextLine1.SetColor(Terminal.Palette.WhiteOnBlack);
				TextLine2 = new TextLine(Terminal);
				TextLine2.Label = "Or press 'Q' to quit";
				TextLine2.SetColor(Terminal.Palette.WhiteOnBlack, FormatFlags.Reverse);
			}

			public void Layout(_)
			{
				TextLine2.ToBottom();
				TextLine2.FillRow();
				TextLine1.ToBottom(1);
				TextLine1.FillRow();
				Vector2I screenExtents = Terminal.MainWindow.Extents;
				ScrollBox.SetExtents(new Vector2I(screenExtents.X - 2, screenExtents.Y));
				TextLine2.Render();
				TextLine1.Render();
				ScrollBox.Render();
			}

			public void AddRandomLine()
			{
				List<string> newLineElems = new List<string>();
				for (int i = 0; i < random.randint(3, 90); ++i)
				{
					newLineElems.Add(random.choice(string.letters));
				}
				string newLine = string.Join("", newLineElems);
				TextLine2.Label = string.Format("Added '{0}'", newLine);
				ScrollBox.AddLine(newLine);
			}

			public void Run()
			{
				//While we haven't hit Q:
				bool shouldQuit = false;
				while (!shouldQuit)
				{
					//Refresh the window.
					int lastChar = Terminal.getch();
					if (lastChar == ord('a') or lastChar == ord('A'))
					{
						AddRandomLine();
					}
					shouldQuit = lastChar == ord('q') || lastChar == ord('Q');
					Terminal.Refresh(Layout);
				}
			}
		}

		// import curses
		public static void testEntryPoint(CursesContext stdscr)
		{
			//Create and run an instance.
			new TestUi(stdscr).Run();
		}

		// if __name__ == "__main__":
		// 	curses.wrapper(testEntryPoint)
	}
}