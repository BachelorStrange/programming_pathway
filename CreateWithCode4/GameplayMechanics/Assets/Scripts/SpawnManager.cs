using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;
    public GameObject[] enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerUpPrefab;
    public GameObject projectile;
    public bool spawnProjectiles;
    public Enemy[] enemyList;
    private GameObject focalPoint;
    public GameObject player;
    public enum powerUpEnum
    {
        powerPowerUp,
        missilePowerUp,
        stopmPowerUp
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpPrefab[0], GenerateSpawnPosition(), powerUpPrefab[0].transform.rotation);
        spawnEnemyWave(waveNumber);
        player = GameObject.Find("Player");
       
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        enemyList = FindObjectsOfType<Enemy>();
        if ( enemyCount == 0)
        {
            if (waveNumber < 3)
            {
                spawnEnemyWave(waveNumber);
            }
            else
            {
                spawnBoss();
            }
            
            waveNumber++;
        }
        if (spawnProjectiles)
        {
            spawnProjectiles = false;
            for (int i = 0; i<enemyCount; i++)
            {
               GameObject proj = Instantiate(projectile, player.transform.position, projectile.transform.rotation);
                proj.GetComponent<Projectile>().enemy = enemyList[i];
                
            }
        }
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefab.Length-2);
            var values = System.Enum.GetValues(typeof(powerUpEnum));       
            powerUpEnum randomPowerUpIndex = (powerUpEnum)values.GetValue( Random.Range(0, values.Length));
            Instantiate(powerUpPrefab[(int) randomPowerUpIndex], GenerateSpawnPosition(), powerUpPrefab[(int) randomPowerUpIndex].transform.rotation);
            Instantiate(enemyPrefab[randomEnemyIndex], GenerateSpawnPosition(), enemyPrefab[randomEnemyIndex].transform.rotation);
        }
    }

    void spawnBoss()
    {
        var values = System.Enum.GetValues(typeof(powerUpEnum));
        powerUpEnum randomPowerUpIndex = (powerUpEnum)values.GetValue(Random.Range(0, values.Length));
        Instantiate(powerUpPrefab[(int)randomPowerUpIndex], GenerateSpawnPosition(), powerUpPrefab[(int)randomPowerUpIndex].transform.rotation);
        Instantiate(enemyPrefab[enemyPrefab.Length-1], GenerateSpawnPosition(), enemyPrefab[enemyPrefab.Length-1].transform.rotation);
    }
}
