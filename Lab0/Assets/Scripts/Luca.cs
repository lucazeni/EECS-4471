using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luca : MonoBehaviour {
    [SerializeField] GameObject camera;
    [SerializeField] GameObject ramp;
    [SerializeField] GameObject car;
    bool x;
    bool o;
    bool xaxis;
    bool yaxis;
    bool zaxis;
    [SerializeField] float value = 1.0f;
    [SerializeField] GameObject light;
    float cameraXT;
    float cameraYT;
    float cameraZT;
    
    float cameraXR;
    float cameraYR;
    float cameraZR;

    float carX;
    float carY;
    float carZ;

    float rampX;
    float rampY;
    float rampZ;
    int count = 0;
    float lightRotation;
    Vector3 position;
    // Use this for initialization
    void Start () {
        
        cameraXT = camera.transform.position.x;
        cameraYT = camera.transform.position.y;
        cameraZT = camera.transform.position.z;
        lightRotation = light.transform.rotation.x;
        cameraXR = camera.transform.rotation.x;
        cameraYR = camera.transform.rotation.y;
        cameraZR = camera.transform.rotation.z;

        carX = car.transform.position.x;
        carY = car.transform.position.y;
        carZ = car.transform.position.z;

        rampX = ramp.transform.position.x;
        rampY = ramp.transform.position.y;
        rampZ = ramp.transform.position.z;
    }
	
	// Update is called once per frame
	
        void Update()
        {
            if (Input.GetKeyDown("t"))
            {
                print("translation key");
                x = true;
                o = false;
            }
            else if (Input.GetKeyDown("r"))
            {
                print("rotation key");
                x = false;
                o = false;
            }
            else if (Input.GetKeyDown("l"))
            {
                print("light key");
                xaxis = false;
                yaxis = false;
                zaxis = false;
                o = false;
            }
            else if (Input.GetKeyDown("o"))
            {
            print("light key");
            o = true;
            count++;
            count = count % 2;
            
            }


            if (Input.GetKeyDown("x"))
            {
                xaxis = true;
                yaxis = false;
                zaxis = false;
                print("x axis");
            }
            else if (Input.GetKeyDown("y"))
            {
                xaxis = false;
                yaxis = true;
                zaxis = false;
                print("y axis");
            }
            else if (Input.GetKeyDown("z"))
            {
                xaxis = false;
                yaxis = false;
                zaxis = true;
                print("z axis");
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                //translation
                print("scrolling forward");
                if (x && xaxis && !o)
                {
                    cameraXT = cameraXT + value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                if (x && yaxis && !o)
                {
                    cameraYT = cameraYT + value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                if (x && zaxis && !o)
                {
                    cameraZT = cameraZT + value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                // rotation
                if (!x && xaxis && !o)
                {
                    cameraXR = cameraXR + value;

                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!x && yaxis && !o)
                {
                    cameraYR = cameraYR + value;
                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!x && zaxis && !o)
                {
                    cameraZR = cameraZR + value;
                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!xaxis && !yaxis && !zaxis && !o)
                {
                    print("rotation here light");
                    lightRotation = lightRotation + value;
                    light.transform.rotation = Quaternion.Euler(lightRotation, light.transform.rotation.y, light.transform.rotation.z);
                }
                // car
                if (xaxis && o && count == 1)
                {
                    carX = carX + value;
                    position = new Vector3(carX, carY, carZ);
                    car.transform.position = position;
                }

                 if (yaxis && o && count == 1)
                {
                    carY = carY + value;
                    position = new Vector3(carX, carY, carZ);
                    car.transform.position = position;
                }
                if (zaxis && o && count == 1)
                {
                carZ = carZ + value;
                position = new Vector3(carX, carY, carZ);
                car.transform.position = position;
                }
            // ramp
            if (xaxis && o && count == 0)
            {
                rampX = rampX + value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }

            if (yaxis && o && count == 0)
            {
                rampY = rampY + value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }
            if (zaxis && o && count == 0)
            {
                rampZ = rampZ + value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }


        }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                //translation
                print("scrolling backward");
                if (x && xaxis && !o)
                {
                    cameraXT = cameraXT - value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                if (x && yaxis && !o)
                {
                    cameraYT = cameraYT - value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                if (x && zaxis && !o)
                {
                    cameraZT = cameraZT - value;
                    position = new Vector3(cameraXT, cameraYT, cameraZT);
                camera.transform.position = position;
                }
                // rotation
                if (!x && xaxis && !o)
                {
                    cameraXR = cameraXR - value;

                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!x && yaxis && !o)
                {
                    cameraYR = cameraYR - value;
                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!x && zaxis && !o)
                {
                    cameraZR = cameraZR - value;
                camera.transform.rotation = Quaternion.Euler(cameraXR, cameraYR, cameraZR);
                }
                if (!xaxis && !yaxis && !zaxis && !o)
                {
                    print("rotation here light");
                    lightRotation = lightRotation - value;
                    light.transform.rotation = Quaternion.Euler(lightRotation, light.transform.rotation.y, light.transform.rotation.z);
                }
            // car
            if (xaxis && o && count == 1)
            {
                carX = carX - value;
                position = new Vector3(carX, carY, carZ);
                car.transform.position = position;
            }

            if (yaxis && o && count == 1)
            {
                carY = carY - value;
                position = new Vector3(carX, carY, carZ);
                car.transform.position = position;
            }
            if (zaxis && o && count == 1)
            {
                carZ = carZ - value;
                position = new Vector3(carX, carY, carZ);
                car.transform.position = position;
            }

            if (xaxis && o && count == 0)
            {
                rampX = rampX - value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }

            if (yaxis && o && count == 0)
            {
                rampY = rampY - value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }
            if (zaxis && o && count == 0)
            {
                rampZ = rampZ - value;
                position = new Vector3(rampX, rampY, rampZ);
                ramp.transform.position = position;
            }
        }


        
    }
}
