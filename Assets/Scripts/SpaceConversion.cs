using UnityEngine;

namespace MathNStuff
{
    public class SpaceConversion : MonoBehaviour
    {
        public Vector2 LocalSpacePoint = Vector2.zero;

        public Transform LocalObjectTransform;
        private void OnDrawGizmos()
        {
            Vector2 objectPosition = transform.position;

            Vector2 right = transform.right;
            Vector2 up = transform.up;
        
            Vector2 LocalToWorld(Vector2 pLocalPoint)
            {
                Vector2 localWorldOffset = right * pLocalPoint.x + up * pLocalPoint.y;

                return (Vector2)transform.position + localWorldOffset;
            }

            Vector2 WorldToLocal(Vector2 pWorldPoint)
            {
                Vector2 relativePoint = pWorldPoint - objectPosition;

                float x = Vector2.Dot(relativePoint, right);
                float y = Vector2.Dot(relativePoint, up);

                return new Vector2(x, y);
            }

            Vector2 worldSpacePoint = LocalToWorld(LocalSpacePoint);
        
            DrawBasisVector(objectPosition, right, up);
            DrawBasisVector(Vector2.zero, Vector2.right, Vector2.up);
        
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(worldSpacePoint, 0.1f);

            LocalObjectTransform.localPosition = WorldToLocal(worldSpacePoint);
        }

    

        void DrawBasisVector(Vector2 pBasisPoint, Vector2 pRight, Vector2 pUp)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(pBasisPoint, pRight);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(pBasisPoint, pUp);
            Gizmos.color = Color.white;
        }
    }
}