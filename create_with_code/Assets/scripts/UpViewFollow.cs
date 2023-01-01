using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpViewFollow : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    private Vector3 offset = new Vector3(0, 40, 0);
    // Start is called before the first frame update
    void Start()
    {
        camera.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            camera.enabled = !camera.enabled;
            Debug.Log("Tests");
        }
        transform.position = player.transform.position + offset;
    }
}