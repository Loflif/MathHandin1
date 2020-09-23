using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    [SerializeField] private float CircleRadius = 5.0f;
    private void Update()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, CircleRadius);
    }
}
