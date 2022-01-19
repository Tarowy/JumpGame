using UnityEngine;

namespace Players
{
    public class CameraFollow : MonoBehaviour
    {
        public static CameraFollow cameraInfo;
    
        public Transform playerPos;
        public float smoothing;
        private Animator _cameraAnimator;

        public Vector2 minPos;
        public Vector2 maxPos;

        private void Awake()
        {
            _cameraAnimator = transform.GetChild(0).GetComponent<Animator>();
            cameraInfo = this;
        }

        private void LateUpdate()
        {
            if (playerPos != null && (playerPos.position != transform.position))
            {
                var limitPos = playerPos.position + new Vector3(0, 1, 0);
            
                limitPos.x = Mathf.Clamp(limitPos.x, minPos.x, maxPos.x);
                limitPos.y = Mathf.Clamp(limitPos.y, minPos.y, maxPos.y);
                transform.position = Vector3.Lerp(transform.position, limitPos, smoothing);
            }
        }

        public void Shake()
        {
            _cameraAnimator.SetTrigger("shake");
        }

        public void SetCameraPosLimit(Vector2 minPos, Vector2 maxPos)
        {
            
        }
    }
}
