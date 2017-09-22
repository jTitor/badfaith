namespace BadFaith.UI.Terminals.Palettes
{
	public class DefaultPalette
	{
		class DefaultPalette(object):
	'''A set of common palette codes. An instance must be
	created by a Terminal first.
	'''
	def __init__(self):
		self.blackOnTransparent = Palette(1, curses.COLOR_BLACK, -1)
		self.whiteOnTransparent = Palette(2, curses.COLOR_WHITE, -1)
		self.redOnTransparent = Palette(3, curses.COLOR_RED, -1)
		self.greenOnTransparent = Palette(4, curses.COLOR_GREEN, -1)
		self.blueOnTransparent = Palette(5, curses.COLOR_BLUE, -1)
		self.whiteOnBlack = Palette(6, curses.COLOR_WHITE, curses.COLOR_BLACK)
		self.redOnBlack = Palette(7, curses.COLOR_RED, curses.COLOR_BLACK)
		self.greenOnBlack = Palette(8, curses.COLOR_GREEN, curses.COLOR_BLACK)
		self.blueOnBlack = Palette(9, curses.COLOR_BLUE, curses.COLOR_BLACK)
		self.whiteOnRed = Palette(10, curses.COLOR_WHITE, curses.COLOR_RED)
		self.whiteOnGreen = Palette(11, curses.COLOR_WHITE, curses.COLOR_GREEN)
		self.whiteOnBlue = Palette(12, curses.COLOR_WHITE, curses.COLOR_BLUE)
		'''All of the palettes as a tuple.
		'''
		self.all = (self.blackOnTransparent, self.whiteOnTransparent, self.redOnTransparent,
		self.greenOnTransparent, self.blueOnTransparent,
		self.whiteOnBlack, self.redOnBlack, self.greenOnBlack,
		self.blueOnBlack, self.whiteOnRed, self.whiteOnGreen,
		self.whiteOnBlue)
	}
}