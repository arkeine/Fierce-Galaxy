using UnityEngine;
using System.Collections;

public class animationSphere : MonoBehaviour {
    public float shiverFactor = 0.2f;
    //private int x;

    // Use this for initialization
    void Start () {
      //  x = 1;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += new Vector3(0.1f*Mathf.Sin(shiverFactor * x++), 0.1f * Mathf.Sin(shiverFactor * x++), 0.1f*Mathf.Sin(shiverFactor * x++)) * Time.deltaTime;

        //transform.position += new Vector3(0, 1, 0) * Mathf.Sin(shiverFactor * x++) * Time.deltaTime;
        
        //if (x > 10000) x = 1;
    }
}
