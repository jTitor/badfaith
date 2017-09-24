using BadFaith.Geography.Fields;

namespace BadFaith.Commands
{
	/**
	Attempts to enter the field's gate,
	if it has one.
	*/
	public class EnterGate : Command
	{
		public readonly int ActorId;
		public EnterGate(int actorId) : base(Actor.All[actorId].FieldId)
			{ActorId = actorId;}

		/**
		Performs a human-readable rendering of this event.
		*/
		public override string Render(int viewerId)
			{
			//Remember that this has been executed
			//and is thus happening on the *destination* field's
			//channel.
			Actor actor = Actor.All[ActorId];
			if (ActorId == viewerId)
				{return "You see yourself entering the gate???"; }
			return string.Format("{0} enters the gate!.", actor.Name);
			}

		public override bool Execute(CommandList commandList)
			{if (Actor.All[ActorId].EnterGate())
				{commandList.AddCommand(new Commands.EnteredGate(ActorId));
				return true;}
			return false;}
	}

	/**
	Observer version of EnterGate.
	*/
	public class EnteredGate : Command
	{
		public readonly int ActorId;
		public EnteredGate(int actorId) : base(Actor.All[actorId].FieldId)
			{
			ActorId = actorId;
			}

		/**
		Performs a human-readable rendering of this event.
		*/
		public override string Render(int viewerId)
			{
			//Remember that this has been executed
			//and is thus happening on the *destination* field's
			//channel.
			Actor actor = Actor.All[ActorId];
			Field field = Field.All[OriginFieldId];
			if (ActorId == viewerId)
				{return string.Format("You gate to {0}.", field.FullName);}
			return string.Format("{0} exits the gate!.", actor.Name);
			}
	}
}