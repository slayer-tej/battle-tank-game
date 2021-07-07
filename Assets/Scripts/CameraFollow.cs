using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform Target;

        Vector3 offset;

        private void Start()
        {
            offset = transform.position - Target.position;
        }

        private void LateUpdate()
        {
        if (Target != null)
        {
            transform.position = Target.position + offset;
        }
        }
    }
