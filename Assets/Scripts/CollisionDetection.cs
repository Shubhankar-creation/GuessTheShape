using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private int currShapeID = 0;
    private int initalShapeID = 0;

    private int currWallID = 0;
    private int initialWallID = 0;
    private void OnTriggerEnter(Collider other)
    {
        currWallID = gameObject.GetInstanceID();
        currShapeID = other.gameObject.GetInstanceID();

        if(currShapeID != initalShapeID && currWallID != initialWallID)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Collided With Wall");
            }

            else if (other.gameObject.CompareTag("FreeSpace"))
            {
                Debug.Log("Collided with FreeSpace");
            }
            else if (other.gameObject.CompareTag("NO Collision"))
            {
                Debug.Log("points should be awarded");
            }

            initalShapeID = currShapeID;
            initialWallID = currWallID;
        }

        
    }
}
