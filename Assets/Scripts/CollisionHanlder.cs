using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHanlder : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField]
    float levelLoadDelay = 2f;
    [SerializeField]
    GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
