using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class transfer : MonoBehaviour {
    private static Vector3? start;
    private static Vector3? stop;

    public GameObject sphere;
    public GameObject workingSphere;
    public connectorAnimation cAnimation;
    

    private static List<connectorAnimation> listConnectorAnimation = new List<connectorAnimation>();

    // Use this for initialization
    void Start () {
        start = null;
        stop = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
        {
            checkWhereButtonReleased();            
        }
        if(workingSphere != null && cAnimation != null)
        {
            cAnimation.move(workingSphere);
        }
    }

    void OnMouseDown()
    {
        start = transform.position;
        print("just start :" + transform.position);
        
    }

    void checkWhereButtonReleased()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                            
                if (start.HasValue)
                {
                    stop = transform.position;
                    if (start != stop)
                    {
                        print("start :" + start);
                        print("stop :" + stop);

                        //do stuff
                        startAnimation((Vector3)start, (Vector3) stop);

                        //put this script in connector as well and treat onMouseDown
                        //créer une liste d'objets static dans la classe Game
                    }

                    start = null;
                    stop = null;
                }
                else
                {
                    
                    print("just stop :" + transform.position);
                    //stop = null;
                }
                
            }
        }
    }

    private void startAnimation(Vector3 start, Vector3 stop)
    {
        cAnimation = new connectorAnimation(start, stop);
        workingSphere = Instantiate(sphere, start, Quaternion.identity) as GameObject;
    }
}
