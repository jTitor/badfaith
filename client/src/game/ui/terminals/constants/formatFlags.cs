namespace BadFaith.UI.Terminals.Constants
{
	public class FormatFlags
	{
		class FormatFlags(object):
	'''Formatting codes for character printing.
	'''

	'''Render the following text normally.
	'''
	Normal = 1 << 0
	'''Bold the text being displayed.
	For some colors this also intensifies
	the color.
	'''
	Bold = 1 << 1
	'''Use palette's foreground as background,
	and its background as foreground.
	'''
	Reverse = 1 << 2
	'''Underline the given character.
	'''
	Underline = 1 << 3
	'''Dim the given character.
	'''
	Dim = 1 << 4
	'''Make the character blink.
	'''
	Blink = 1 << 5
	'''Make the character as visible as possible.
	'''
	Standout = 1 << 6

	'''All formatting flags.
	'''
	All = (Normal, Bold, Reverse, Underline, Dim, Blink, Standout)
	'''Maps format flags to internal implementation values.
	'''
	ImplementationMap = {
		Normal: curses.A_NORMAL,
		Bold: curses.A_BOLD,
		Reverse: curses.A_REVERSE,
		Underline: curses.A_UNDERLINE,
		Dim: curses.A_DIM,
		Blink: curses.A_BLINK,
		Standout: curses.A_STANDOUT
	}

	@classmethod
	def toImplementationFlags(cls, flags):
		'''Converts a FormatFlags value to its
		implementation's respective value.
		'''
		result = 0
		for flag in cls.All:
			if flags & flag:
				result |= cls.ImplementationMap[flag]
		return result
	}
}