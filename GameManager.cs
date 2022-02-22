using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject astroid;
    public List<GameObject> enemies;
    public float time = 0;
    public float maxTime =2;
    public float coin;

    void Awake(){
        instance=this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coin=0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>maxTime){

            int check = Random.Range(0,2);
            if (check==0){
                Instantiate(astroid, new Vector3(10, Random.Range(-4.0f, 4.0f),0), Quaternion.identity);
            }
            else{
                int type = Random.Range(0,3);
                Instantiate(enemies[type], new Vector3(10, Random.Range(-4.0f, 4.0f),0), Quaternion.identity);
            }
            time=0;
            
        }
        
    }

    
}
