using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
