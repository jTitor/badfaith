/**
 */
using System;
using System.Collections.Generic;

namespace BadFaith
{
	class Zone
	{
		//TODO: add fields!

		/**
		The table of all zones in use.
		Each zone has an ID that is also its index into this array.
		All[0] is a null element that isn't connected to anything and can't be entered.
		*/
		//TODO
		private List<Zone> _all = new List<Zone>();
		public List<Zone> All { get { return _all; } }
		public void InitZones()
		{
			throw new NotImplementedException("Implement null element initialization");
		}

		/**
		One-way connections between zones.
		The index is the origin zone's ID, and the result is a list of zone IDs
		that the zone is connected to, indexed by north/south/east/west;
		You should use Zone.addLink to create links, but
		there's no reason you couldn't hand-generate links either.
		*/
		//TODO
		//#_LinkLookup = 

		public Zone()
		{
			throw new NotImplementedException();
			// self.name = "ZONE_NAME_UNSET"
			// #The fields contained by this zone.
			// self.fields = []
			// self.zoneID = len(Zone.All)
			// Zone.All.append(self)
			// self.owningSectorID = 0
			// #The N/S/E/W gates.
			// self.gates = (Gate(), Gate(), Gate(), Gate())
			// for gate in self.gates:
			// 	self.addField(gate)
		}

		/**
		Makes the given field a member of this zone.
		*/
		public void AddField(Field field)
		{
			throw new NotImplementedException();
			// assert isinstance(field, Field)
			// field.owningZoneID = self.zoneID
			// #Fix up any reverse-lookup tables.
			// self.fields.append(field)
			// #raise NotImplementedError
		}

		/**
		Lists all of the zones reachable from this zone.
		*/
		public List<Zone> ListNeighbors()
		{
			throw new NotImplementedException();

			// raise NotImplementedError
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
			throw new NotImplementedException();
			// assert isinstance(destinationZone, Zone)
			// assert isinstance(direction, Direction)

			// #Connect the gates so the zones can reach each other.
			// sourceGate = self.gates[direction.value]
			// destinationGate = destinationZone.gates[Directions.opposite(direction).value]
			// sourceGate.linkTo(destinationGate)

			// #Fix up any neighbor tables.
			// #raise NotImplementedError
		}

		public string FullName
		{
			get
			{
				throw new NotImplementedException();
				// return "{0} {1}".format(Sector.All[self.owningSectorID].fullName(), self.name)
			}
		}
	}
}