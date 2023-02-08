using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : BoundsRespectingMover
{
    [SerializeField] float speed = 2f;

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis != 0 || verticalAxis != 0) {
            MoveIfPossible((Vector2)transform.position + new Vector2(horizontalAxis * speed * Time.deltaTime, verticalAxis * speed * Time.deltaTime));
        }
    }
}
