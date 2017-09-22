namespace BadFaith.UI.Terminals.Constants
{
	class SnapCodes(object):
	'''Possible values for Window.snap.
	'''
	NoSnap = 0
	Up = 1
	Down = 2
	Left = 3
	Right = 4
	UpperLeft = 5
	UpperRight = 6
	LowerLeft = 7
	LowerRight = 8

class FillFlags(object):
	'''Possible flag values for Window.fill.
	'''
	NoFill = 0
	Up = 1 << 0
	Down = 1 << 1
	Left = 1 << 2
	Right = 1 << 3
}