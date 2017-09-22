namespace BadFaith.UI.Terminals
{
	public class Terminal
	{
		'''Contains terminal-specific operations.
'''
try:
	import curses
except ImportError:
	print "Platform doesn't appear to support Curses! Can't setup terminal!"
	import sys
	sys.exit(1)

class Terminal(object):
	'''Manages the terminal display and input.
	'''
	def __init__(self, window):
		#Set this or you end up with a totally black screen
		curses.use_default_colors()
		self.mainWindow = Window(window, isStatic=True)
		#We also don't really need to highlight the cursor.
		curses.curs_set(0)
		self.windows = [self.mainWindow,]
		'''Set this to ensure all windows are resized
		and refreshed.
		'''
		self.needsLayout = True
		#Initialize palettes.
		self.palette = DefaultPalette()
		for p in self.palette.all:
			curses.init_pair(p.paletteCode, p.cursesForeground, p.cursesBackground)
			p.cursesCode = curses.color_pair(p.paletteCode)

	def refresh(self, layoutFunction=_noLayout):
		'''Redraws the screen.
		'layoutFunction' is a callback you provide that
		takes the terminal as its only parameter;
		it should rearrange and resize the windows as you desire.
		if you don't provide one, a no-op dummy is used instead.
		'''
		#Check for size changes.
		screenResized = self.mainWindow.refreshExtents()
		#Don't actually lazy redraw
		#right now since you have to redraw
		#on screen change, and the screen's supposed to be dynamic.
		self.needsLayout = screenResized or self.needsLayout
		#if self.needsLayout:
		for window in self.windows:
			window.clear()
		layoutFunction(self)
		for window in self.windows:
			window.shouldRefresh()
		curses.doupdate()
		self.needsLayout = False

	def getch(self):
		'''Gets a single character from
		standard input. Can be any positive value;
		you can trust that ASCII values corespond as
		expected.
		Returns -1 when there's no input.

		To test for characters, do equality against ord(),
		or test equality against the curses constants for
		keys such as curses.KEY_LEFT.
		'''
		return self.mainWindow.getch()

	def _implementationSubWindow(self, originYX=(0, 0), extentsYX=(1, 1)):
		return curses.newwin(extentsYX[0], extentsYX[1], originYX[0], originYX[1])

	def subWindow(self, originYX=(0, 0), extentsYX=(1, 1), isStatic=False):
		'''Makes a subwindow at the given screen
		coordinates and extents, returning
		the Window object used to manipulate it.
		'''
		subwindow = self._implementationSubWindow(originYX, extentsYX)
		result = Window(subwindow, isStatic)
		self.windows.append(result)
		return result

	def removeWindow(self, windowID):
		'''Removes a window from rendering.
		The main window can't be removed this way,
		however.
		'''
		if windowID != self.mainWindow.id:
			windowToRemove = None
			for window in self.windows:
				if window.id == windowID:
					windowToRemove = window
			if windowToRemove:
				self.windows.remove(windowToRemove)
	}
}