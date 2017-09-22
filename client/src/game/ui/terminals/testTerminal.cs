namespace BadFaith.UI.Terminals
{
	class TestTerminal
	{
		class manualTest(object):
	def __init__(self, stdscr):
		print("In init")
		#Make a terminal with stdscr.
		self.terminal = Terminal(stdscr)
		self.palette = self.terminal.palette
		#Display a world status section
		self.worldStatus = self.terminal.subWindow()
		#in red,
		self.worldStatus.setColor(self.palette.whiteOnRed)
		#An interpreter response section
		self.responseLine = self.terminal.subWindow()
		#in green,
		self.responseLine.setColor(self.palette.whiteOnGreen, FormatFlags.Bold)
		#and the interpreter command section
		self.commandLine = self.terminal.subWindow()
		self.commandLine.setColor(self.palette.whiteOnBlue, FormatFlags.Reverse)
		#in blue.
		print("Extents are: {0}").format(self.terminal.mainWindow.extents)

	def _manualTestLayout(self, _):
		#The command line should snap to the bottom left first
		#and fill right first. It should be 1 row high.
		screenExtents = tuple(self.terminal.mainWindow.extents)
		self.commandLine.setOrigin((screenExtents[0]-1, 0))
		self.commandLine.setExtents((1, screenExtents[1]))
		#The response line should snap to the bottom left second
		#and fill right second. It should be 1 row high.
		self.responseLine.setOrigin((screenExtents[0]-2, 0))
		self.responseLine.setExtents((1, screenExtents[1]))
		#The world status should snap to the upper left last
		#and fill bottom right last.
		self.worldStatus.setOrigin((0, 0))
		self.worldStatus.setExtents((screenExtents[0]-2, screenExtents[1]))
		#Optionally draw a border.
		# for window in self.terminal.windows[1:]:
		# 	window.window.border()
		#Add a message indicating the different windows.
		self.worldStatus.printString("The world status window! Should be white on red.")
		self.worldStatus.printString("(press 'Q' to end test)", (1, 0))
		self.responseLine.printString("The response line! Should be white on green and bold.")
		self.commandLine.printString("The command line! Should be blue on white.")

	def run(self):
		print("Entering run loop")
		#While we haven't hit Q:
		shouldQuit = False
		while not shouldQuit:
			#refresh the window.
			self.terminal.refresh(self._manualTestLayout)
			lastChar = self.terminal.getch()
			shouldQuit = lastChar == ord('q') or lastChar == ord('Q')

def _manualTest(stdscr):
	print("Running test")
	manualTest(stdscr).run()

def main():
	curses.wrapper(_manualTest)

if __name__ == "__main__":
	main()

	}
}