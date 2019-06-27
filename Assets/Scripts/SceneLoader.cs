using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float startDelay = 2f;
    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        Invoke("LoadFirstScene", startDelay);
    }
}
