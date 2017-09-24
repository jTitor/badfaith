using BadFaith.Geography.Fields;

namespace BadFaith.Commands
{
	/**
	Moves the actor from their current field
	to the destination field if possible. Does nothing if
	the actor can't actually reach the given field from their
	current field or the actor is already at the given field.
	*/
	public class MoveToField : Command
	{
		public readonly int ActorId;
		public readonly int FieldId;

		public MoveToField(int actorId, int fieldId) : base(Actor.All[actorId].FieldId)
		{
			ActorId = actorId;
			FieldId = fieldId;
		}

		/**
		Performs a human-readable rendering of this event.
		*/
		public override string Render(int viewerId)
		{
			Field field = Field.All[FieldId];
			Actor actor = Actor.All[ActorId];
			if (ActorId == viewerId)
			{
				return string.Format("You see yourself moving to field {0}???", field.FullName);
			}
			return string.Format("{0} leaves the field.", actor.Name);
		}

		public override bool Execute(CommandList commandList)
		{
			if (Actor.All[ActorId].MoveToField(FieldId))
			{
				//Also notify the field that the actor left.
				commandList.AddCommand(new Commands.MovedField(ActorId));
				return true;
			}
			return false;
		}
	}

	/**
	An indicator command that an actor has left
		the given field. Does nothing when executed.
		*/
	public class MovedField : Command
	{
		public readonly int ActorId;
		public MovedField(int actorId) : base(Actor.All[actorId].FieldId)
		{
			ActorId = actorId;
		}

		/**
		Performs a human-readable rendering of this event.
		*/
		public override string Render(int viewerId)
		{
			Field field = Field.All[OriginFieldId];
			Actor actor = Actor.All[ActorId];
			if (ActorId == viewerId)
			{
				return string.Format("You enter field {0}", field.FullName);
			}
			return string.Format("{0} enters the field.", actor.Name);
		}
	}
}