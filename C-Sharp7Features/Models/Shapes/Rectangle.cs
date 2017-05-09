namespace C_Sharp7Features.Models
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }

        public double Length { get; set; }

        public Rectangle() => Name = "Rectangle";
    }
}