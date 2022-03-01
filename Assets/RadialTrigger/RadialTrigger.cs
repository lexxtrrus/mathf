using UnityEditor;
using UnityEngine;

namespace RadialTrigger
{
    public class RadialTrigger : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float radius;

        private void OnDrawGizmos()
        {
            Vector3 direction = target.position - transform.position;
            var sqrt = Mathf.Sqrt( Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        
            Handles.color = Color.red;
            if (radius > sqrt) // Mathf.Pow(radius, 2) < direction.sqrMagnitude
            {
                Handles.color = Color.green;
            }
            Handles.DrawWireDisc(transform.position, transform.forward, radius);
        
        
        }
    }
}
