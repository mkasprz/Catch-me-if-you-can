using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : BoundsRespectingMover
{
    [SerializeField] float speed = 2f;
    public GameObject mainCharacter;
    public bool cought;

    void Update()
    {
        if (!cought) {
            MoveIfPossible(Vector2.MoveTowards(transform.position, mainCharacter.transform.position, -speed * Time.deltaTime));
        }
    }
}
