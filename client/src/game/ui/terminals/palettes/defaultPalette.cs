using System.Collections.Generic;

namespace BadFaith.UI.Terminals.Palettes
{
	/**
	A set of common palette codes. An instance must be
	created by a Terminal first.
	*/
	public class DefaultPalette
	{
		
		public const PaletteColor BlackOnTransparent = PaletteColor(1, curses.COLOR_BLACK, -1);
		public const PaletteColor WhiteOnTransparent = PaletteColor(2, curses.COLOR_WHITE, -1);
		public const PaletteColor RedOnTransparent = PaletteColor(3, curses.COLOR_RED, -1);
		public const PaletteColor GreenOnTransparent = PaletteColor(4, curses.COLOR_GREEN, -1);
		public const PaletteColor BlueOnTransparent = PaletteColor(5, curses.COLOR_BLUE, -1);
		public const PaletteColor WhiteOnBlack = PaletteColor(6, curses.COLOR_WHITE, curses.COLOR_BLACK);
		public const PaletteColor RedOnBlack = PaletteColor(7, curses.COLOR_RED, curses.COLOR_BLACK);
		public const PaletteColor GreenOnBlack = PaletteColor(8, curses.COLOR_GREEN, curses.COLOR_BLACK);
		public const PaletteColor BlueOnBlack = PaletteColor(9, curses.COLOR_BLUE, curses.COLOR_BLACK);
		public const PaletteColor WhiteOnRed = PaletteColor(10, curses.COLOR_WHITE, curses.COLOR_RED);
		public const PaletteColor WhiteOnGreen = PaletteColor(11, curses.COLOR_WHITE, curses.COLOR_GREEN);
		public const PaletteColor WhiteOnBlue = PaletteColor(12, curses.COLOR_WHITE, curses.COLOR_BLUE);
		/**
		All of the palettes as a tuple.
		*/
		private List<PaletteColor> all = new List<PaletteColor>(){BlackOnTransparent, WhiteOnTransparent, RedOnTransparent,
		GreenOnTransparent, BlueOnTransparent,
		WhiteOnBlack, RedOnBlack, GreenOnBlack,
		BlueOnBlack, WhiteOnRed, WhiteOnGreen,
		WhiteOnBlue};
		public List<PaletteColor> All { get {return all;} }
	}
}