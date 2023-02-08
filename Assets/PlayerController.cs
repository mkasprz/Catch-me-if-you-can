using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis != 0 || verticalAxis != 0) {
            transform.Translate(new Vector2(horizontalAxis * speed, verticalAxis * speed));
        }
    }
}
