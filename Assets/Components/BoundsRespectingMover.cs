using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsRespectingMover : MonoBehaviour
{
    float minimumVerticalPosition;
    float maximumVerticalPosition;
    float minimumHorizontalPosition;
    float maximumHorizontalPosition;

    void Start()
    {
        CharactersPositionsBoundsComputer charactersPositionsBoundsComputer = Camera.main.GetComponent<CharactersPositionsBoundsComputer>();
        minimumHorizontalPosition = charactersPositionsBoundsComputer.minimumHorizontalPosition;
        maximumHorizontalPosition = charactersPositionsBoundsComputer.maximumHorizontalPosition;
        minimumVerticalPosition = charactersPositionsBoundsComputer.minimumVerticalPosition;
        maximumVerticalPosition = charactersPositionsBoundsComputer.maximumVerticalPosition;
    }

    private protected void MoveIfPossible(Vector2 requestedPosition)
    {
        if (requestedPosition.x < minimumHorizontalPosition || requestedPosition.x > maximumHorizontalPosition)
        {
            requestedPosition.x = transform.position.x;
        }
        if (requestedPosition.y < minimumVerticalPosition || requestedPosition.y > maximumVerticalPosition)
        {
            requestedPosition.y = transform.position.y;
        }
        transform.position = requestedPosition;
    }
}
