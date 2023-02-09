using UnityEngine;

public class MainCharacterController : BoundsRespectingMover
{
    [SerializeField] float speed = 2f;
    Vector2 previousMousePosition;
    bool mousePositionChanged;

    Vector2 getCurrentMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -Camera.main.transform.position.z));
    }

    new void Start()
    {
        base.Start();
        previousMousePosition = getCurrentMousePosition();
    }

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        if (horizontalAxis != 0 || verticalAxis != 0) {
            mousePositionChanged = false;
            MoveIfPossible((Vector2)transform.position + new Vector2(horizontalAxis * speed * Time.deltaTime, verticalAxis * speed * Time.deltaTime));
        }
        else
        {
            Vector2 currentMousePosition = getCurrentMousePosition();
            if (!Vector2.Equals(currentMousePosition, previousMousePosition)) {
                mousePositionChanged = true;
            }
            if (mousePositionChanged)
            {
                MoveIfPossible(Vector2.MoveTowards(transform.position, currentMousePosition, speed * Time.deltaTime));
            }
            previousMousePosition = currentMousePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "Enemy") {
            collider2D.GetComponent<EnemyMover>().TreatAsCaught();
        }
    }
}
