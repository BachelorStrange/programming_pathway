using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    private Vector3 offset = new Vector3(0, 7, -9);
    // Start is called before the first frame update
    void Start()
    {
        cam.enabled = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            cam.enabled = !cam.enabled;
            Debug.Log("test");
        }
        transform.position = player.transform.position + offset;
    }
}
