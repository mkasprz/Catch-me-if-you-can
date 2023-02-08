using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] int numberOfEnemies = 1000;
    [SerializeField] GameObject mainCharacter;

    void Start()
    {
        float maximumVertialPositionOfEnemy = -Camera.main.transform.position.z * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float maximumHorizontalPositionOfEnemy = maximumVertialPositionOfEnemy * Camera.main.aspect;
        for (int index = 0; index < numberOfEnemies; index++) {
            GameObject enemy = Instantiate<GameObject>(Resources.Load<GameObject>("Enemy"), transform);
            enemy.transform.localPosition = new Vector2(maximumHorizontalPositionOfEnemy * 2 * (UnityEngine.Random.value - 0.5f), maximumVertialPositionOfEnemy * 2 * (UnityEngine.Random.value - 0.5f));
            EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
            enemyMover.mainCharacter = mainCharacter;
            enemyMover.minimumHorizontalPosition = -maximumHorizontalPositionOfEnemy;
            enemyMover.minimumVertialPosition = -maximumVertialPositionOfEnemy;
            enemyMover.maximumHorizontalPosition = maximumHorizontalPositionOfEnemy;
            enemyMover.maximumVerticalPosition = maximumVertialPositionOfEnemy;
        }
    }
}
