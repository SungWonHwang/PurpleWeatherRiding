﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed = 1.5f;
    public float coinSize =1;
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime);
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
