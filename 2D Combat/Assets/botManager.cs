using UnityEngine;

public class BotManager : MonoBehaviour
{
    public GameObject playerBotPrefab;
    public GameObject enemyBotPrefab;
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;

    private GameObject playerBot;
    private GameObject enemyBot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnPlayerBot();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnEnemyBot();
        }
    }

    void SpawnPlayerBot()
    {
        if (playerBot == null)
        {
            playerBot = Instantiate(playerBotPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            playerBot.tag = "PlayerBot";
        }
    }

    void SpawnEnemyBot()
    {
        if (enemyBot == null)
        {
            enemyBot = Instantiate(enemyBotPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
            enemyBot.tag = "EnemyBot";
        }
    }
}
