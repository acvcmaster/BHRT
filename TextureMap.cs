using static System.Math;
using System.Drawing;
using System.Numerics;

namespace BHRT
{
    public class TextureMap
    {
        public double Radius { get; }
        Bitmap InnerImage { get; }
        public int SizeX { get; }
        public int SizeY { get; }

        public TextureMap(double radius, string file)
        {
            Radius = radius;
            InnerImage = new Bitmap(file);
            SizeX = InnerImage.Size.Width;
            SizeY = InnerImage.Size.Height;
        }

        public Color ColorAt(Vector3 position)
        {
            var normal = position.Normalize();
            double u = Atan2(normal.X, normal.Z) / (2 * PI) + 0.5;
            double v = normal.Y * 0.5 + 0.5;
            int U = (int)(u * SizeX) % SizeX;
            int V = (int)(v * SizeY) % SizeY;
            lock (InnerImage)
                return InnerImage.GetPixel(U, V);
        }
    }
}