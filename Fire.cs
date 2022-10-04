using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if mouse button down (trigger item)
          if(Input.GetButtonDown("Fire1"))
          {
            //create ray and point it to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //create a sphere gameobject
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //put the sphere where the ray origin is
            sphere.transform.position = ray.origin;
            //put a rigidbody on the sphere and then add a force to it
            sphere.AddComponent<Rigidbody>();
            sphere.GetComponent<Rigidbody>().AddForce(ray.direction * 1000);
            sphere.AddComponent<TrailRenderer>();

          }
    }
}
