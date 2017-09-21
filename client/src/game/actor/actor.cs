/**
	actor.cs
	Objects in the game world distinct from terrain that can move.
*/
using System;
using System.Collections.Generic;

namespace BadFaith
{
	struct Actor
	{
		public int ActorId;
		public string Name;
		public int MaxHealth;
		public int MaxArmor;
		public int MaxPsyche;
		public int Health;
		public int Armor;
		public int Psyche;
		public int FieldId;

		/**
		All actors in the game world.
		Element 0 is the null element.
		*/
		private static List<Actor> _all = new List<Actor>();
		public static List<Actor> All { get { return _all; } }

		/**
		Resets the table of all actors
		in the game world.
		 */
		public static void InitActors(int numActors)
		{
			throw new System.NotImplementedException("Implement null element initialization");
		}

		/**
			Moves the actor from their current field
			to the destination field if possible. Does nothing if
			the actor can't actually reach the given field from their
			current field or the actor is already at the given field.

			Returns True if the actor was moved
			to the new field, False otherwise.
		*/
		public static bool MoveToField(List<int> actorIds)
		{
			//TODO: result should really include an ActorId?
			throw new System.NotImplementedException();

			// #You can only go to another field in the same zone.
			// if Field.All[fieldID].owningZoneID != Field.All[self.fieldID].owningZoneID or fieldID == self.fieldID:
			// 	return False
			// 	#warning ("Trying to go to an invalid field!")
			// #Otherwise, set the field.
			// oldField = Field.All[self.fieldID]
			// newField = Field.All[newFieldID]
			// oldField.actors.remove()
			// self.fieldID = newFieldID
			// newField.actors.append()
			// return True
		}

		/**
			Attempts to enter the gate in each actor's field, if they have one.
			Returns true if the given actor entered the gate.
		*/
		public static List<bool> EnterGate(List<int> actorIds)
		{
			//TODO: result should really include an ActorId?
			throw new System.NotImplementedException();

			// field = Field.All[self.fieldID]
			// if field.type != Field.Types.Gate:
			// 	return False
			// self._doFieldChange(field.destinationFieldID)
			// return True
		}

		/**
			Moves the actors in the given direction by
			`length` number of units. If this would
			take it outside the field, the movement is
			clamped to the field's edge instead.
			Returns True if the actor was successfully moved any distance from its prior position.
		*/
		public static List<bool> Move(List<int> actorIds, List<Vector2I> moveVectors)
		{
			throw new System.NotImplementedException();
			// assert isinstance(direction, Direction)
			// field = Field.All[self.fieldID]
			// assert isinstance(field, Field)
			// vertical = 1 if direction.value % 2 == 0 else 0
			// horizontal = 1 if not vertical else 0
			// magnitude = 1 if direction.value | 2 == 0 else -1
			// moveVector = Vector(horizontal, vertical) * magnitude * length
			// newPosition = self.fieldPosition + moveVector
			// #Clamp the position.
			// for i in range(0, 2):
			// 	newPosition.value[i] = max(0, min(newPosition.value[i], field.gridSize-1))
			// self.fieldPosition = newPosition
			// return True
		}

		/**
			Randomly places a new actor.
			Returns: The ActorId of the new actor.
		*/
		private static int doRandomSpawn()
		{
			throw new System.NotImplementedException();

			// actor = Actor()
			// actor.fieldID = random.randint(1, len(Field.All)-1)
			// actor.name = "Nemo {0}".format(actor.fieldID)
			// return actor.actorID
		}

		/**
			Creates a new actor, randomly places it,
			and puts it under control of the given view.
		*/
		public static void RandomSpawnForView(int viewId)
		{
			throw new System.NotImplementedException();
			// actorID = cls._doRandomSpawn()
			// view.controlActor(actorID)
		}

		/**
			Removes the given actors
			from the world.
		*/
		public static void DestroyActors(List<int> actorIds)
		{
			throw new System.NotImplementedException();

			// #No point actually removing a row in the actor table;
			// #instead send the actor to the deadlands.
			// #Since they probably don't have a view controlling them
			// #they won't get updated,
			// #and we can scan the table for inactive actors if we
			// #need to add more.
			// Actor.All[actorID].fieldID = 0
		}

		/**
		Places the given view in a new actor.
		*/
		public static void RespawnView(int viewId)
		{
			throw new System.NotImplementedException();

			// oldActorID = view.controlledActorID
			// cls.randomSpawnForView(view)
			// cls.destroyActor(oldActorID)
		}
	}
}