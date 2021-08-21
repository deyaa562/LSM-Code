using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static CameraController _Instance;

    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
        else if(_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Vector3 camPos = Camera.main.transform.position;
            if(camPos.x == 0.0f)
            {
                Camera.main.transform.position = new Vector3(
                    -19.0f,
                    camPos.y,
                    camPos.z);
            }

            if (camPos.x == -19.0f)
            {
                Camera.main.transform.position = new Vector3(
                    0.0f,
                    camPos.y,
                    camPos.z);
            }
        }
    }
}
