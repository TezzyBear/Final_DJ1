using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Enemy;
    [SerializeField]
    private int spawnRate;
    private float spawnTimer;
    [SerializeField]
    private int nEnemies;
    private int countEnemies;
    public bool hasStarted;
    public int waveNumber;

    void Start()
    {
        countEnemies = 0;
    }

    void Update()
    {
        if (hasStarted) {
            spawnTimer += 1 * Time.deltaTime;
            if (spawnTimer > spawnRate) {
                spawnTimer = 0;
                int i = Random.Range(0, Enemy.Count);
                Instantiate(Enemy[i], new Vector2(0f, 0f), Quaternion.identity);
                countEnemies++;
                if (countEnemies > nEnemies) {
                    Destroy(this.gameObject);
                    GameController.instance.startWave(waveNumber);
                }
            }
        }        
    }
}
