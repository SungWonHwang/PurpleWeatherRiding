using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotSpeed = 100;
    public float speed =5;
    public int hp =5;
    public float coin =2;

    void Update()
    {
        //transform.position += Vector3.left *speed*Time.deltaTime;
        transform.Translate(Vector3.left *speed*Time.deltaTime, Space.World); //월드 좌표를 쓰냐, 로컬 좌표를 쓰냐의 차이 
        transform.Rotate(new Vector3(0,0,Time.deltaTime*rotSpeed));
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
