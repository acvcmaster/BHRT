using System.Drawing;
using System.Numerics;
using System.Collections.Generic;

namespace BHRT
{
    public class Screen
    {
        public Size PSize { get; }
        public Vector3 NormalVector { get; }
        public Vector3 XVector { get; }
        public Vector3 YVector { get; }
        public float Width { get; }
        public float Height { get; }
        public float FocalLength { get; }
        public Vector3 Center { get; }
        private Vector3 Origin { get; }
        private Vector3 TopLeft { get; }

        public Screen(float width, float height, float focalLength, int pwidth, int pheight, Vector3 center, Vector3 normalVector, Vector3 xVector)
        {
            Width = width;
            Height = height;
            FocalLength = focalLength;
            PSize = new Size(pwidth, pheight);
            Center = center;

            NormalVector = normalVector.Normalize();
            XVector = xVector.Normalize();
            YVector = Vector3.Cross(normalVector, xVector).Normalize();

            Origin = Center + NormalVector * focalLength;
            TopLeft = Center - (width / 2) * XVector + (height / 2) * YVector;
        }

        public Vector3 GetPoint(int x, int y)
        {
            return TopLeft + ((float)x / (float)PSize.Width) * Width * XVector - ((float)y / (float)PSize.Height) * Height * YVector;
        }

        public Lightray GetLightray(int x, int y) => new Lightray(Origin, (GetPoint(x, y) - Origin).Normalize(), x, y);

        public IEnumerable<Lightray> GetLightrays()
        {
            for (int x = 0; x < PSize.Width; x++)
                for (int y = 0; y < PSize.Height; y++)
                    yield return GetLightray(x, y);
        }
    }
}