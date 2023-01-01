using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -15.0f;
    private float rightBound = 30.0f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.z > topBound)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.z < lowerBound)
        {
            player.GetComponent<PlayerController>().lives--;

            if (player.GetComponent<PlayerController>().lives <= 0)
            {
                player.GetComponent<PlayerController>().gameover = true;
            }
            Destroy(gameObject);
        }
        else if (transform.position.x > rightBound)
        { 
            Destroy(gameObject);
        }
    }
}
