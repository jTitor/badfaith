/**
	direction.cs
 */

namespace BadFaith.Geography
{
	public struct Direction
	{
		public string Name;
		public int Value;

		public Direction(string name, int value)
		{
			Name = name;
			Value = value;
		}

		public static Direction North = new Direction("North", 0);
		public static Direction South = new Direction("South", 2);
		public static Direction East = new Direction("East", 1);
		public static Direction West = new Direction("West", 3);
		private static Direction[] all = {North, East, South, West};

		/**
		Returns the opposite direction of the given direction object.
		 */
		public static Direction Opposite(Direction d)
		{
			return all[(d.Value + 2) % all.Length];
		}

		public Direction Opposite()
		{
			return Direction.Opposite(this);
		}
	}
}