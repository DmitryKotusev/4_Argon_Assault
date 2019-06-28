using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHanlder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
}
