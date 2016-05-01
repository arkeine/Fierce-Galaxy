using UnityEngine;
using System.Collections;

public class hoverSphere : MonoBehaviour {
    
    private Color startcolor;

    // Use this for initialization
    void Start()
    {
        startcolor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {        
        GetComponent<Renderer>().material.color = new Color(startcolor.r + 5, startcolor.g + 5, startcolor.b + 5);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }    

}
