using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject platform;

    // Update is called once per frame
    void Update()
    {
       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began)
                Instantiate(platform, pos, Quaternion.identity);
        }*/
    }
}
