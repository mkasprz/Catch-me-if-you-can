using UnityEngine;

public class EnemyMover : BoundsRespectingMover
{
    [SerializeField] float speed = 2f;
    public GameObject mainCharacter;
    private bool cought;

    void Update()
    {
        if (!cought) {
            MoveIfPossible(Vector2.MoveTowards(transform.position, mainCharacter.transform.position, -speed * Time.deltaTime));
        }
    }

    public void TreatAsCought() {
        if (!cought) {
            cought = true;
            GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(GetComponent<Collider2D>()); // To increase performance.
        }
    }
}
