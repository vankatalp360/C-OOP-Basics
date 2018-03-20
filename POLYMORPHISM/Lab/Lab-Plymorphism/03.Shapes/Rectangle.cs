public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }
    private double height;
    private double width;

    public double Width
    {
        get
        {
            return width;
        }
        set
        {
            width = Validator.ValidateSide(value);
        }
    }

    public double Height
    {
        get
        {
            return height;
        }
        set
        {
            height = Validator.ValidateSide(value);
        }
    }

    public override double CalculatePerimeter()
    {
        return (Height + Width) * 2;
    }

    public override double CalculateArea()
    {
        return Height * Width;
    }

    public override string Draw()
    {
        return $"{base.Draw()}Rectangle";
    }
}