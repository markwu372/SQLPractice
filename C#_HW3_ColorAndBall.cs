namespace System;

public class Color
{
    private byte red { get; set; }
    private byte green{ get; set; }
    private byte blue{ get; set; }
    private byte alpha { get; set; }

    public Color(byte red, byte green, byte blue, byte alpha)
    {
        this.red = red;
        this.blue = blue;
        this.green = green;
        this.alpha = alpha;
    }
    
    public Color(byte red, byte green, byte blue)
    {
        this.red = red;
        this.blue = blue;
        this.green = green;
        alpha = 255;
    }

    public double GetGrayValue()
    {
        return (red + green + blue) / 3.0;
    } 
}

public class Ball
{
    private Color color;
    private double size;
    private int numOfThrow;

    public Ball(Color color, double size, int numOfThrow)
    {
        this.color = color;
        this.size = size;
        this.numOfThrow = numOfThrow;
    }

    public void Pop()
    {
        this.size = 0;
    }

    public void ThrowBall()
    {
        if (numOfThrow == 0)
        {
            numOfThrow++;
        }
    }

    public int GetNumOfThrow()
    {
        return numOfThrow;
    }

}
