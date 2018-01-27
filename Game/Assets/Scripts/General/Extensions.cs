using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATY
{
    public static class Extensions
    {
        public static Vector2 Set_X(this Vector2 vector, float x) { var v = vector; v.x = x; return v; }
        public static Vector2 Set_Y(this Vector2 vector, float y) { var v = vector; v.y = y; return v; }

        public static Vector3 Set_X(this Vector3 vector, float x) { var v = vector; v.x = x; return v; }
        public static Vector3 Set_Y(this Vector3 vector, float y) { var v = vector; v.y = y; return v; }
        public static Vector3 Set_Z(this Vector3 vector, float z) { var v = vector; v.z = z; return v; }

        public static Vector4 Set_X(this Vector4 vector, float x) { var v = vector; v.x = x; return v; }
        public static Vector4 Set_Y(this Vector4 vector, float y) { var v = vector; v.y = y; return v; }
        public static Vector4 Set_Z(this Vector4 vector, float z) { var v = vector; v.z = z; return v; }
        public static Vector4 Set_W(this Vector4 vector, float w) { var v = vector; v.w = w; return v; }

        public static Vector2 Clamp(this Vector2 vector, Vector2 minValues, Vector2 maxValues)
        {
            return new Vector2(
                x: Mathf.Clamp(vector.x, minValues.x, maxValues.x),
                y: Mathf.Clamp(vector.y, minValues.y, maxValues.y));
        }

        public static Vector3 Clamp(this Vector3 vector, Vector3 minValues, Vector3 maxValues)
        {
            return new Vector3(
                x: Mathf.Clamp(vector.x, minValues.x, maxValues.x),
                y: Mathf.Clamp(vector.y, minValues.y, maxValues.y),
                z: Mathf.Clamp(vector.z, minValues.z, maxValues.z));
        }

        public static Vector4 Clamp(this Vector4 vector, Vector4 minValues, Vector4 maxValues)
        {
            return new Vector4(
                x: Mathf.Clamp(vector.x, minValues.x, maxValues.x),
                y: Mathf.Clamp(vector.y, minValues.y, maxValues.y),
                z: Mathf.Clamp(vector.z, minValues.z, maxValues.z),
                w: Mathf.Clamp(vector.w, minValues.w, maxValues.w));
        }

        public static Vector2 ScaleVector(this Vector2 vector, Vector2 scale) { vector.Scale(scale); return vector; }
        public static Vector3 ScaleVector(this Vector3 vector, Vector3 scale) { vector.Scale(scale); return vector; }
        public static Vector4 ScaleVector(this Vector4 vector, Vector4 scale) { vector.Scale(scale); return vector; }

        public static float Clamp(this float value, float min, float max) { return Mathf.Clamp(value, min, max); }
        public static int   Clamp(this int value,   int min,   int max)   { return Mathf.Clamp(value, min, max); }

        public static RaycastHit2D VisibleRaycast(Vector2 origin, Vector2 direction, float distance, LayerMask layerMask)
        {
            Debug.DrawRay(origin, direction * distance, Color.magenta, .5f);
            return Physics2D.Raycast(origin, direction, distance, layerMask);
        }

        public static RaycastHit2D[] VisibleRaycastAll(Vector2 origin, Vector2 direction, float distance, LayerMask layerMask)
        {
            Debug.DrawRay(origin, direction * distance, Color.magenta, .5f);
            return Physics2D.RaycastAll(origin, direction, distance, layerMask);
        }
    }
}