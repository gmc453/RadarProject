using System;

[Serializable()]
public class Position
{
	private double xPosition, yPosition;

	public Position(double xPos, double yPos) {
		xPosition = xPos;
		yPosition = yPos;
	}

	public double GetXPosition()
	{
		return xPosition;
	}

	public double GetYPosition()
	{
		return yPosition;
	}

	public void Tranlate(double deltaX,double deltaY)
	{
		xPosition += deltaX;
		yPosition += deltaY;
	}

	static public double CalculateHeading(Position a,Position b) {
		double x = b.xPosition - a.xPosition;
		double y = b.yPosition - a.yPosition;

		double heading = Math.Abs(Math.Atan2(y, x) - Math.PI)-(Math.PI/2);

        if (heading<0)
        {
			heading = 2 * Math.PI + heading;
        }

		return heading;
	}

	static public double CalculateDistance(Position a, Position b)
	{
		double x = Math.Pow(b.xPosition - a.xPosition,2);
		double y = Math.Pow(b.yPosition - a.yPosition, 2);

		return Math.Sqrt(y+x);
	}
}

