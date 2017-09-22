namespace BadFaith.UI
{
	'''Specifies UI elements.
'''
from .terminal import Terminal, Window
	class UIElement(Window):
		'''Base class for UI elements.
		'''
		def __init__(self, terminal):
			#Make the window.
			implementationWindow = terminal._implementationSubWindow()
			#Attach ourselves to the terminal's window list.
			terminal.windows.append(self)
			#Initialize the super data now...
			super(UI.UIElement, self).__init__(implementationWindow)
			self.mainWindow = terminal.mainWindow

		def setRow(self, row):
			'''Convenience function for adjusting the row position
			only.
			'''
			self.setOrigin((row, self.origin[1]))

		def fillRow(self):
			'''Convenience function to fill entire row.
			'''
			self.setExtents((self.extents[0], self.mainWindow.extents[1]))

		def toBottom(self, displacement=0):
			'''Convenience function to snap to bottom minus
			'displacement'.
			'''
			self.setOrigin((self.mainWindow.extents[0]-(1+displacement), self.origin[1]))

		def toTop(self, displacement=0):
			'''Convenience function to snap to top plus
			'displacement'.
			'''
			self.setOrigin((displacement, self.origin[1]))
}