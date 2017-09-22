namespace BadFaith.UI.Terminals.Palettes
{
	public class Palette
	{
		class Palette(object):
	'''Represents a foreground/background pair.
	The colors come initialized with a Terminal;
	do not instantiate an instance as the colors won't
	actually work.
	'''
	def __init__(self, paletteCode, cursesForeground, cursesBackground):
		'''The palette's number in the palette.
		'''
		self.paletteCode = paletteCode
		'''The code this would have if curses.color_pair
		were called on its palette number.
		'''
		self.cursesCode = 0
		'''The curses constant that represents this
		palette's foreground color.
		'''
		self.cursesForeground = cursesForeground
		'''The curses constant that represents this
		palette's background color.
		'''
		self.cursesBackground = cursesBackground
	}
}