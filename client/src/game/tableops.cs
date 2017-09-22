/**
Functions for initializing game tables.
*/
// from .topology import Field, Zone, Sector
// from .actor import Actor
using System.Diagnostics;

namespace BadFaith
{
	namespace TableOps
	{
		class Nulls
		{   /**
	Contains null objects.
		*/
			public static Field Field = new Field();
			public static Zone Zone = new Zone();
			public static Sector Sector = new Sector();
			public static Actor Actor = new Actor();

			static public void Setup()
			{
				Field.Name = "0xBAADF00D";
				Zone.Name = "0xDEAD";
				Sector.Name = "0xFF";
				Actor.Name = "580087734";
				Debug.Assert(Nulls.Field.FieldID == 0);
				Debug.Assert(Nulls.Zone.ZoneID == 0);
				Debug.Assert(Nulls.Sector.SectorID == 0);
				Debug.Assert(Nulls.Actor.ActorID == 0);
			}

			static public void SetupAll()
			{
				Nulls.Setup();
			}
		}
	}
}