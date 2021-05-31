using System;
using System.Collections.Generic;

public class Map
{
	private List<MapObject> staticObjects = new List<MapObject>();
	private List<MovingMapObject> movingObjects = new List<MovingMapObject>();

	public void Simulate(double timeDelta) {
		foreach (MovingMapObject obj in movingObjects) {
			obj.Simulate(timeDelta);
		}
	}

	public void AddStaticObject(MapObject mapObject)
	{
		staticObjects.Add(mapObject);
	}

	public void RemoveStaticObject(MapObject mapObject)
	{
		staticObjects.Remove(mapObject);
	}


	public void AddMovingObject(MovingMapObject mapObject)
	{
		movingObjects.Add(mapObject);
	}

	public void RemoveMovingObject(MovingMapObject mapObject)
	{
		movingObjects.Remove(mapObject);
	}

	public void AddRandomMovingObject()
	{
		Random random = new Random();
		int randomNumber = random.Next() % 4;

		MovingMapObject newObject;
		switch (randomNumber) {
			case 0:
				newObject = new Glider((random.Next() % 1000).ToString(), new Position(0, random.NextDouble() % 100), 100, Math.PI / 2, 10000);
				break;
			case 1:
				newObject = new Airplane((random.Next() % 1000).ToString(), new Position(random.NextDouble() % 100, 0), 250, 0, 30000);
				break;
			case 2:
				newObject = new Helicopter((random.Next() % 1000).ToString(), new Position(100, random.NextDouble() % 100), 50, 3*Math.PI / 4, 5000);
				break;
			default:
				newObject = new Balloon((random.Next() % 1000).ToString(), new Position(random.NextDouble() % 100, 100), 10, Math.PI, 2000);
				break;
		}


		movingObjects.Add(newObject);
	}
}


