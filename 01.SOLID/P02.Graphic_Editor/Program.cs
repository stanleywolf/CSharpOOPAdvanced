using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var graficEditor = new GraphicEditor();
            graficEditor.DrawShape(new Circle());
            
        }
    }
}
