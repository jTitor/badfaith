namespace BadFaith.UI
{
	class ScrollBox(UIElement):
		'''Displays multiple lines,
		removing the oldest as it goes.
		'''
		def __init__(self, terminal, bufferMax=80):
			super(UI.ScrollBox, self).__init__(terminal)
			#Now init our data.
			'''The lines currently being displayed.
			Always displays the *last* of these.
			'''
			self.lines = []
			'''The maximum number of lines
			stored before the oldest gets removed.
			'''
			assert bufferMax > 0
			self.bufferMax = bufferMax

		def addLine(self, stringToAdd=""):
			'''Adds a line to the box.
			If the line contains newlines,
			they're each considered a separate line.
			'''
			allStrings = stringToAdd.split('\n')
			for s in allStrings:
				self.lines.append(s)
			#Also pop off any excess from the top.
			while len(self.lines) > self.bufferMax:
				self.lines.pop(0)

		def render(self):
			'''Renders this ScrollBox.
			'''
			linesToRender = min(len(self.lines), self.extents[0])
			stringPosition = [0, 0]
			for s in self.lines[-linesToRender:]:
				self.printString(s, stringPosition)
				stringPosition[0] += 1
}