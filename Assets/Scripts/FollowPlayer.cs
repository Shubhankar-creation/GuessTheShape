using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    PlayerMovement movement;
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        transform.Translate(0f, 0f, movement.forwardSpeed * Time.deltaTime);
    }
}
