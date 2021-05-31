using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private int currID = 0;
    private int initalID = 0;
    private void OnTriggerEnter(Collider other)
    {
        currID = other.gameObject.GetInstanceID();

        if(currID != initalID)
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

            initalID = currID; ;
        }

        
    }
}
