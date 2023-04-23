using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    
    public enum STATE
    {
        IDLE,
        RUN,
        JUMP,
        ATTACK,
        DEAD
    }
    public STATE catState;
    public GameManager gameManager;
    public GameObject gameoverPanel;
    public AudioSource shootingSfx;
    public AudioSource jumpingSfx;

    public Animator anim;
    public float moveSpeed = 2f;
    public float sparkMoveSpd = 5f;
    public GameObject sparkEffect;
    public Vector3 effectPos;
    public Rigidbody2D rigid;

    public bool isLeft = false;

    public float catHp;
    public int score = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        catHp = 5;
        score = 0;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            catState = STATE.RUN;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            catState = STATE.JUMP;
        }

       if (Input.GetKeyDown(KeyCode.Z))
        {
            catState = STATE.ATTACK;

            shootingSfx.Play();
            GameObject effect;
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                effectPos.x = -effectPos.x;
                sparkMoveSpd = -sparkMoveSpd;
                Debug.Log(sparkMoveSpd);
            }

            effect = Instantiate(sparkEffect, transform.position + effectPos, transform.rotation);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                effect.GetComponent<SpriteRenderer>().flipX = true;
            }

            Destroy(effect, 2f);
            effectPos.x = Mathf.Abs(effectPos.x);
            sparkMoveSpd = Mathf.Abs(sparkMoveSpd);
        }

       if (catHp <= 0)
        {
            catState = STATE.DEAD;
        }

        switch (catState)
        {
            case STATE.IDLE:
                anim.SetInteger("State", (int)catState);
                break;
            case STATE.RUN:
                anim.SetInteger("State", (int) catState);
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    isLeft = true;
                    MoveLeft();
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    isLeft = false;
                    MoveRight();
                }
                else
                {
                    catState = STATE.IDLE;
                }
                break;
            case STATE.JUMP:
                anim.SetInteger("State", 1);
                jumpingSfx.Play();
                rigid.velocity = new Vector2(0, 5f);

                catState = STATE.IDLE;
                break;
            case STATE.ATTACK:
                anim.SetInteger("State", (int)catState);
                anim.SetTrigger("ATTACK");
                
                catState = STATE.IDLE;
                break;
            case STATE.DEAD:
                anim.SetTrigger("DEAD");
                gameManager.Pause();
                gameoverPanel.SetActive(true);
                break;
        }
    }

    public void MoveLeft()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0,0);
        GetComponent<SpriteRenderer>().flipX = true;
    }

    public void MoveRight()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        GetComponent<SpriteRenderer>().flipX = false;
    }
}
