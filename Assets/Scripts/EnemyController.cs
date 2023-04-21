using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        IDLE,
        ATTACK,
        DAMAGE,
        DEAD
    }
    public ENEMYSTATE enemyState;
    public CatController catController;
    public GameObject slimePrefab;
    public Animator anim;

    public int enemyHp;
    public int score;
    public float enemyMoveSpd = 3f;
    public float attackRange = 1f;
    public Vector3 catPos;


    void Start()
    {
        enemyState = ENEMYSTATE.IDLE;
        anim.SetInteger("EnemyState", (int)enemyState);
        catController = GameObject.Find("Cat").GetComponent<CatController>();
        score = catController.score;
    }

    
    void Update()
    {
        catPos = GameObject.Find("Cat").transform.position;

        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                anim.SetInteger("EnemyState", (int)enemyState);
                slimePrefab.transform.Translate(-enemyMoveSpd * Time.deltaTime, 0, 0);
                float dist = Vector3.Distance(catPos, slimePrefab.transform.position);

                if (dist < attackRange)
                {
                    enemyState = ENEMYSTATE.ATTACK;
                }
                break;

            case ENEMYSTATE.ATTACK:
                anim.SetInteger("EnemyState", (int)enemyState);

                enemyState = ENEMYSTATE.IDLE;
                break;

            case ENEMYSTATE.DAMAGE:
                anim.SetInteger("EnemyState", (int)enemyState);
                if (enemyHp <= 0)
                {
                    enemyState = ENEMYSTATE.DEAD;
                }

                enemyState = ENEMYSTATE.IDLE;
                break;

            case ENEMYSTATE.DEAD:
                anim.SetInteger("EnemyState", (int)enemyState);
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<Rigidbody2D>().isKinematic = true;

                anim.SetTrigger("Dead");
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            catController.catHp--;
            Debug.Log("Cat°ú ºÎµúÈû");
            enemyState = ENEMYSTATE.ATTACK;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("º®°ú ºÎµúÈû");
            Destroy(gameObject);
        }
    }
}
