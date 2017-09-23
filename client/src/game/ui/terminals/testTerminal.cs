namespace BadFaith.UI.Terminals
{
	public class TestTerminal
	{
		class manualTest{
	public manualTest(CursesInterface stdscr){
		print("In init");
		//Make a terminal with stdscr.
		Terminal terminal = new Terminal(stdscr);
		Palette palette = terminal.Palette;
		//Display a world status section
		Window worldStatus = terminal.SubWindow();
		//in red,
		worldStatus.SetColor(palette.whiteOnRed);
		//An interpreter response section
		Window responseLine = terminal.SubWindow();
		//in green,
		responseLine.SetColor(palette.whiteOnGreen, FormatFlags.Bold);
		//and the interpreter command section
		Window commandLine = terminal.SubWindow();
		commandLine.SetColor(palette.whiteOnBlue, FormatFlags.Reverse);
		//in blue.
		print("Extents are: {0}").format(terminal.MainWindow.extents);}

	def _manualTestLayout(_)
		{//The command line should snap to the bottom left first
		//and fill right first. It should be 1 row high.
		screenExtents = tuple(terminal.mainWindow.extents)
		commandLine.setOrigin((screenExtents[0]-1, 0))
		commandLine.setExtents((1, screenExtents[1]))
		//The response line should snap to the bottom left second
		//and fill right second. It should be 1 row high.
		responseLine.setOrigin((screenExtents[0]-2, 0))
		responseLine.setExtents((1, screenExtents[1]))
		//The world status should snap to the upper left last
		//and fill bottom right last.
		worldStatus.setOrigin((0, 0))
		worldStatus.setExtents((screenExtents[0]-2, screenExtents[1]))
		//Optionally draw a border.
		// for window in terminal.windows[1:]:
		// 	window.window.border()
		//Add a message indicating the different windows.
		worldStatus.printString("The world status window! Should be white on red.")
		worldStatus.printString("(press 'Q' to end test)", (1, 0))
		responseLine.printString("The response line! Should be white on green and bold.")
		commandLine.printString("The command line! Should be blue on white.")}

	def run(){
		print("Entering run loop")
		//While we haven't hit Q:
		shouldQuit = False
		while not shouldQuit:
			//refresh the window.
			terminal.refresh(_manualTestLayout)
			lastChar = terminal.getch()
			shouldQuit = lastChar == ord('q') or lastChar == ord('Q')}}

def _manualTest(stdscr):
	print("Running test")
	manualTest(stdscr).run()

def main():
	curses.wrapper(_manualTest)

if __name__ == "__main__":
	main()

	}
}