using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[Serializable()]
public class Map
{
	private List<MapObject> staticObjects = new List<MapObject>();
	private List<MovingMapObject> movingObjects = new List<MovingMapObject>();
	const string FileSO = "configSO.bin";
	const string FileMO = "configMO.bin";
	Random random = new Random();

	public void Simulate(double timeDelta) {
		foreach (MovingMapObject obj in movingObjects) {
            if (obj.GetStatus()!=Status.Collided)
			{
				obj.Simulate(timeDelta);
			}
		}

		foreach (MovingMapObject objA in movingObjects)
		{
			foreach (MovingMapObject objB in movingObjects)
			{
				if (objA!=objB) {
					if (Position.CalculateHeading(objA.GetPosition(), objB.GetPosition()) < 1.0 && Math.Abs(objA.GetAltitude() - objB.GetAltitude()) < 100)
					{
						objA.SetStatus(Status.InDanger);
					}
					else if (Position.CalculateHeading(objA.GetPosition(), objB.GetPosition()) < 10.0 && Math.Abs(objA.GetAltitude() - objB.GetAltitude()) < 2000)
					{
						objA.SetStatus(Status.Collided);
					}
					else
					{
						objA.SetStatus(Status.Safe);
					}
				}
			}
		}
	}

	public void AddStaticObject(MapObject mapObject)
	{
		staticObjects.Add(mapObject);
	}

	public List<MapObject> GetStaticObject()
	{
		return staticObjects;
	}

	public void RemoveStaticObject(MapObject mapObject)
	{
		staticObjects.Remove(mapObject);
	}


	public void AddMovingObject(MovingMapObject mapObject)
	{
		movingObjects.Add(mapObject);
	}

	public List<MovingMapObject> GetMovingObjects()
	{
		return movingObjects;
	}

	public void RemoveMovingObject(MovingMapObject mapObject)
	{
		movingObjects.Remove(mapObject);
	}

	public void AddRandomMovingObject()
	{
	
		int randomNumber = random.Next() % 4;

		MovingMapObject newObject;
		switch (randomNumber) {
			case 0:
				newObject = new Glider((random.Next() % 1000).ToString(), new Position(0, random.NextDouble() * 100), 4, Math.PI / 2, 10000);
				break;
			case 1:
				newObject = new Airplane((random.Next() % 1000).ToString(), new Position(random.NextDouble() * 100, 0), 11, 0, 30000);
				break;
			case 2:
				newObject = new Helicopter((random.Next() % 1000).ToString(), new Position(100, random.NextDouble() * 100), 6, 3*Math.PI / 4, 5000);
				break;
			default:
				newObject = new Balloon((random.Next() % 1000).ToString(), new Position(random.NextDouble() * 100, 100), 2, Math.PI, 2000);
				break;
		}


		movingObjects.Add(newObject);
	}

	public void Save(){
		Stream configSaveMO = File.Create(FileMO);
		Stream configSaveSO = File.Create(FileSO);
		BinaryFormatter serializer = new BinaryFormatter();
		serializer.Serialize(configSaveMO, movingObjects);
		serializer.Serialize(configSaveSO, staticObjects);
		configSaveSO.Close();
		configSaveMO.Close();
	}

	public void Load(){
	if(File.Exists(FileMO)){
			Stream configMO = File.OpenRead(FileMO);
			BinaryFormatter deserializer = new BinaryFormatter();
			movingObjects = (List<MovingMapObject>)deserializer.Deserialize(configMO);
			configMO.Close();
		}

		if(File.Exists(FileSO)){
			Stream configSO = File.OpenRead(FileSO);
			BinaryFormatter deserializer = new BinaryFormatter();
			staticObjects = (List<MapObject>)deserializer.Deserialize(configSO);
			configSO.Close();
		}
	}


}

