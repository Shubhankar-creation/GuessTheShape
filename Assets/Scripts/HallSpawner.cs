using UnityEngine;

public class HallSpawner : MonoBehaviour
{

    [SerializeField] GameObject hallPrefab;
    [SerializeField] GameObject hallSpawnLoc;

    private float hallPosition = 110f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hall"))
        {
            Destroy(other.gameObject);
            instantiateHall();   
        }
    }
    void instantiateHall()
    {
        GameObject hallClones = Instantiate(hallPrefab, new Vector3(0f, 0f, hallPosition), Quaternion.identity) as GameObject;
        hallClones.transform.parent = hallSpawnLoc.transform;
        hallPosition += 20;
    }
}
    
