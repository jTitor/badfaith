namespace BadFaith.UI
{
	class TextLine(UIElement):
		'''Displays a single string inside itself.
		This tries to have the same width as the screen.
		'''
		def __init__(self, terminal, label=""):
			super(UI.TextLine, self).__init__(terminal)
			#Now init our data.
			'''The text to display.
			'''
			self.label = label

		def render(self):
			'''Renders this TextLine.
			'''
			self.printString(self.label)
}