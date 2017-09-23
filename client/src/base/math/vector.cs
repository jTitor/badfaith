/**
	vector.cs
	Defines 2D vectors.
*/
using System;

namespace BadFaith
{
	/**
		2D int vector.
	*/
	public struct Vector2I
	{
		#region Static Members
		private static Vector2I sZero = new Vector2I(0, 0);
		public static Vector2I Zero { get { return sZero; } }
		private static Vector2I sOne = new Vector2I(1, 1);
		public static Vector2I One { get { return sOne; } }
		private static Vector2I sRight = new Vector2I(1, 0);
		public static Vector2I Right { get { return sRight; } }
		private static Vector2I sUp = new Vector2I(0, 1);
		public static Vector2I Up { get { return sUp; } }
		#endregion

		public int X, Y;

		public Vector2I(int x, int y)
		{
			X = x;
			Y = y;
		}

		#region Operators
		/**
			Negation operator
		*/
		public static Vector2I operator -(Vector2I x)
		{
			return new Vector2I(-x.X, -x.Y);
		}

		public static Vector2I operator +(Vector2I lhs, Vector2I rhs)
		{
			return new Vector2I(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}

		public static Vector2I operator -(Vector2I lhs, Vector2I rhs)
		{
			return lhs + (-rhs);
		}

		public static Vector2I operator *(Vector2I lhs, int rhs)
		{
			return new Vector2I(lhs.X * rhs, lhs.Y * rhs);
		}

		public static Vector2I operator *(int lhs, Vector2I rhs)
		{
			return new Vector2I(lhs * rhs.X, lhs * rhs.Y);
		}

		public static Vector2I operator /(Vector2I lhs, int rhs)
		{
			return new Vector2I(lhs.X / rhs, lhs.Y / rhs);
		}

		public static Vector2I operator /(int lhs, Vector2I rhs)
		{
			return new Vector2I(lhs / rhs.X, lhs / rhs.Y);
		}

		public static int Dot(Vector2I lhs, Vector2I rhs)
		{
			return lhs.X * rhs.X + lhs.Y * rhs.Y;
		}

		#region Equality Operators
		public static bool operator ==(Vector2I lhs, Vector2I rhs)
		{
			return lhs.X == rhs.X && lhs.Y == rhs.Y;
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			//
			// See the full list of guidelines at
			//   http://go.microsoft.com/fwlink/?LinkID=85237
			// and also the guidance for operator== at
			//   http://go.microsoft.com/fwlink/?LinkId=85238
			//

			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			return this == (Vector2I)obj;
		}

		public bool Equals(Vector2I obj)
		{
			return this == obj;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			return (int)Math.Hashing.FnvHash(new uint[] { (uint)X, (uint)Y });
		}

		public static bool operator !=(Vector2I lhs, Vector2I rhs)
		{
			return !(lhs == rhs);
		}
		#endregion
		#endregion

		/**
		Returns the squared magnitude of this vector.
		*/
		public int SqrMag()
		{
			return X * X + Y * Y;
		}

		public float Mag()
		{
			return (float)System.Math.Sqrt(SqrMag());
		}

		public int Dot(Vector2I rhs)
		{
			return Vector2I.Dot(this, rhs);
		}
	}
}