using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] wallPrefab;
    [SerializeField] GameObject wallParent;
    [SerializeField] Material wallMaterial;

    GameObject wallPos;

    float zPosWall = 40;
    int rand;
    int Currrand = 2;

    MeshRenderer meshRenderWall;


    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            meshRenderWall = wallPrefab[i].GetComponent<MeshRenderer>();
            meshRenderWall.material = wallMaterial;

            wallPos = Instantiate(wallPrefab[i], new Vector3(0f, wallPrefab[i].transform.position.y, zPosWall), Quaternion.identity) as GameObject;
            wallPos.transform.parent = wallParent.transform;
            zPosWall += 60;
        }
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {

            Destroy(other.gameObject);
            rand = GetRandomNumber(Currrand);
            instantiateWall();
        }
    }

    int GetRandomNumber(int Currrand)
    {
        while(rand == Currrand)
        {
            rand = Random.Range(0, wallPrefab.Length);
        }
        return rand;
    }

    void instantiateWall()
    {
        meshRenderWall = wallPrefab[rand].GetComponent<MeshRenderer>();
        meshRenderWall.material = wallMaterial;

        wallPos = Instantiate(wallPrefab[rand], new Vector3(0f, wallPrefab[rand].transform.position.y, zPosWall), Quaternion.identity) as GameObject;
        wallPos.transform.parent = wallParent.transform;
        zPosWall += 40;

        Currrand = rand;
    }
}
