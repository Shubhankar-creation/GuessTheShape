using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] shapePrefab;
    [SerializeField] GameObject shapeParent;
    [SerializeField] Material[] shapeMaterial;
    GameObject shapePos;

    MeshRenderer meshRenderShape;

    private Touch touch;

    CollisionDetection collDetect;
    PlayerMovement shapeMove;

    private int currInd = 0, randInd = 0, matInd = 0;
    void Start()
    {
        randInd = GenerateRand(currInd);
        shapeMove = gameObject.AddComponent<PlayerMovement>();

        instantiateShape();

        currInd = randInd;

    }

    void Update()
    {
        changeShape();
    }

    void changeShape()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("being clicked");
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {

                    Debug.Log("Raycast");
                    if (hit.collider.tag == "Shapes")
                    {
                        Debug.Log("Shape touched");

                        randInd = GenerateRand(currInd);

                        Destroy(shapePos);
                        instantiateShape();

                        currInd = randInd;

                    }
                }
            }
        }
    }

    int GenerateRand(int currInd)
    {
        while (randInd == currInd)
        {
            randInd = Random.Range(0, shapePrefab.Length);
        }

        if (matInd == 0)
        {
            matInd = 1;

        }
        else
        {
            matInd = 0;
        }

        return randInd;
    }

    void instantiateShape()
    {

        meshRenderShape = shapePrefab[randInd].GetComponent<MeshRenderer>();
        meshRenderShape.material = shapeMaterial[matInd];

        shapePos = Instantiate(shapePrefab[randInd], transform.position, Quaternion.identity) as GameObject;

        collDetect = shapePos.AddComponent<CollisionDetection>();


        shapePos.transform.parent = shapeParent.transform;
    }

}
