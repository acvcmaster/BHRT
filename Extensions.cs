using System.Numerics;
using static System.Math;

namespace BHRT
{
    public static class Extensions
    {
        public static Vector3 Normalize(this Vector3 @vector)
        {
            Vector3 result = vector / vector.Length();
            return result;
        }
    }
}