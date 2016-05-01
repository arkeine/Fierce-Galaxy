using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class game : MonoBehaviour {
    
    public GameObject sphere;
    public GameObject plan;
    public GameObject connection;

    public static List<GameObject> connections;

    // Use this for initialization
    void Start () {
        Instantiate(plan);

        Vector3 sphere1Coord = Vector3.zero;
        Vector3 sphere2Coord = new Vector3(8, 0, 4);
        Vector3 sphere3Coord = new Vector3(2, 0, -4);
        Vector3 sphere4Coord = new Vector3(-6, 0, -4);
        Vector3 sphere5Coord = new Vector3(-2, 0, -4);
        Instantiate(sphere, sphere1Coord, Quaternion.identity);
        Instantiate(sphere, sphere2Coord, Quaternion.identity);
        Instantiate(sphere, sphere3Coord, Quaternion.identity);
        Instantiate(sphere, sphere4Coord, Quaternion.identity);
        Instantiate(sphere, sphere5Coord, Quaternion.identity);

        connectSpheres(sphere1Coord, sphere2Coord);
        connectSpheres(sphere1Coord, sphere3Coord);
        connectSpheres(sphere2Coord, sphere3Coord);
        connectSpheres(sphere1Coord, sphere4Coord);
        connectSpheres(sphere4Coord, sphere5Coord);

    }

    // Update is called once per frame
    void Update () {
        
    }

    void connectSpheres(Vector3 sphere1Coord, Vector3 sphere2Coord)
    {
        Vector3 connectionDirection = sphere1Coord - sphere2Coord;
        Vector3 connectionCenter = (sphere1Coord + sphere2Coord) / 2;

        var connector = Instantiate(connection, connectionCenter, Quaternion.LookRotation(connectionDirection)) as GameObject;
        connector.transform.localScale = new Vector3(1, 1, connectionDirection.magnitude/2);

        
    }
    
}
