namespace BadFaith
{
	public class MoveToField{
		class MoveToField(object):
		'''Moves the actor from their current field
		to the destination field if possible. Does nothing if
		the actor can't actually reach the given field from their
		current field or the actor is already at the given field.
		'''
		def __init__(self, actorID, fieldID):
			self.actorID = actorID
			self.originFieldID = Actor.All[self.actorID].fieldID
			self.fieldID = fieldID

		def render(self, viewerID):
			'''Performs a human-readable rendering of this event.
			'''
			field = Field.All[self.fieldID]
			actor = Actor.All[self.actorID]
			if self.actorID == viewerID:
				return "You see yourself moving to field {0}???".format(field.fullName())
			return "{0} leaves the field.".format(actor.name)

		def execute(self, commandList):
			if Actor.All[self.actorID].moveToField(self.fieldID):
				#Also notify the field that the actor left.
				commandList.addCommand(Commands.MovedField(self.actorID))
				return True
			return False
	}

	public class MovedField
	{
		class MovedField(object):
		'''An indicator command that an actor has left
		the given field. Does nothing.
		'''
		def __init__(self, actorID):
			self.actorID = actorID
			self.originFieldID = Actor.All[self.actorID].fieldID

		def render(self, viewerID):
			'''Performs a human-readable rendering of this event.
			'''
			field = Field.All[self.originFieldID]
			actor = Actor.All[self.actorID]
			if self.actorID == viewerID:
				return "You enter field {0}".format(field.fullName())
			return "{0} enters the field.".format(actor.name)

		def execute(self, commandList):
			return True
	}
}