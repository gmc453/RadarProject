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

	private Stack<RouteSegment> route = new Stack<RouteSegment>();

	private Status status = Status.Safe;

	private static Random random = new Random();

	public MovingMapObject(String name, Position position, double speed, double heading, double altitude, double acceleration, double climbRate, double turnRate) : base(name, position)
	{
		this.speed = speed;
		this.heading = heading;
		this.altitude = altitude;
		this.acceleration = acceleration;
		this.climbRate = climbRate;
		this.turnRate = turnRate;

		route.Push(new RouteSegment(new Position(random.Next(25, 75), random.Next(25, 75)), new Position(random.Next(0,2) * 100, random.Next(0, 2)*100),speed*(1+(random.NextDouble()-0.5f)/5), altitude * (1 + (random.NextDouble() - 0.5f) / 5)));
		route.Push(new RouteSegment(position, route.Peek().GetOrigin(), speed*(1+(random.NextDouble()-0.5f)/5), altitude * (1 + (random.NextDouble() - 0.5f) / 5)));
	}

	public void SetNewRoute(Stack<RouteSegment> newRoute) {
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

	public Stack<RouteSegment> GetRoute() {
		return route;
	}

	public void Simulate(double timeDelta) {
		if (route.Count == 0)
		{
			return;
		}
		if (Position.CalculateDistance(GetPosition(), route.Peek().GetDestination()) < 6.0) {
			route.Pop();
			if (route.Count == 0) {
				return;
			}
		}

		RouteSegment segment = route.Peek();

		double targetHeading = Position.CalculateHeading(GetPosition(), segment.GetDestination());

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
		
			
		

		if (heading < 0) {
			heading += 2 * Math.PI;
		} else if (heading>Math.PI*2) {
			heading %= Math.PI;
		}
		
		if (Math.Abs(speed - segment.GetTargetSpeed()) < acceleration * timeDelta)
		{
			speed = segment.GetTargetSpeed();
		}
		else
		{
			speed += acceleration * timeDelta * -Math.Sign(speed - segment.GetTargetSpeed());
		}

		if (Math.Abs(altitude - segment.GetTargetAltitude()) < climbRate * timeDelta)
		{
			altitude = segment.GetTargetAltitude();
		}
		else
		{
			altitude += climbRate * timeDelta * -Math.Sign(altitude - segment.GetTargetAltitude());
		}

		position.Tranlate(Math.Sin(heading) * speed * timeDelta, Math.Cos(heading) *speed*timeDelta);
	}
}

