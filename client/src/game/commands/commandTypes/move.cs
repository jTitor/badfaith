namespace BadFaith
{
	public class Move
	{
		class Move(object):
		'''Moves the actor in the given direction by
		`length` number of units. If this would
		take it outside the field, the movement is
		clamped to the field's edge instead.
		'''
		def __init__(self, actorID, direction, length=1):
			self.actorID = actorID
			self.originFieldID = Actor.All[self.actorID].fieldID
			self.direction = direction
			self.length = length

		def render(self, viewerID):
			'''Performs a human-readable rendering of this event.
			'''
			actor = Actor.All[self.actorID]
			if self.actorID == viewerID:
				return "You move to {0}.".format(actor.fieldPosition)
			return "{0} moves to {1}.".format(actor.name, actor.fieldPosition)

		def execute(self, commandList):
			return Actor.All[self.actorID].move(self.direction, self.length)
	}
}