using UnityEngine;
using System.Collections;

public class connectorAnimation : ScriptableObject{

    private Vector3 direction;
    private float length;
    private Vector3 currentPos;
    private Vector3 start;

    public connectorAnimation(Vector3 start, Vector3 stop)
    {        
        direction = stop - start;
        length = direction.magnitude;
        currentPos = start;
        this.start = start;
    }

    public void move(GameObject workingSphere)
        {
            Vector3 move = direction * Time.deltaTime;
            currentPos += move;
            Vector3 diff = currentPos - start;

            if (diff.magnitude<length)
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
