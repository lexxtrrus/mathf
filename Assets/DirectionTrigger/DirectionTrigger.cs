using System;
using UnityEditor;
using UnityEngine;

namespace DirectionTrigger
{
    public class DirectionTrigger : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float threshfold;
        
        private void OnDrawGizmos()
        {
            var direction = (target.position - transform.position).normalized;
            
            var angle = transform.right.x * direction.x + transform.right.y * direction.y;
            //angle = Vector3.Dot(transform.right, direction);

            Gizmos.color = Color.red;
            if (angle > threshfold) { Gizmos.color = Color.green; }
            Gizmos.DrawRay(transform.position, transform.right);
        }
    }
}
