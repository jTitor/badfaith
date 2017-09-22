namespace BadFaith.Views.Player
{
	public static class XActorControlCommands
	{
		def controlActor(self, actorID):
		'''Immediately takes control of an actor.
		'''
		self._doControlActor(actorID)
		self.uiInterpreterResponse.label = "You are now {0}.".format(self.actor.name)

	def respawn(self):
		'''Creates a new actor and puts you in control
		of them, destroying the old actor you might've been in.
		'''
		raise NotImplementedError
	}
}