using UnityEngine;

public class EnemyMover : BoundsRespectingMover
{
    [SerializeField] float speed = 2f;
    public GameObject mainCharacter;
    private bool caught;

    void Update()
    {
        if (!caught) {
            MoveIfPossible(Vector2.MoveTowards(transform.position, mainCharacter.transform.position, -speed * Time.deltaTime));
        }
    }

    public void TreatAsCaught() {
        if (!caught) {
            caught = true;
            GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(GetComponent<Collider2D>()); // To increase performance.
        }
    }
}
