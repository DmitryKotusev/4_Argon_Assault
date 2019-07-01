using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject deathFX;
    [SerializeField]
    int scorePerHit = 12;
    [SerializeField]
    int hits = 10;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNoneTriggerBoxCollider();
    }

    private void AddNoneTriggerBoxCollider()
    {
        AddBoxCollider();
        InitScoreBoard();
    }

    private void InitScoreBoard()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);

        hits--;
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject deathExplode = Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
