using System;
using UnityEngine;

namespace Game
{
    public class CameraOrbit : MonoBehaviour
    {
        public Vector3 camRotation;
        public float orbitSpeed, orbitDampening;
        public float maxVal;
        public Transform target;  
        [Range(-10f,3)] public float minDistance = 1.0f; 
        [Range(3f,10f)] public float maxDistance = 10.0f; 
        public float zoomSpeed = 1.0f;
        [Range(-360, 360)]public float xMinLimit = -45f;
        [Range(-360, 360)]public float xMaxLimit = 45f;
        internal float Distance = 0.0f; 
        internal float TargetDistance = 0.0f; 
        internal Vector3 DistancePosition; 
        internal Vector3 TargetPosition;
        void Start()
        {
            var targetPosition = target.position;
            TargetPosition = targetPosition;
            var position = transform.position;
            DistancePosition = position;
            DistancePosition = (position - targetPosition).normalized * Distance;
            target.transform.position = TargetPosition + DistancePosition;
            TargetDistance = Vector3.Distance(TargetPosition, position);
        }
        float _prevDistance;
        void Update()
        {
            Orbit();
        }
        void Orbit(){
            if (Input.GetMouseButton(1))
            {
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    camRotation.x += Input.GetAxis("Mouse X") * orbitSpeed * Time.deltaTime ;
                    camRotation.y -= Input.GetAxis("Mouse Y") * orbitSpeed * Time.deltaTime ;
                }
                if (Input.GetAxis("Mouse X") > maxVal)
                    camRotation.x = maxVal;
                if (Input.GetAxis("Mouse Y") > maxVal)
                    camRotation.y = maxVal;
                camRotation.y  = ClampAngle(camRotation.y, xMinLimit, xMaxLimit);
                transform.rotation  = Quaternion.Euler(camRotation.y, camRotation.x, 0);
            }

        }

        private void LateUpdate()
        {
            Distance = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            Distance = Mathf.Clamp(Distance, minDistance, maxDistance);
            var setter = target.transform.localPosition +  new Vector3(0, 0, Distance);
            target.transform.SetLocalPositionAndRotation(setter, Quaternion.identity);
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F) angle += 360F;
            if (angle > 360F) angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
    }
}