using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float Sensitivity = 0.005f;
    
    public float forwardSpeed = 8f;

    private Touch touch;

    void Update()
    {
        moveForward();
        moveSideways();
    }

    void moveForward()
    {
        transform.Translate(0f, 0f, forwardSpeed * Time.deltaTime);
    }

    void moveSideways()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            float xWays = Mathf.Clamp(transform.position.x + touch.deltaPosition.x * Sensitivity, -1.5f, 1.5f);
            float yWays = Mathf.Clamp(transform.position.y + touch.deltaPosition.y * Sensitivity, -3f, 3f);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(xWays, yWays, transform.position.z);
            }
        }
    }
}
