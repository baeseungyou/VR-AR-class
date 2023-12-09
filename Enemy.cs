using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject explosionFactory;
    public float speed = 5;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3 ) {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        } 
        else {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) 
    {
       /* GameObject smObject = GameObject.Find("ScoreManager");
        if (smObject != null){
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.SetScore(sm.GetScore() + 1);
        } */
       // ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
       ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (collision.gameObject.name.Contains("Bullet")){
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(collision.gameObject);
        }
        else {
            Destroy(collision.gameObject);
        }
        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);
        gameObject.SetActive(false);
    }

    void OnEnable() 
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3) {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else {
            dir = Vector3.down;
        }
    }
}
