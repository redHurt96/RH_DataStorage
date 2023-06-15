using UnityEngine;

namespace RH_Utilities.Extensions
{
    public static class Vector2Extensions
    {
        public static bool ApproximatelyEqual(this Vector2 a, Vector2 b) =>
            a.x.ApproximatelyEqual(b.x)
            && a.y.ApproximatelyEqual(b.y);
    }
}