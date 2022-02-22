using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject shotEffect; //샷 이펙트 관련 퍼블릭
    public GameObject coin;
    public GameObject explosion;
    public float speed = 10; //샷 스피드
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime *speed);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        print(collision.tag);
        if(collision.tag=="Asteroid"){

            AsteroidScript asteroidScript=collision.gameObject.GetComponent<AsteroidScript>();
            asteroidScript.hp -=3;
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            if (asteroidScript.hp <=0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Vector3 randomPos=new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f),0);
                GameObject coinObj=Instantiate(coin, transform.position+randomPos, Quaternion.identity);
                CoinScript coinScript = coinObj.GetComponent<CoinScript>();
                coinScript.coinSize = asteroidScript.coin;
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        else if (collision.tag=="Enemy"){

            EnemyScript enemyScript=collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.hp -=3;
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            if (enemyScript.hp <=0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Vector3 randomPos=new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f),0);
                GameObject coinObj=Instantiate(coin, transform.position+randomPos, Quaternion.identity);
                CoinScript coinScript = coinObj.GetComponent<CoinScript>();
                coinScript.coinSize = enemyScript.coin;
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
