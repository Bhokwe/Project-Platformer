using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Who to follow")]
    [SerializeField]private Transform target;

    [Header("Offset Settings")]
    [Range(0f,1f)]
    private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    private void FixedUpdate()
    {
        //when the player dies, the camera should stop following
        if (target == null) return;

        //the place we want to the camera to be
        Vector3 desiredPosition = target.position + offset;

        //smooth movement from current position to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        //new position that is set
        transform.position = smoothedPosition;
    }
}
