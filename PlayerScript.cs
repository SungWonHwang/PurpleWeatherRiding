using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Shot;

    public Text MyScoreText;
    private int ScoreNum;

    //public Transform shotPointTr;

    public float speed = 5;

    Vector3 min, max;
    Vector2 colSize;
    Vector2 chrSize;

    // Start is called before the first frame update
    void Start()
    {

        //Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        //print(worldPos);
        //min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        //max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        min = new Vector3(-8, -4.5f, 0);
        max = new Vector3(8, 4.5f, 0);

        colSize=GetComponent<BoxCollider2D>().size;
        chrSize= new Vector2(colSize.x/2, colSize.y/2);

        ScoreNum=0;
        MyScoreText.text="SCORE : "+ ScoreNum;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerShot();
    }

    public float shotMax = 0.5f;
    public float shotDelay=0;



    void PlayerShot(){
        shotDelay += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            if (shotDelay > shotMax)
            {
                shotDelay =0;
                Vector3 vec = new Vector3(transform.position.x+1.12f, transform.position.y-0.17f, transform.position.z);
                Instantiate(Shot, vec, Quaternion.identity);
            }
        }
        

    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position = transform.position + dir * Time.deltaTime * speed;
        float newX = transform.position.x;
        float newY = transform.position.y;
        /*
        if(newX < min.x + chrSize.x){
            newX=min.x + chrSize.x;
        }
        if(newX > max.x - chrSize.x){
            newX=max.x - chrSize.x;
        }

        if(newY < min.y + chrSize.y){
            newY=min.y + chrSize.y;
        }
        if(newY > max.y - chrSize.y){
            newY=max.y - chrSize.y;
        }
        */
        newX = Mathf.Clamp(newX, min.x+chrSize.x, max.x - chrSize.x);
        newY = Mathf.Clamp(newY, min.y + chrSize.y, max.y - chrSize.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Item"){
            ScoreNum  +=10;
            MyScoreText.text="SCORE : "+ ScoreNum;
            CoinScript coinScript = collision.gameObject.GetComponent<CoinScript>();
            GameManager.instance.coin +=coinScript.coinSize;
            print("Coin"+GameManager.instance.coin);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="Asteroid"||
        collision.gameObject.tag=="Enemy"||
        collision.gameObject.tag=="EnemyShot"
        )
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene(0);
        }
    }
}
