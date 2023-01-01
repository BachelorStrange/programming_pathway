using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    GameObject player;
    Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        slide = gameObject.GetComponentInChildren<Slider>();
        Debug.Log(slide);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (slide.value <3 )
        {
            slide.value++;
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            player.GetComponent<PlayerController>().points = player.GetComponent<PlayerController>().points + 1;
        }
        

    }
}
