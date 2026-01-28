using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiguelGameDev
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform t)
        {
            for (int i = 0; i < t.childCount; ++i)
            {
                Object.Destroy(t.GetChild(i).gameObject);
            }
        }

        public static void SetPositionX (this Transform t, float x)
        {
            Vector3 position = t.position;
            position = new Vector3(x, position.y, position.z);
            t.position = position;
        }
        
        public static void SetPositionY (this Transform t, float y)
        {
            Vector3 position = t.position;
            position = new Vector3(position.x, y, position.z);
            t.position = position;
        }
        
        public static void SetPositionZ (this Transform t, float z)
        {
            Vector3 position = t.position;
            position = new Vector3(position.x, position.y, z);
            t.position = position;
        }
        
        public static void SetLocalPositionX (this Transform t, float x)
        {
            Vector3 localPosition = t.localPosition;
            localPosition = new Vector3(x, localPosition.y, localPosition.z);
            t.localPosition = localPosition;
        }
        
        public static void SetLocalPositionY (this Transform t, float y)
        {
            Vector3 localPosition = t.localPosition;
            localPosition = new Vector3(localPosition.x, y, localPosition.z);
            t.localPosition = localPosition;
        }
        
        public static void SetLocalPositionZ (this Transform t, float z)
        {
            Vector3 localPosition = t.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, z);
            t.localPosition = localPosition;
        }

        public static void SetScale(this Transform t, float scale)
        {
            t.localScale = new Vector3(scale, scale, scale);
        }

        public static void SetScaleX(this Transform t, float scale)
        {
            t.localScale = new Vector3(scale, t.localScale.y, t.localScale.z);
        }

        public static void SetScaleY(this Transform t, float scale)
        {
            t.localScale = new Vector3(t.localScale.x, scale, t.localScale.z);
        }

        public static void SetScaleZ(this Transform t, float scale)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y, scale);
        }

        public static void LookAtXY(this Transform t, Vector2 position, float speed)
        {
            
            Quaternion q = Quaternion.AngleAxis(t.GetLookAtAngle(position), Vector3.forward);
            t.rotation = Quaternion.Slerp(t.rotation, q, Time.deltaTime * speed);
        }

        public static float GetLookAtAngle(this Transform t, Vector2 position)
        {
            Vector2 vectorToTarget = position - (Vector2)t.position;
            return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        }
    }

}
