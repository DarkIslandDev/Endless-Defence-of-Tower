using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThiccness = 10f;

    public int yawsSpeed;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 50f;
    public float minZ = 10f;
    public float maxZ = 50f;
    public float minX = 10f;
    public float maxX = 50f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            doMovement = !doMovement;
        }

        if(!doMovement)
        {
            return;
        }

        if(Input.GetKey("d") || Input.GetMouseButton(0) && Input.mousePosition.y <= panBorderThiccness - Input.mousePosition.y)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey("a") || Input.GetMouseButton(0) && Input.mousePosition.y >= Screen.height - panBorderThiccness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey("s") || Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width - panBorderThiccness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey("w") || Input.GetMouseButton(0) && Input.mousePosition.x <= panBorderThiccness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 pos = transform.position;

        pos.y -= scroll * yawsSpeed * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}