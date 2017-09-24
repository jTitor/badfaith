using System.Collections.Generic;

namespace BadFaith.Ui.Terminals.Palettes
{
	/**
	A set of common palette codes. An instance must be
	created by a Terminal first.
	*/
	public class DefaultPalette
	{
		
		private static PaletteColor blackOnTransparent = new PaletteColor(1, curses.COLOR_BLACK, -1);
		public PaletteColor BlackOnTransparent { get { return blackOnTransparent; } }
		private static PaletteColor whiteOnTransparent = new PaletteColor(2, curses.COLOR_WHITE, -1);
		public PaletteColor WhiteOnTransparent { get { return whiteOnTransparent; } }
		private static PaletteColor redOnTransparent = new PaletteColor(3, curses.COLOR_RED, -1);
		public PaletteColor RedOnTransparent { get { return redOnTransparent; } }
		private static PaletteColor greenOnTransparent = new PaletteColor(4, curses.COLOR_GREEN, -1);
		public PaletteColor GreenOnTransparent { get { return greenOnTransparent; } }
		private static PaletteColor blueOnTransparent = new PaletteColor(5, curses.COLOR_BLUE, -1);
		public PaletteColor BlueOnTransparent { get { return blueOnTransparent; } }
		private static PaletteColor whiteOnBlack = new PaletteColor(6, curses.COLOR_WHITE, curses.COLOR_BLACK);
		public PaletteColor WhiteOnBlack { get { return whiteOnBlack; } }
		private static PaletteColor redOnBlack = new PaletteColor(7, curses.COLOR_RED, curses.COLOR_BLACK);
		public PaletteColor RedOnBlack { get { return redOnBlack; } }
		private static PaletteColor greenOnBlack = new PaletteColor(8, curses.COLOR_GREEN, curses.COLOR_BLACK);
		public PaletteColor GreenOnBlack { get { return greenOnBlack; } }
		private static PaletteColor blueOnBlack = new PaletteColor(9, curses.COLOR_BLUE, curses.COLOR_BLACK);
		public PaletteColor BlueOnBlack { get { return blueOnBlack; } }
		private static PaletteColor whiteOnRed = new PaletteColor(10, curses.COLOR_WHITE, curses.COLOR_RED);
		public PaletteColor WhiteOnRed { get { return whiteOnRed; } }
		private static PaletteColor whiteOnGreen = new PaletteColor(11, curses.COLOR_WHITE, curses.COLOR_GREEN);
		public PaletteColor WhiteOnGreen { get { return whiteOnGreen; } }
		private static PaletteColor whiteOnBlue = new PaletteColor(12, curses.COLOR_WHITE, curses.COLOR_BLUE);
		public PaletteColor WhiteOnBlue { get { return whiteOnBlue; } }
		/**
		All of the palettes as a tuple.
		*/
		private static List<PaletteColor> all = new List<PaletteColor>(){blackOnTransparent, whiteOnTransparent, redOnTransparent,
		greenOnTransparent, blueOnTransparent,
		whiteOnBlack, redOnBlack, greenOnBlack,
		blueOnBlack, whiteOnRed, whiteOnGreen,
		whiteOnBlue};
		public List<PaletteColor> All { get {return all;} }
	}
}