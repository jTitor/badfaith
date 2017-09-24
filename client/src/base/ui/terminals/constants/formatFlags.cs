using System.Collections.Generic;

namespace BadFaith.Ui.Terminals.Constants
{
	/**
	Formatting codes for character printing.
	*/
	public static class FormatFlags
	{
		/**
		Render the following text normally.
		*/
		//Use "readonly" since semantically we'd have these
		//be extern constants, const copies values during link
		public static readonly int Normal = 1 << 0;
		/**
		Bold the text being displayed.
		For some colors this also intensifies
		the color.
		*/
		public static readonly int Bold = 1 << 1;
		/**
		Use palette's foreground as background,
		and its background as foreground.
		*/
		public static readonly int Reverse = 1 << 2;
		/**
		Underline the given character.
		*/
		public static readonly int Underline = 1 << 3;
		/**
		Dim the given character.
		*/
		public static readonly int Dim = 1 << 4;
		/**
		Make the character blink.
		*/
		public static readonly int Blink = 1 << 5;
		/**
		Make the character as visible as possible.
		*/
		public static readonly int Standout = 1 << 6;

		private static int[] all = { Normal, Bold, Reverse, Underline, Dim, Blink, Standout };
		/**
		All formatting flags.
		*/
		public static int[] All { get { return all; } }
		/**Maps format flags to internal implementation values.
		*/
		private static readonly Dictionary<int, int> implementationMap = new Dictionary<int, int>(){
		{Normal, curses.A_NORMAL},
		{Bold, curses.A_BOLD},
		{Reverse, curses.A_REVERSE},
		{Underline, curses.A_UNDERLINE},
		{Dim, curses.A_DIM},
		{Blink, curses.A_BLINK},
		{Standout, curses.A_STANDOUT}
	};

		/**
		Converts a FormatFlags value to its
		implementation's respective value.
		*/
		public static int ToImplementationFlags(int flags)
		{
			int result = 0;
			foreach (int flag in All)
			{
				if ((flags & flag) != 0)
				{ result |= implementationMap[flag]; }
			}
			return result;
		}
	}
}