using BadFaith.Geography;

namespace BadFaith.Commands
{
	/**
	Moves the actor in the given direction by
	`length` number of units. If this would
	take it outside the field, the movement is
	clamped to the field's edge instead.
	*/
	public class Move : Command
	{
		public readonly int ActorId;
		public readonly Direction Direction;
		public readonly int Length;

		public Move(int actorId, Direction direction, int length = 1) : base(Actor.All[actorId].FieldId)
		{
			ActorId = actorId;
			Direction = direction;
			Length = length;
		}

		/**
		Performs a human-readable rendering of this event.
		*/
		public override string Render(int viewerId)
		{
			Actor actor = Actor.All[ActorId];
			if (ActorId == viewerId)
			{ return string.Format("You move to {0}.", actor.FieldPosition); }
			return string.Format("{0} moves to {1}.", actor.Name, actor.FieldPosition);
		}

		public override bool Execute(CommandList commandList)
		{ return Actor.All[ActorId].Move(Direction, Length); }
	}
}