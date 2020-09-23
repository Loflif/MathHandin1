#if UNITY_EDITOR
#endif
using UnityEngine;

namespace MathNStuff
{
    public class LookTrigger : MonoBehaviour
    {
        [Range(0.0f, 1.0f)]
        [SerializeField] private float LookPrecision = 0.5f;

        public Transform ObjectLooking;
    
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Vector2 center = transform.position;
            Vector2 objectPosition = ObjectLooking.position;
            Vector2 objectLookDirection = ObjectLooking.right;

            Vector2 objectToTriggerDirection = (center - objectPosition).normalized;

            float ODotT = Vector2.Dot(objectToTriggerDirection, objectLookDirection);

            bool isLookingAtTrigger = ODotT >= LookPrecision;
        
            Gizmos.color = isLookingAtTrigger ? Color.green : Color.red;
            Gizmos.DrawLine(objectPosition, objectPosition + objectToTriggerDirection);
        
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(objectPosition, objectPosition + objectLookDirection);
        
        }
#endif
    }
}

