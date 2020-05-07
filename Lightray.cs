using System.Numerics;
using System.Drawing;

namespace BHRT
{
    public struct Lightray
    {
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public float Radius => Position.Length();
        public int X;
        public int Y;
        public Color Color;

        public Lightray(Vector3 position, Vector3 velocity, int x, int y)
        {
            Position = position;
            Velocity = velocity;
            X = x;
            Y = y;
            Color = Color.Black;
        }
    }
}