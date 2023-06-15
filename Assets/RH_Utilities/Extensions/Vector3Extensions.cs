using UnityEngine;
using static UnityEngine.Random;

namespace RH_Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 AddRandomInBox(this Vector3 origin, Vector3 size) =>
            origin + new Vector3(
                Range(-size.x, size.x),
                Range(-size.y, size.y),
                Range(-size.z, size.z));
        
        public static bool ApproximatelyEqual(this Vector3 a, Vector3 b) =>
            a.x.ApproximatelyEqual(b.x)
            && a.y.ApproximatelyEqual(b.y)
            && a.z.ApproximatelyEqual(b.z);
    }
}