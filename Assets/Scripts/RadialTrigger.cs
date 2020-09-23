using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace MathNStuff
{
    public class RadialTrigger : MonoBehaviour
    {
        [SerializeField] private float CircleRadius = 5.0f;

        public Transform PointForTriggerCheck;

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            float distance = Vector2.Distance(transform.position, PointForTriggerCheck.position);
            bool isInside = distance < CircleRadius;
            Handles.color = isInside ? Color.green : Color.red;
            Handles.DrawWireDisc(transform.position, Vector3.forward, CircleRadius);
        }
        #endif
    }
}

