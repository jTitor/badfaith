namespace BadFaith.Views.Player
{
	public static class XActionCommands
	{
		def move(self, direction):
		'''Attempts to move the player's actor in
		the given direction.
		'''
		self.commandList.addCommand(Commands.Move(self.controlledActorID, direction))
		self.uiInterpreterResponse.label = "Moving {0}...".format(direction.name)

	def changeField(self):
		'''Prompts for a field to go to,
		then tries to go to that field.
		'''
		pass
		self._updateField()

	def useGate(self):
		'''Uses the field's gate, if it has one.
		'''
		if not self.field.type == Field.Types.Gate:
			self.uiInterpreterResponse.label = "This isn't a gate field."
		else:
			self.commandList.addCommand(Commands.EnterGate(self.controlledActorID))
			self._updateField()
	}
}