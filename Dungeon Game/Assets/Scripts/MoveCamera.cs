using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform cameraPosition;
    private float cameraY;

    void Start()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("Head").transform;
    }
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
    }
}
