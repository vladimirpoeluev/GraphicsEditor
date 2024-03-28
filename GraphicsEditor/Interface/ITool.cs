using System.Drawing;

namespace GraphicsEditor
{
    enum TypeClick
    {
        Click,
        LongPress,
        DownLeft,
        DownRight,
        UpLeft,
        UpRight,
    }
    internal interface ITool
    {
        void Draw(Bitmap bmp, Point p, TypeClick type);
    }
}
