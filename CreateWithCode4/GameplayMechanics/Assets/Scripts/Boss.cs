using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bomb;
    private float spawnRange = 9;
    public bool timer = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnBomb", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void spawnBomb()
    {
        Instantiate(bomb, GenerateSpawnPosition(), transform.rotation);
    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

 
}
