using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadSecondLevel", 2f);
    }



    // Update is called once per frame
    void Update()
    {

    }

    void LoadSecondLevel()
    {
        SceneManager.LoadScene(1);
        Invoke("LoadGameScene1", 3f);
    }

    void LoadGameScene1()
    {
        SceneManager.LoadScene(2);
    }
}
