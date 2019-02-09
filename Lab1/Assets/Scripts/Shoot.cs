using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject VRcamera;
    int force = 50;
    [SerializeField] TextMeshProUGUI tm;
    [SerializeField] LineRenderer line;
    [SerializeField] int aimSpeed = 10;
    float x_rotation;
    float y_rotation;
    float cam_x;
    float cam_y;
    bool x = false;
    void Start()
    {
        
        x_rotation = line.transform.rotation.x;
        y_rotation = line.transform.rotation.y;

       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("p")) // set HMD aim
        {
            x = true; 
        }
        else if (Input.GetKey("o")) // set keyboard aim
        {
            x = false;
        }

        cam_x = VRcamera.transform.rotation.x * 60;
        cam_y = VRcamera.transform.rotation.y * 60;

        Vector3 c = new Vector3 (cam_x, cam_y, 0.0f);

        if (Input.GetKey("w"))
        {
            print("translation up");
            x_rotation -= aimSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            print("translation down");
            x_rotation += aimSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            print("translation left");
            y_rotation -= aimSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            print("translation right");
            y_rotation += aimSpeed * Time.deltaTime;
        }
        Vector3 aim = new Vector3(x_rotation, y_rotation, 0.0f);
        if (x)
        {
            gameObject.transform.rotation = Quaternion.Euler(c);
        }
        else if (!x)
        {
            gameObject.transform.rotation = Quaternion.Euler(aim);
        }
        if (Input.GetKeyDown("f"))
        {
            print("fire!");
            Debug.Log(x_rotation);
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * force;
            Object.Destroy(line);
        }
        if(Input.GetKeyDown("z"))
        {
            if (force < 100)
            {
                force = force + 10;
            }
        }
        else if (Input.GetKeyDown("x"))
        {
            if (force > 10)
            {
                force = force - 10;
            }
        }
        tm.text = "Force: " + force + "%";
    }
}
