using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a spawnear
    public Transform spawnPoint; // Punto de spawn de los enemigos
    public float respawnTime = 5f; // Tiempo en segundos entre cada respawn

    private float timeElapsed = 0f; // Tiempo transcurrido desde el último respawn

    void Update()
    {
        // Incrementar el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        // Verificar si es tiempo de respawnear un enemigo
        if (timeElapsed >= respawnTime)
        {
            SpawnEnemy();
            timeElapsed = 0f; // Reiniciar el contador de tiempo
        }
    }

    void SpawnEnemy()
    {
        // Instanciar un nuevo enemigo en el punto de spawn
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
