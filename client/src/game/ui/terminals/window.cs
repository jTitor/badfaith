namespace BadFaith.UI.Terminals
{
	public class Window
	{
		class Window(object):
	'''Abstracts windows.
	'''
	LastID = -1
	FlagMap = {

	}

	@classmethod
	def _nextID(cls):
		'''Gets the next ID available for a window.
		'''
		cls.LastID += 1
		return cls.LastID

	def __init__(self, window, isStatic=False):
		'''The actual curses window object
		this window owns.
		'''
		self.window = window
		self.id = Window._nextID()
		#Set screen to no-delay
		#so key events don't block game execution.
		self.window.nodelay(True)
		'''If true, resize/change origin commands
		won't work and requestFill will be ignored.
		Generally only the main window needs this,
		but any window can have it set.
		'''
		self.isStatic = isStatic
		# '''If nonzero, this window will attempt to take the specified edges it can in the main window.
		# This is a *request*; if multiple windows have this set,
		# only one will get the fill and it's not guaranteed which
		# one is it.
		# '''
		# self.fillRequestFlags = fillRequestFlags
		# '''If nonzero, this window will attempt to snap to the specified edges in the main window.
		# Again, this is a request, and the first window in the terminal to request it gets to snap to the screen edge.
		# Other windows will snap to that window.
		# '''
		# self.snapRequest = snapRequest
		'''The (y,x) origin of the window.
		'''
		self.origin = self.window.getbegyx()
		'''The (y,x) lengths of the window sides.
		Is totally ignored if 'requestFill' is set.
		'''
		self.extents = self.window.getmaxyx()

	def clear(self):
		'''Clears the window area.
		'''
		self.window.clear()

	def shouldRefresh(self):
		'''Indicates that the window should be redrawn,
		but does not specifically do it; 'Terminal.refresh()'
		performs the actual redraw.
		'''
		self.window.noutrefresh()

	def refreshOrigin(self):
		'''If the origin was changed without us knowing,
		call this to update self.origin with the actual origin value.
		Returns:
			* True if the origin actually changed.
		'''
		newOrigin = self.window.getbegyx()
		originChanged = newOrigin != self.origin
		self.origin = newOrigin
		return originChanged

	def refreshExtents(self):
		'''The windowing system may have resized
		the terminal window; call this on the main window,
		otherwise 'self.extents' may no longer be valid.
		Returns:
			* True if the extents actually changed.
		'''
		newExtents = self.window.getmaxyx()
		extentsChanged = newExtents != self.extents
		self.extents = newExtents
		return extentsChanged

	def setOrigin(self, newOriginYX):
		'''Changes the window origin.
		Returns True if the window was moved
		to the exact position requested.
		'''
		if not self.isStatic:
			self.window.mvwin(newOriginYX[0], newOriginYX[1])
			self.refreshOrigin()
		return self.origin == newOriginYX

	def setExtents(self, newExtentsYX):
		'''Actually resizes the window.
		Returns True if the window was resized
		to the exact size requested.
		'''
		if not self.isStatic:
			self.window.resize(newExtentsYX[0], newExtentsYX[1])
			self.refreshExtents()
		return self.extents == newExtentsYX

	def getch(self):
		'''Gets a single character from
		standard input as an *integer*. Can be any positive value;
		you can trust that ASCII and Unicode values corespond as
		expected.
		Returns -1 when there's no input.

		To test for characters, do equality against ord(),
		or test equality against the curses constants for
		keys such as curses.KEY_LEFT.
		'''
		return self.window.getch()

	def setColor(self, backgroundPalette, formatFlags=FormatFlags.Normal):
		'''Sets the foreground/background to the given palette.
		'''
		assert isinstance(backgroundPalette, Palette)
		flags = FormatFlags.toImplementationFlags(formatFlags)
		self.window.bkgd(' ', backgroundPalette.cursesCode | flags)

	def _doPrintString(self, string, positionYX, cursesFlags=curses.A_NORMAL):
		self.window.addnstr(positionYX[0], positionYX[1], string, self.extents[1]-1, cursesFlags)

	def printString(self, string, positionYX=(0, 0)):
		'''Prints the given string, clipping it if
		it's too long for its window.
		'''
		self._doPrintString(string, positionYX)

	def printFormattedString(self, string, positionYX=(0, 0), flags=FormatFlags.Normal):
		'''Prints the given string with the
		given FormatFlags.
		'''
		self._doPrintString(string, positionYX, FormatFlags.toImplementationFlags(flags))

def _noLayout(_):
	'''Dummy function used when application
	doesn't provide a layout function.
	'''
	pass
	}
}