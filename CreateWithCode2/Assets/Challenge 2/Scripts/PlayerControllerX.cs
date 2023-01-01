using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Time.deltaTime);
            if (timer > 1.0f)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0.0f;               
            }
            
        }
        timer = timer + Time.deltaTime;
    }
}
