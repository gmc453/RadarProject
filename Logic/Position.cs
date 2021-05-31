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
}

