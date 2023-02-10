using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Utils
{
    public static class Extentions
    {
        private const float EqualityThreshold = 0.0000001f;

        public static bool IsEqual(this float a, float b)
        {
            return Mathf.Abs(a - b) <= EqualityThreshold;
        }

        public static bool IsEqual(this Vector2 a, Vector2 b)
        {
            return (a - b).sqrMagnitude <= EqualityThreshold;
        }

        public static Vector3 AsUnityVector(this Vector3Data vector3Data)
        {
            return new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);
        }

        public static Vector3Data AsVectorData(this Vector3 vector)
        {
            return new Vector3Data(vector.x, vector.y, vector.z);
        }

        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }

        public static T ToDeserialized<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}