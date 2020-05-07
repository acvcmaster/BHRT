using System.Drawing;

namespace BHRT.Raytracing
{
    public interface IRaytracer
    {
        void Raytrace();
        Bitmap Render();
    }
}