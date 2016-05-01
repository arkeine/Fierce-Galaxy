using UnityEngine;
using System.Collections;
using System;

public class testSphere : MonoBehaviour {
    
    public GameObject sphere;
    public GameObject plan;
    public GameObject connection;

    // Use this for initialization
    void Start () {
        Instantiate(plan);

        Vector3 sphere1Coord = Vector3.zero;
        Vector3 sphere2Coord = new Vector3(8,0,4);
        Vector3 sphere3Coord = new Vector3(2, 0, -4);
        Instantiate(sphere, sphere1Coord, Quaternion.identity);
        Instantiate(sphere, sphere2Coord, Quaternion.identity);
        Instantiate(sphere, sphere3Coord, Quaternion.identity);

        connectSpheres(sphere1Coord, sphere2Coord);
        connectSpheres(sphere1Coord, sphere3Coord);

        initSphereBehavior();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Instantiate(sphere, new Vector3(2,2,2), Quaternion.identity);
                //Destroy((GameObject)hit);

                print(hit.transform.position);
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }
    }

    void connectSpheres(Vector3 sphere1Coord, Vector3 sphere2Coord)
    {
        Vector3 connectionDirection = sphere1Coord - sphere2Coord;
        Vector3 connectionCenter = (sphere1Coord + sphere2Coord) / 2;

        var connector = Instantiate(connection, connectionCenter, Quaternion.LookRotation(connectionDirection)) as GameObject;
        connector.transform.localScale = new Vector3(1, 1, connectionDirection.magnitude/2);

        
    }

    private void initSphereBehavior()
    {
        
    }
}
