using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TMP_InputField textField;
    public string text;
    public static UIHandler Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onInputChange()
    {
        UIHandler.Instance.text = textField.text;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        UIHandler.Instance.text = "Default";

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

   public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

}
