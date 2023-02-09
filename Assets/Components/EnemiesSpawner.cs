using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] int numberOfEnemies = 1000;
    [SerializeField] GameObject mainCharacter;

    void Start()
    {
        CharactersPositionsBoundsComputer charactersPositionsBoundsComputer = Camera.main.GetComponent<CharactersPositionsBoundsComputer>();
        float minimumHorizontalPositionOfEnemy = charactersPositionsBoundsComputer.minimumHorizontalPosition;
        float maximumHorizontalPositionOfEnemy = charactersPositionsBoundsComputer.maximumHorizontalPosition;
        float minimumVerticalPositionOfEnemy = charactersPositionsBoundsComputer.minimumVerticalPosition;
        float maximumVerticalPositionOfEnemy = charactersPositionsBoundsComputer.maximumVerticalPosition;
        for (int index = 0; index < numberOfEnemies; index++) {
            GameObject enemy = Instantiate<GameObject>(Resources.Load<GameObject>("Enemy"), transform);
            enemy.transform.localPosition = new Vector2(
                (Mathf.Abs(minimumHorizontalPositionOfEnemy) + Mathf.Abs(maximumHorizontalPositionOfEnemy)) * (UnityEngine.Random.value - 0.5f),
                (Mathf.Abs(minimumVerticalPositionOfEnemy) + Mathf.Abs(maximumVerticalPositionOfEnemy)) * (UnityEngine.Random.value - 0.5f)
            );
            EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
            enemyMover.mainCharacter = mainCharacter;
        }
    }
}
