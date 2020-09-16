using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Public Variables
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
        zoomOutMax = 30;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ZoomInOut(float moveDist)
    {
        mainCamera.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - moveDist, zoomOutMin, zoomOutMax);
    }

    public void Move(Vector3 newPos)
    {
      transform.position += -newPos * Time.deltaTime * cameraMoveSpeed;
    }

    public float getOrthographicSize()
    {
        return mainCamera.orthographicSize;
    }



}
