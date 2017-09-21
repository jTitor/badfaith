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