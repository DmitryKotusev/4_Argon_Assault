using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject deathFX;

    private void Start()
    {
        AddNoneTriggerBoxCollider();
    }

    private void AddNoneTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject deathExplode = Instantiate(deathFX, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
}
