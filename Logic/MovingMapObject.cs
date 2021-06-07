using System;
using System.Collections.Generic;

public enum Status
{
	Safe, InDanger, Collided
}

[Serializable()]
public class MovingMapObject : MapObject
{
	private double speed;
	private double heading;
	private double altitude;

	private double acceleration;
	private double climbRate;
	private double turnRate;

	private List<Position> route = new List<Position>();

	private Status status = Status.Safe;

	private static Random random = new Random();

	public MovingMapObject(String name, Position position, double speed, double heading, double altitude, double acceleration, double climbRate, double turnRate) : base(name, position)
	{
		if (speed < 0) throw new WrongConstructorValue("Speed lower than 0. ", speed);
		if (heading < 0) throw new WrongConstructorValue("Heading lower than 0. ", heading);
		if (altitude < 0) throw new WrongConstructorValue("Altitude lower than 0. ", altitude);

		this.speed = speed;
		this.heading = heading;
		this.altitude = altitude;
		this.acceleration = acceleration;
		this.climbRate = climbRate;
		this.turnRate = turnRate;

		route.Add(new Position(random.Next(25, 75), random.Next(25, 75)));
		route.Add(new Position(random.Next(0,2) * 100, random.Next(0, 2)*100));
	}

	public void SetNewRoute(List<Position> newRoute) {
		route = newRoute;
	}

	public void SetStatus(Status newStatus) {
		status = newStatus;
	}

	public Status GetStatus()
	{
		return status;
	}

	public double GetAltitude()
	{
		return altitude;
	}

	public double GetHeading()
	{
		return heading;
	}
	public double GetSpeed()
	{
		return speed;
	}

	public List<Position> GetRoute() {
		return route;
	}

	public void Simulate(double timeDelta) {

		if (route.Count != 0 && Position.CalculateDistance(GetPosition(), route[0]) < 2.0) {
			route.RemoveAt(0);
			if (route.Count == 0) {
				return;
			}
		}

		if (route.Count != 0)
		{
			Position nextPosition = route[0];

			//Wyznaczanie nowego kierunku lotu zgodnie z czasem jaki upłyną od ostatniej symulacji

			double targetHeading = Position.CalculateHeading(GetPosition(), nextPosition);

			if (Math.Abs(heading - targetHeading) < turnRate * timeDelta)
			{
				heading = targetHeading;
			}

			else
			{
				if (Math.Abs(heading - targetHeading) > Math.PI)
				{
					if (heading > Math.PI)
					{
						targetHeading += Math.PI * 2;
					}
					else
					{
						targetHeading -= Math.PI * 2;
					}
				}
				heading += turnRate * timeDelta * -Math.Sign(heading - targetHeading);
			}

			if (heading < 0)
			{
				heading += 2 * Math.PI;
			}
			else if (heading > Math.PI * 2)
			{
				heading %= Math.PI;
			}
		}

		//Przesuwanie statku na mapie zgodnie z wyznaczonym kierunkiem
		position.Tranlate(Math.Sin(heading) * speed * timeDelta, Math.Cos(heading) *speed*timeDelta);
	}
}

