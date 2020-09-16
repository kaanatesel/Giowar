using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Public Variables
    public GameObject background;
    // Private Variables
    private float cameraMoveSpeed;
    private Camera mainCamera;
    private float zoomOutMin, zoomOutMax;

    // Start is called before the first frame update
    void Start()
    {
        cameraMoveSpeed = 10;
        mainCamera = Camera.main;
        zoomOutMin = 2;
        zoomOutMax = 20;
    }

    void Update()
    {

    }

    public void ZoomInOut(float moveDist)
    {
        mainCamera.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - moveDist, zoomOutMin, zoomOutMax);
    }

    public void Move(Vector3 newPos)
    {
        Vector3 checkV = transform.position - (newPos * Time.deltaTime * cameraMoveSpeed);
        checkV.x = Mathf.Clamp(checkV.x, -25, 25);
        checkV.y = Mathf.Clamp(checkV.y, -25, 25);
        transform.position = checkV;
    }

    public float getOrthographicSize()
    {
        return mainCamera.orthographicSize;
    }



}
