using UnityEngine;

public class CharactersPositionsBoundsComputer : MonoBehaviour
{
    public float minimumVerticalPosition;
    public float maximumVerticalPosition;
    public float minimumHorizontalPosition;
    public float maximumHorizontalPosition;

    void Awake()
    {
        minimumVerticalPosition = Camera.main.transform.position.z * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        minimumHorizontalPosition = minimumVerticalPosition * Camera.main.aspect;
        maximumVerticalPosition = -minimumVerticalPosition;
        maximumHorizontalPosition = -minimumHorizontalPosition;
    }
}
