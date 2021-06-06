using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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
			objA.SetStatus(Status.Safe);
			foreach (MovingMapObject objB in movingObjects)
			{
				if (!objA.Equals(objB))
				{
					if (Position.CalculateDistance(objA.GetPosition(), objB.GetPosition()) < 1.0 && Math.Abs(objA.GetAltitude() - objB.GetAltitude()) < 100)
					{
						objA.SetStatus(Status.Collided);

					}
					else if (Position.CalculateDistance(objA.GetPosition(), objB.GetPosition()) < 10.0 && Math.Abs(objA.GetAltitude() - objB.GetAltitude()) < 2000)
					{
						if (objA.GetStatus() == Status.Safe)
						{
							objA.SetStatus(Status.InDanger);
						}
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

	public void Save(string fileName)
	{
		Stream config = File.Create(fileName);
		BinaryFormatter serializer = new BinaryFormatter();
		try
		{
			serializer.Serialize(config, this);
		}
		catch (SerializationException e)
		{
			Console.WriteLine("Failed to serialize. Reason: " + e.Message);
			throw;
		}
		finally
		{
			config.Close();
		}
	}

	public void Load(string fileName)
	{
		Map _map = new Map();
		if (File.Exists(fileName))
		{
			Stream config = File.OpenRead(fileName);
			BinaryFormatter deserializer = new BinaryFormatter();
			try
			{
				_map = (Map)deserializer.Deserialize(config);
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
				throw;
			}
			finally
			{
				config.Close();
			}
			this.movingObjects = _map.movingObjects;
			this.staticObjects = _map.staticObjects;

		}
	}



}


