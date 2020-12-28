using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
    private Transform Target;
    private Vector3 offset;
    private float smoothSpeed = 0.1f;

        private void Start()
        {
            Target = TankService.Instance.playerController.GetComponent<Transform>();
            offset = transform.position - Target.position;
        }

        private void LateUpdate()
        {
        if (Target != null)
        {
            //Vector3 DesiredPos = Target.position + offset;
            //Vector3 SmoothedPos = Vector3.Lerp(transform.position, DesiredPos, smoothSpeed);
            transform.position = Target.position + offset;
        }
        }
    }
