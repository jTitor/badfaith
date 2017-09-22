namespace BadFaith
{
	public class EnterGate
	{
		class EnterGate(object):
		'''Attempts to enter the field's gate,
		if it has one.
		'''
		def __init__(self, actorID):
			self.actorID = actorID
			self.originFieldID = Actor.All[self.actorID].fieldID

		def render(self, viewerID):
			'''Performs a human-readable rendering of this event.
			'''
			#Remember that this has been executed
			#and is thus happening on the *destination* field's
			#channel.
			actor = Actor.All[self.actorID]
			if self.actorID == viewerID:
				return "You see yourself entering the gate???."
			return "{0} enters the gate!.".format(actor.name)

		def execute(self, commandList):
			if Actor.All[self.actorID].enterGate():
				commandList.addCommand(Commands.EnteredGate(self.actorID))
				return True
			return False
	}

	public class EnteredGate
	{
		class EnteredGate(object):
		'''Observer version of EnterGate.
		'''
		def __init__(self, actorID):
			self.actorID = actorID
			self.originFieldID = Actor.All[self.actorID].fieldID

		def render(self, viewerID):
			'''Performs a human-readable rendering of this event.
			'''
			#Remember that this has been executed
			#and is thus happening on the *destination* field's
			#channel.
			actor = Actor.All[self.actorID]
			field = Field.All[self.originFieldID]
			if self.actorID == viewerID:
				return "You gate to {0}.".format(field.fullName)
			return "{0} exits the gate!.".format(actor.name)

		def execute(self, commandList):
			return True
	}
}