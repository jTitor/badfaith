namespace BadFaith.Views.Player
{
	public static class XActorControlCommands
	{
		/**
		Immediately takes control of an actor.
		*/
		public void ControlActor(int actorID)
		{
			_doControlActor(actorID);
			UiInterpreterResponse.label = string.Format("You are now {0}.", Actor.Name);
		}

	/**
	Creates a new actor and puts you in control
	of them, destroying the old actor you might've been in.
	*/
	public void Respawn()
		{
			throw new NotImplementedException();
		}
	}
}