using BadFaith.Views.Player;

namespace BadFaith.Views
{
	class PlayerView(object):
	'''Displays world state and relays player input as world commands.

	There are two main sections: the world display
	and the command interpreter. The interpreter is split into
	two halves, a top line displaying system responses to their
	actions and a bottom line where the player enters commands.
	By default most commands are keyboard shortcuts, and '`' activates the interpreter mode.
	'''
	def _doControlActor(self, actorID):
		if actorID > len(Actor.All):
			raise RuntimeError("Invalid actor {0}".format(actorID))
		self.controlledActorID = actorID
		self.actor = Actor.All[self.controlledActorID]
		self._updateField()

	def _updateField(self):
		self.field = Field.All[self.actor.fieldID]

	def __init__(self, game, actorID=0):
		print("Entering world...")
		self._doControlActor(actorID)
		self.actionList = {
			ord('q'): game.quit,
			ord('w'): lambda: self.move(Directions.North),
			ord('s'): lambda: self.move(Directions.South),
			ord('a'): lambda: self.move(Directions.East),
			ord('d'): lambda: self.move(Directions.West),
			ord('f'): self.changeField,
			ord('g'): self.useGate,
			ord('l'): self.lookAll
		}
		self.commandList = game.commandList
		#UI elements.
		self.terminal = game.terminal
		self.uiWorldEvents = UI.ScrollBox(self.terminal)
		self.uiPlayerLocation = UI.TextLine(self.terminal)
		self.uiPlayerStatus = UI.TextLine(self.terminal)
		self.uiInterpreterResponse = UI.TextLine(self.terminal)
		self.uiInterpreterInput = UI.TextLine(self.terminal)
		self.uiPlayerLocation.setColor(self.terminal.palette.whiteOnBlack)
		self.uiPlayerStatus.setColor(self.terminal.palette.whiteOnBlack)
		self.uiInterpreterResponse.setColor(self.terminal.palette.whiteOnBlack)
		self.uiInterpreterInput.label = ">"
		self.uiInterpreterResponse.label = "What next?"
		self.uiAll = (self.uiWorldEvents, self.uiPlayerLocation, self.uiPlayerStatus, self.uiInterpreterResponse, self.uiInterpreterInput)

	def updateUI(self):
		self.uiInterpreterResponse.label = "What next?"
		self.uiPlayerLocation.label = self.actorLocation()
		self.uiPlayerStatus.label = self.actorState()
		for fieldEvent in self._getFieldChannel():
			self.uiWorldEvents.addLine(fieldEvent.render(self.controlledActorID))
		for uiElement in self.uiAll:
			uiElement.render()

	def layout(self, _):
		'''UI layout callback.
		'''
		self.uiInterpreterInput.toBottom()
		self.uiInterpreterResponse.toBottom(1)
		self.uiPlayerStatus.toBottom(2)
		self.uiWorldEvents.toTop(1)
		self.uiPlayerLocation.toTop()
		self.uiInterpreterInput.fillRow()
		self.uiInterpreterResponse.fillRow()
		self.uiPlayerStatus.fillRow()
		screenExtents = self.terminal.mainWindow.extents
		self.uiWorldEvents.setExtents((screenExtents[0]-4, screenExtents[1]))
		self.uiPlayerLocation.fillRow()
		self.updateUI()

	def update(self, game):
		#Get player input here and send commands here.
		playerInput = game.terminal.getch()
		if playerInput in self.actionList:
			#If input's a valid command, run it.
			self.actionList[playerInput]()

	def _getFieldChannel(self):
		return self.commandList.fieldEvents[self.actor.fieldID]

	def render(self):
		#Display game world here.
		self.terminal.refresh(self.layout)
}