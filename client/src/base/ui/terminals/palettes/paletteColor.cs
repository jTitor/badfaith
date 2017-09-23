namespace BadFaith.UI.Terminals.Palettes
{
	public class PaletteColor
	{
		/**The palette's number in the palette.
		*/
		private int paletteCode;
		public int PaletteCode { get { return paletteCode; } }
		/**The code this would have if curses.color_pair
		were called on its palette number.
		*/
		private int cursesCode;
		public int CursesCode { get { return cursesCode; } set { cursesCode = value; } }
		/**The curses constant that represents this
		palette's foreground color.
		*/
		private int cursesForeground;
		public int CursesForeground { get { return cursesForeground; } }
		/**The curses constant that represents this
		palette's background color.
		*/
		private int cursesBackground;
		public int CursesBackground { get { return cursesBackground; } }
		/**Represents a foreground/background pair.
		The colors come initialized with a Terminal;
		do not instantiate an instance as the colors won't
		actually work.
		*/
		public PaletteColor(int paletteCode, int cursesForeground, int cursesBackground)
		{
			/**The palette's number in the palette.
			*/
			this.paletteCode = paletteCode;
			/**The code this would have if curses.color_pair
			were called on its palette number.
			*/
			cursesCode = 0;
			/**The curses constant that represents this
			palette's foreground color.
			*/
			this.cursesForeground = cursesForeground;
			/**The curses constant that represents this
			palette's background color.
			*/
			this.cursesBackground = cursesBackground;
		}
	}
}