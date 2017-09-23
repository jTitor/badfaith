using System.Collections.Generic;

namespace BadFaith.UI.Terminals
{
	/**
	Abstracts windows.
	*/
	public class Window
	{
	private static int sLastID = -1;
	//TODO: check types on this
	private static Dictionary<int, int> sFlagMap = new Dictionary<int, int>();
	/**
	The actual curses window object
		this window owns.
		*/
	private	CursesWindow cursesWindow;
	/**
	This window's ID.
	 */
	private int id;
	public int Id{get{return id;}}

	/**If true, resize/change origin commands
		won't work and requestFill will be ignored.
		Generally only the main window needs this,
		but any window can have it set.
		*/
	public bool IsStatic{get;set;}
	public Vector2I Origin{get;}
	public Vector2I Extents{get;set;}

	private static int nextID()
		{/**
		Gets the next ID available for a window.
		*/
		Window.sLastID += 1;
		return Window.sLastID;}

	public Window(CursesWindow window, bool isStatic=false)
		{/**The actual curses window object
		this window owns.
		*/
		cursesWindow = window;
		id = Window.nextID();
		//Set screen to no-delay
		//so key events don't block game execution.
		cursesWindow.nodelay(true);
		/**If true, resize/change origin commands
		won't work and requestFill will be ignored.
		Generally only the main window needs this,
		but any window can have it set.
		*/
		this.IsStatic = isStatic;
		// /**If nonzero, this window will attempt to take the specified edges it can in the main window.
		// This is a *request*; if multiple windows have this set,
		// only one will get the fill and it's not guaranteed which
		// one is it.
		// */
		// fillRequestFlags = fillRequestFlags
		// /**If nonzero, this window will attempt to snap to the specified edges in the main window.
		// Again, this is a request, and the first window in the terminal to request it gets to snap to the screen edge.
		// Other windows will snap to that window.
		// */
		// snapRequest = snapRequest
		/**The (y,x) origin of the window.
		*/
		Origin = cursesWindow.getbegyx();
		/**The (y,x) lengths of the window sides.
		Is totally ignored if 'requestFill' is set.
		*/
		Extents = cursesWindow.getmaxyx();}

	/**Clears the window area.
		*/
	public void Clear(){
		
		cursesWindow.clear();}

	/**Indicates that the window should be redrawn,
		but does not specifically do it; 'Terminal.refresh()'
		performs the actual redraw.
		*/
	public void RequestRefresh(){
		
		cursesWindow.noutrefresh();}

	/**If the origin was changed without us knowing,
		call this to update origin with the actual origin value.
		Returns:
			* True if the origin actually changed.
		*/
	public bool RefreshOrigin(){
		Vector2I newOrigin = cursesWindow.getbegyx();
		bool originChanged = newOrigin != Origin;
		Origin = newOrigin;
		return originChanged;}

	/**The windowing system may have resized
		the terminal window; call this on the main window,
		otherwise 'extents' may no longer be valid.
		Returns:
			* True if the extents actually changed.
		*/
	public bool RefreshExtents(){
		Vector2I newExtents = cursesWindow.getmaxyx();
		bool extentsChanged = newExtents != Extents;
		Extents = newExtents;
		return extentsChanged;}

	/**Changes the window origin.
		Returns True if the window was moved
		to the exact position requested.
		*/
	public bool SetOrigin(Vector2I newOriginYX)
		{
		if (!IsStatic)
		{
			cursesWindow.mvwin(newOriginYX.X, newOriginYX.Y);
			RefreshOrigin();
			}
		return Origin == newOriginYX;
}

	/**Actually resizes the window.
		Returns True if the window was resized
		to the exact size requested.
		*/
	public bool SetExtents(Vector2I newExtentsYX)
		{
		if (!IsStatic)
			{cursesWindow.resize(newExtentsYX.X, newExtentsYX.Y);
			RefreshExtents();}
		return Extents == newExtentsYX;}

	/**Gets a single character from
		standard input as an *integer*. Can be any positive value;
		you can trust that ASCII and Unicode values corespond as
		expected.
		Returns -1 when there's no input.

		To test for characters, do equality against ord(),
		or test equality against the curses constants for
		keys such as curses.KEY_LEFT.
		*/
	public int GetCh(){
		return cursesWindow.getch();}

	public void SetColor(PaletteColor backgroundPalette, FormatFlags formatFlags=FormatFlags.Normal)
		{/**Sets the foreground/background to the given palette.
		*/
		//assert isinstance(backgroundPalette, Palette);
		int flags = FormatFlags.toImplementationFlags(formatFlags);
		cursesWindow.bkgd(' ', backgroundPalette.cursesCode | flags);}

	private void doPrintString(string toPrint, Vector2I positionYX, int cursesFlags=curses.A_NORMAL)
		{cursesWindow.addnstr(positionYX.X, positionYX.Y, toPrint, Extents.X-1, cursesFlags);}

	/**Prints the given string, clipping it if
		it's too long for its window.
		*/
	public void PrintString(string toPrint, Vector2I positionYX)
		{doPrintString(string, positionYX);}

	public void PrintString(string toPrint)
		{doPrintString(string, positionYX);}

	def printFormattedString(string, positionYX=(0, 0), flags=FormatFlags.Normal):
		/**Prints the given string with the
		given FormatFlags.
		*/
		_doPrintString(string, positionYX, FormatFlags.toImplementationFlags(flags))

private void noLayout()
	{
		/**Dummy function used when application
	doesn't provide a layout function.
	*/
	}
	}
}