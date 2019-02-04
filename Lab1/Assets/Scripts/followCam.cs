using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    [SerializeField] GameObject ball;
    Vector3 originalPos;
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("g"))
        {
            gameObject.transform.position = ball.transform.position;
        }
        else
        {
            gameObject.transform.position = originalPos;
        }
    }
}
