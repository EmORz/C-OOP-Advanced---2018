using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var square = new Square();
            var rectangle = new Rectangle();

            var editor = new GraphicEditor();
            editor.DrawShape(circle);
            editor.DrawShape(square);
            editor.DrawShape(rectangle);
        }
    }
}
