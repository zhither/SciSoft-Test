namespace CSharpTest.Shapes
{
    public interface ICanvas
    {
        void Draw(Triangle triangle);
        void Draw(Rectangle rectangle);
        void Draw(Circle circle);
    }
}
