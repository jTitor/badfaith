namespace BadFaith.Tests.UI
{
	public class TestAll
	{
		import random
import string
from .terminal import FormatFlags

class TestUI(object):
	'''Tests the UI elements.
	'''
	def __init__(self, window):
		self.terminal = Terminal(window)
		self.scrollBox = UI.ScrollBox(self.terminal)
		self.textLine1 = UI.TextLine(self.terminal, "Press 'A' to add a line...")
		self.textLine1.setColor(self.terminal.palette.whiteOnBlack)
		self.textLine2 = UI.TextLine(self.terminal)
		self.textLine2.label = "Or press 'Q' to quit"
		self.textLine2.setColor(self.terminal.palette.whiteOnBlack, FormatFlags.Reverse)

	def layout(self, _):
		self.textLine2.toBottom()
		self.textLine2.fillRow()
		self.textLine1.toBottom(1)
		self.textLine1.fillRow()
		screenExtents = self.terminal.mainWindow.extents
		self.scrollBox.setExtents((screenExtents[0]-2,screenExtents[1]))
		self.textLine2.render()
		self.textLine1.render()
		self.scrollBox.render()

	def addRandomLine(self):
		newLine = "".join([random.choice(string.letters) for i in xrange(random.randint(3, 90))])
		self.textLine2.label = "Added '{0}'".format(newLine)
		self.scrollBox.addLine(newLine)

	def run(self):
		#While we haven't hit Q:
		shouldQuit = False
		while not shouldQuit:
			#Refresh the window.
			lastChar = self.terminal.getch()
			if lastChar == ord('a') or lastChar == ord('A'):
				self.addRandomLine()
			shouldQuit = lastChar == ord('q') or lastChar == ord('Q')
			self.terminal.refresh(self.layout)

import curses
def testEntryPoint(stdscr):
	#Create and run an instance.
	TestUI(stdscr).run()

if __name__ == "__main__":
	curses.wrapper(testEntryPoint)
	}
}