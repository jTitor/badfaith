/**
Contains terminal-specific operations.
*/
using System.Collections.Generic;
using BadFaith.UI;
using BadFaith.UI.Palettes;

namespace BadFaith.UI.Terminals
{
	public class Terminal
	{
		private CursesInterface curses;
		private Window mainWindow;
		private List<Window> windows;
		private Palette palette;
		public bool NeedsLayout { get; set; }

	/**
Manages the terminal display and input.
	*/
	public Terminal(Window window){
		//Set this or you end up with a totally black screen
		curses.use_default_colors();
		mainWindow = Window(window, isStatic=True);
		//We also don't really need to highlight the cursor.
		curses.curs_set(0);
		windows = new List<Window>(){mainWindow};
		/**
Set this to ensure all windows are resized
		and refreshed.
		*/
		NeedsLayout = true;
		//Initialize palettes.
		palette = UI.Palettes.DefaultPalette();
		foreach(PaletteColor p in palette.All)
			{curses.init_pair(p.paletteCode, p.cursesForeground, p.cursesBackground);
			p.cursesCode = curses.color_pair(p.paletteCode);}}

	def refresh(self, layoutFunction=_noLayout):
		/**
Redraws the screen.
		'layoutFunction' is a callback you provide that
		takes the terminal as its only parameter;
		it should rearrange and resize the windows as you desire.
		if you don't provide one, a no-op dummy is used instead.
		*/
		//Check for size changes.
		screenResized = mainWindow.refreshExtents()
		//Don't actually lazy redraw
		//right now since you have to redraw
		//on screen change, and the screen's supposed to be dynamic.
		needsLayout = screenResized or needsLayout
		//if needsLayout:
		for window in windows:
			window.clear()
		layoutFunction(self)
		for window in windows:
			window.shouldRefresh()
		curses.doupdate()
		needsLayout = False

	def getch(self):
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
		return mainWindow.getch()

	def _implementationSubWindow(self, originYX=(0, 0), extentsYX=(1, 1)):
		return curses.newwin(extentsYX[0], extentsYX[1], originYX[0], originYX[1])

	def subWindow(self, originYX=(0, 0), extentsYX=(1, 1), isStatic=False):
		/**
Makes a subwindow at the given screen
		coordinates and extents, returning
		the Window object used to manipulate it.
		*/
		subwindow = _implementationSubWindow(originYX, extentsYX)
		result = Window(subwindow, isStatic)
		windows.append(result)
		return result

	def removeWindow(self, windowID):
		/**
Removes a window from rendering.
		The main window can't be removed this way,
		however.
		*/
		if windowID != mainWindow.id:
			windowToRemove = None
			for window in windows:
				if window.id == windowID:
					windowToRemove = window
			if windowToRemove:
				windows.remove(windowToRemove)
	}
}