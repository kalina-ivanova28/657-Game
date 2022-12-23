using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;
    public float smoothSpeed = 1f;


    // Update is called once per frame

    private void LateUpdate() {

        Vector3 desiredPosition = cameraPosition.position;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = desiredPosition;
    }
}
