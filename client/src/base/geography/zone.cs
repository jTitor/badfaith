/**
 */
using System;
using System.Collections.Generic;
using BadFaith.Geography.Fields;

namespace BadFaith.Geography
{
	public class Zone
	{
		//TODO: add fields!

		/**
		The table of all zones in use.
		Each zone has an ID that is also its index into this array.
		All[0] is a null element that isn't connected to anything and can't be entered.
		*/
		//TODO
		private static List<Zone> _all = new List<Zone>();
		public static List<Zone> All { get { return _all; } }
		public static void InitZones()
		{
			throw new NotImplementedException("Implement null element initialization");
		}

		/**
		One-way connections between zones.
		The index is the origin zone's ID, and the result is a list of zone Ids
		that the zone is connected to, indexed by north/south/east/west;
		You should use Zone.addLink to create links, but
		there's no reason you couldn't hand-generate links either.
		*/
		//TODO
		private static List<List<Zone>> sLinkLookup = new List<List<Zone>>();

		public string Name;
		public List<Field> Fields = new List<Field>();
		public int ZoneId;
		public int OwningSectorId = 0;
		//The N/S/E/W gates.
		public Gate[] Gates;

		public Zone()
		{
			Name = "ZONE_NAME_UNSET";
			//The fields contained by this zone.
			ZoneId = Zone.All.Count;
			Zone.All.Add(this);
			//The N/S/E/W gates.
			Gates = new Gate[] { new Gate(), new Gate(), new Gate(), new Gate() };
			foreach (Gate gate in Gates)
			{
				AddField(gate);
			}
		}

		/**
		Makes the given field a member of this zone.
		*/
		public void AddField(Field field)
		{
			throw new NotImplementedException();
			// assert isinstance(field, Field)
			field.OwningZoneId = ZoneId;
			//Fix up any reverse-lookup tables.
			Fields.Add(field);
			//throw new NotImplementedException()
		}

		/**
		Lists all of the zones reachable from this zone.
		*/
		public List<Zone> ListNeighbors()
		{
			throw new NotImplementedException();

			// throw new NotImplementedException()
		}

		/**
		Adds a link between two zones, if it doesn't already exist. This zone's `direction` gate will connect to
			destinationZone's opposite direction gate.
		Raises:
			* WorldGenError if the origin zone already has a link in the given direction.
			* WorldGenError if twoWay is True and the destination zone has
			a link in the opposite direction.
		*/
		public void LinkTo(Zone destinationZone, Direction direction)
		{
			// //Connect the gates so the zones can reach each other.
			Gate sourceGate = Gates[direction.Value];
			Gate destinationGate = destinationZone.Gates[direction.Opposite().Value];
			sourceGate.LinkTo(destinationGate);

			// //Fix up any neighbor tables.
			throw new NotImplementedException();
		}

		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", Sector.All[OwningSectorId].FullName(), Name);
			}
		}
	}
}