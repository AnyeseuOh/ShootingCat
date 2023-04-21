using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float sparkMoveSpd = 5f;
    public Vector3 effectPos_;

    public EnemyController enemyController;
    public CatController catController;

    private void Start()
    {
        sparkMoveSpd = GameObject.Find("Cat").GetComponent<CatController>().sparkMoveSpd;
        effectPos_ = GameObject.Find("Cat").GetComponent<CatController>().effectPos;
        
        if (GameObject.Find("Cat").GetComponent<CatController>().isLeft)
        {
            sparkMoveSpd = -sparkMoveSpd;
            effectPos_.x = -effectPos_.x;
        }
        transform.position = GameObject.Find("Cat").transform.position + effectPos_;
    }

    void Update()
    {
        transform.Translate(sparkMoveSpd * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyController.enemyHp--;
            enemyController.enemyState = EnemyController.ENEMYSTATE.DAMAGE;
            if (enemyController.enemyHp <= 0)
            {
                catController = GameObject.Find("Cat").GetComponent<CatController>();
                catController.score++;
                enemyController.enemyState = EnemyController.ENEMYSTATE.DEAD;
                Destroy(collision.gameObject, 1f);
            }
            Destroy(gameObject);
            
        }
    }
}
