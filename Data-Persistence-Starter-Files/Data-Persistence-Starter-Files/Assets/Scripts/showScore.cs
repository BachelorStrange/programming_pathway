using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showScore : MonoBehaviour
{
    public int score;
    Text texta;
    // Start is called before the first frame update
    void Start()
    {

        texta = GetComponent<Text>();
       
     
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("MainManager").GetComponent<MainManager>().highscore;
        texta.text = "Best Score :" + UIHandler.Instance.text + " " + score;
    }
}
