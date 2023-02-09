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

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "Enemy") {
            collider2D.GetComponent<EnemyMover>().TreatAsCought();
        }
    }
}
