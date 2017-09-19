using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour {

    private GameObject player;
    [SerializeField] float speed = 0.5f;
    [SerializeField] Animator anim;
    public float health = 4f;
    

    //   [SerializeField] Animator animator;
    //   [SerializeField] Transform target;
    //   [SerializeField] float speed = 2f;
    //   [SerializeField] float attackRange = 1f;
    //   [SerializeField] int attackDmg = 1;
    //   [SerializeField] float timeBetweenAttacks;

    private PlayerMovement playerScript;
    private ZomMeleeAnim zomMelee;

    private Vector3 startLocation;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        zomMelee = anim.GetBehaviour<ZomMeleeAnim>();
        playerScript = player.GetComponent<PlayerMovement>();
        startLocation = transform.position;
    }

    private void FixedUpdate()
    {
        if (zomMelee.isAttacking && playerScript.isBlocking == false)
        {
           print("EnemyHit!");
           playerScript.playerHealth = playerScript.playerHealth - 0.26f;
           zomMelee.isAttacking = false;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(player.transform.position, transform.position) < 5f)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 1f)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
