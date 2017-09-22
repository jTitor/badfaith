namespace BadFaith.Views.Player
{
			/**
			View commands for the player view.
			 */
			public static class XViewCommands
			{
				def describeSelf(self):
		return "You are {0}.".format(self.actor.name)

	def describeField(self):
		fieldDescription = "You are in {0}.".format(self.field.fullName())
		if self.field.fieldID == 0:
			fieldDescription += "\nYou get the feeling you shouldn't be here..."
		if self.field.type == Field.Types.Gate:
			otherField = Field.All[self.field.destinationFieldID]
			fieldDescription += "\nThis is a gate field! It's pointing to {0}.".format(otherField.fullName())
		return fieldDescription

	def lookAll(self):
		'''Looks at everything in the field.
		'''
		#Print to world status even though this isn't a event.
		self.uiWorldEvents.addLine(self.describeField())

	def actorState(self):
		return("Position:{0}, Armor: {1}/{2}, Psyche: {3}/{4}".format(self.actor.fieldPosition, self.actor.armor, self.actor.maxArmor, self.actor.psyche, self.actor.maxPsyche))

	def actorLocation(self):
		return "{0}: {1}".format(self.actor.name, self.field.fullName())

	def describeActor(self, otherActorID):
		if otherActorID == self.controlledActorID:
			self.describeSelf()
			return

		actor = Actor.All[otherActorID]
		print("You see a {0}.".format(actor.name))
			}
}