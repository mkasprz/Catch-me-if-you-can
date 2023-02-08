using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    public GameObject mainCharacter;
    public float minimumVertialPosition;
    public float minimumHorizontalPosition;
    public float maximumVerticalPosition;
    public float maximumHorizontalPosition;
    public bool cought;

    void Update()
    {
        if (!cought) {
            Vector2 requestedPosition = Vector2.MoveTowards(transform.position, mainCharacter.transform.position, -speed * Time.deltaTime);
            if (requestedPosition.x < minimumHorizontalPosition || requestedPosition.x > maximumHorizontalPosition)
            {
                requestedPosition.x = transform.position.x;
            }
            if (requestedPosition.y < minimumVertialPosition || requestedPosition.y > maximumVerticalPosition)
            {
                requestedPosition.y = transform.position.y;
            }
            transform.position = requestedPosition;
        }
    }
}
