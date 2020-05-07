using System;
using System.Numerics;
using System.Diagnostics;
using BHRT.Raytracing;

namespace BHRT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading textures..");
            TextureMap map = new TextureMap(20, "Assets/dcc885s-30cefd70-38d0-45b0-b5fa-d338081f4d9b.png");
            Screen screen = new Screen(0.5f, 0.5f, 0.2f, 2000, 2000, new Vector3(10, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0));
            IRaytracer raytracer = new CPURaytracer(map, screen, 0.05f);
            Console.Write("Raytracing.. ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            raytracer.Raytrace();
            stopwatch.Stop();
            Console.WriteLine($"took {stopwatch.ElapsedMilliseconds} ms.");
            Console.WriteLine("Rendering..");
            var result = raytracer.Render();
            result.Save("blackhole.bmp");
            Console.ReadKey();
        }
    }
}
