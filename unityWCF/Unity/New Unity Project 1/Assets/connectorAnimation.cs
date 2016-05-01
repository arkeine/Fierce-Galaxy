using UnityEngine;
using System.Collections;

public class connectorAnimation : MonoBehaviour {

    public GameObject sphere;

    private GameObject workingSphere;
    private Vector3 direction;
    private float length;
    private Vector3 currentPos;
    private Vector3 start;

    public connectorAnimation(Vector3 start, Vector3 stop)
    {
        workingSphere = Instantiate(sphere, start, Quaternion.identity) as GameObject;
        direction = stop - start;
        length = direction.magnitude;
        currentPos = start;
        this.start = start;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (workingSphere != null)
        {
            Vector3 move = direction * Time.deltaTime;
            currentPos += move;
            Vector3 diff = currentPos - start;

            if (diff.magnitude < length)
            {
                workingSphere.transform.Translate(move);
            }
            else
            {
                workingSphere.transform.position = start;
                currentPos = start;
            }
        }
    }
}
