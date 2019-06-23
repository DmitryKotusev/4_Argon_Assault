using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public float startDelay = 2f;
    void Start()
    {
        Invoke("LoadFirstScene", startDelay);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
