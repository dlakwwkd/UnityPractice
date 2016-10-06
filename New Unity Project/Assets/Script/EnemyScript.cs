using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyScript : MonoBehaviour
{
    ENEMYSTATE enemyState = ENEMYSTATE.IDLE;

    delegate void StateFunc();
    Dictionary<ENEMYSTATE, Action> dicState = new Dictionary<ENEMYSTATE, Action>();

    Animation anim = null;
    Transform target = null;
    PlayerState playerState = null;
    CharacterController characterControlloer = null;

    int healthPoint = 5;
    float stateTime = 0.0f;

    public float idleStateMaxTime = 2.0f;
    public float attackStateMaxTime = 2.0f;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 2.5f;

    public GameObject explosionParticle = null;
    public GameObject deadObject = null;
    public AudioClip clip = null;

    public int score = 10;

    void Awake()
    {
        anim = GetComponent<Animation>();
        InitSpider();
    }

    void OnEnable()
    {
        InitSpider();
    }

    void OnDisable()
    {

    }

    void Start()
    {
        dicState[ENEMYSTATE.NONE] = None;
        dicState[ENEMYSTATE.IDLE] = Idle;
        dicState[ENEMYSTATE.MOVE] = Move;
        dicState[ENEMYSTATE.ATTACK] = Attack;
        dicState[ENEMYSTATE.DAMAGE] = Damage;
        dicState[ENEMYSTATE.DEAD] = Dead;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        characterControlloer = GetComponent<CharacterController>();
        playerState = target.GetComponent<PlayerState>();
        //         AnimationEvent ae = new AnimationEvent();
        //         ae.functionName = "Attack";
        //         ae.time = anim["attack_Melee"].length * 0.7f;
        //         anim["attack_Melee"].clip.AddEvent(ae);
    }

    void Update()
    {
        dicState[enemyState]();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bomb")
            return;

        if (enemyState == ENEMYSTATE.NONE ||
            enemyState == ENEMYSTATE.DEAD)
            return;

        enemyState = ENEMYSTATE.DAMAGE;
    }



    void InitSpider()
    {
        healthPoint = 5;
        enemyState = ENEMYSTATE.IDLE;
        anim.Play("iddle");
    }

    void None()
    {
    }

    void Idle()
    {
        stateTime += Time.deltaTime;
        if (stateTime > idleStateMaxTime)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.MOVE;
        }
    }

    void Move()
    {
        anim.Play("walk");
        float distance = (target.position - transform.position).magnitude;
        if(distance < attackRange)
        {
            enemyState = ENEMYSTATE.ATTACK;
            stateTime = attackStateMaxTime;
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            dir.y = 0.0f;
            dir.Normalize();
            characterControlloer.SimpleMove(dir * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        stateTime += Time.deltaTime;
        if(stateTime > attackStateMaxTime)
        {
            stateTime = 0.0f;
            anim.Play("attack_Melee");
            anim.PlayQueued("iddle", QueueMode.CompleteOthers);

            playerState.DamageByEnemy();
        }

        float distance = (target.position - transform.position).magnitude;
        if (distance > attackRange)
        {
            enemyState = ENEMYSTATE.IDLE;
        }
    }

    void Damage()
    {
        healthPoint -= 1;

        anim["damage"].speed = 0.5f;
        anim.Play("damage");
        anim.PlayQueued("iddle", QueueMode.CompleteOthers);

        stateTime = 0.0f;
        enemyState = ENEMYSTATE.IDLE;

        if (healthPoint <= 0)
            enemyState = ENEMYSTATE.DEAD;

        AudioManager.instance.PlaySfx(clip);
    }

    void Dead()
    {
        StartCoroutine("DeadProcess");
        enemyState = ENEMYSTATE.NONE;

        ScoreManager.Instance().myScore += score;
    }

    IEnumerator DeadProcess()
    {
        anim["death"].speed = 0.5f;
        anim.Play("death");

        while(anim.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1.0f);

        GameObject explosionObj = Instantiate(explosionParticle) as GameObject;
        Vector3 explosionObjPos = transform.position;
        explosionObjPos.y = 0.6f;
        explosionObj.transform.position = explosionObjPos;

        yield return new WaitForSeconds(0.5f);

        GameObject deadObj = Instantiate(deadObject) as GameObject;
        Vector3 deadObjPos = transform.position;
        deadObjPos.y = 0.6f;
        deadObj.transform.position = deadObjPos;

        float rotationY = UnityEngine.Random.Range(-180.0f, 180.0f);
        deadObj.transform.eulerAngles = new Vector3(0.0f, rotationY, 0.0f);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
