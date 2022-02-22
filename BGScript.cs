﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public float speed =5;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Vector3.left * Time.deltaTime *speed;
        Vector3 pos = transform.position;
        if(pos.x + spr.bounds.size.x/2 < -8){
            float size = spr.bounds.size.x *2;
            pos.x +=size;
            transform.position = pos;
        }
    }
}
