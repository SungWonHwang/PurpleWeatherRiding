using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBGScript : MonoBehaviour
{
    float speed = 1.0f;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        print(spr.bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Vector3.left * Time.deltaTime *speed;
        Vector3 pos = transform.position;
        if(pos.x + spr.bounds.size.x/2 < -8){
            pos.x +=spr.bounds.size.x *3;
            transform.position=pos;
        }
    }
}
