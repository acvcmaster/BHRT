using System.Threading.Tasks;
using System.Linq;
using System.Numerics;
using static System.Math;
using System.Drawing;

namespace BHRT.Raytracing
{
    public class CPURaytracer: IRaytracer
    {
        public TextureMap TextureMap { get; }
        public Screen Screen { get; }
        public float Step { get; }
        private Lightray[] Rays { get; }

        public CPURaytracer(TextureMap textureMap, Screen screen, float step)
        {
            TextureMap = textureMap;
            Screen = screen;
            Step = step;
            Rays = screen.GetLightrays().ToArray();
        }

        public void Raytrace()
        {
            Parallel.For(0, Rays.Length, (i) =>
            {                
                while (Rays[i].Radius > 1 && Rays[i].Radius < TextureMap.Radius)
                {
                    var radius = Rays[i].Position.Length();
                    var h2 = Vector3.Cross(Rays[i].Position, Rays[i].Velocity).LengthSquared();
                    var accel = (float)(-1.5 * h2 / (radius * radius * radius * radius * radius)) * Rays[i].Position;

                    Rays[i].Position += Rays[i].Velocity * Step;
                    Rays[i].Velocity += accel * Step;
                }

                if (Abs(Rays[i].Radius - TextureMap.Radius) <= 10 * Step)
                    Rays[i].Color = TextureMap.ColorAt(Rays[i].Position);
            });
        }

        public Bitmap Render()
        {
            var result = new Bitmap(Screen.PSize.Width, Screen.PSize.Height);
            foreach (var ray in Rays)
                result.SetPixel(ray.X, ray.Y, ray.Color);
            return result;
        }
    }
}