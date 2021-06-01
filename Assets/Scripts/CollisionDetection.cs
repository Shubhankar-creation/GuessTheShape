using UnityEngine;
using UnityEngine.UI;
public class CollisionDetection : MonoBehaviour
{

    private static int currShapeID ;
    private static int initalShapeID;

    private static int currWallID ;
    private static int initialWallID;

    float points = 0;
    Score score;
    private void Start()
    {
        currShapeID = 0; currWallID = 0; initalShapeID = 0; initialWallID = 0;
        Debug.Log(currShapeID + " " + currWallID + " " + initalShapeID + " " + initialWallID);

        score = GameObject.Find("Canvas").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currWallID = gameObject.GetInstanceID();
        currShapeID = other.gameObject.GetInstanceID();

        if(currShapeID != initalShapeID && currWallID != initialWallID)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                score.Levelscore = -0.1f;
                Debug.Log("Collided with Wall");
                Debug.Log(points);
            }

            else if (other.gameObject.CompareTag("FreeSpace"))
            {
                Debug.Log("Collided with FreeSpace");
                score.Levelscore = -0.1f;
                Debug.Log(points);


            }

            else if (other.gameObject.CompareTag("NO Collision"))
            {
                Debug.Log("points should be awarded");
                score.Levelscore = 0.2f;
                Debug.Log(points);
            }

            initalShapeID = currShapeID;
            initialWallID = currWallID;
        }

        
    }
}
