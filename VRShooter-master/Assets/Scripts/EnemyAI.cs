using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour, ITakeDamage
{
    const string RUN_TRIGGER = "Run";
    const string CROUCH_TRIGGER = "Crouch";
    const string SHOOT_TRIGGER = "Shoot";

    [SerializeField] private float startingHealth;
    [SerializeField] private float minTimeUnderCover;
    [SerializeField] private float maxTimeUnderCover;
    [SerializeField] private int minShotsToTake;
    [SerializeField] private int maxShotsToTake;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float damage;
    [SerializeField] public TMP_Text puntuation;
    [SerializeField] public TMP_Text Timer;

    [Range(0, 100)]
    [SerializeField] private float shootingAccuracy;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private ParticleSystem bloodSplatterFX;
    [SerializeField] public IntSO user;
    [SerializeField] public EnemiesSO EnemiesDefeated;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;
    private bool isShooting;
    private int currentShotsTaken;
    private int currentMaxShotsToTake;
    private NavMeshAgent agent;
    private Player player;
    public GameObject Player;
    private Transform occupiedCoverSpot;
    private Animator animator;
    private float _health;
    public int score;
    public float AttackDistance = 10.0f;

    void Start()
    {
        gameObject.tag = "Music";
        EnemiesDefeated.Value = 0;
    }
    public float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, startingHealth);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetTrigger(RUN_TRIGGER);
        _health = startingHealth;
        
    }

    public void Init(Player player, Transform coverSpot)
    {
        occupiedCoverSpot = coverSpot;
        this.player = player;
        GetToCover();
    }

    private void GetToCover()
    {
        agent.isStopped = false;
        agent.SetDestination(occupiedCoverSpot.position);
    }

    private void Update()
    {
        if (agent.isStopped == false && (transform.position - occupiedCoverSpot.position).sqrMagnitude <= 0.1f)
        {
            agent.isStopped = true;
            StartCoroutine(InitializeShootingCO());
        }
        if (isShooting)
        {
            RotateTowardsPlayer();
        }
    }
    private IEnumerator InitializeShootingCO()
    {
        HideBehindCover();
        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeUnderCover, maxTimeUnderCover));
        StartShooting();
    }


    private void HideBehindCover()
    {
        animator.SetTrigger(CROUCH_TRIGGER);
    }
    private void StartShooting()
    {
        isShooting = true;
        currentMaxShotsToTake = UnityEngine.Random.Range(minShotsToTake, maxShotsToTake);
        currentShotsTaken = 0;
        animator.SetTrigger(SHOOT_TRIGGER);
    }

    public void Shoot()
    {

        float dist = Vector3.Distance(Player.transform.position, this.transform.position);
        float random = UnityEngine.Random.Range(0, 100);
        float random1 = UnityEngine.Random.Range(0.0f, 1.0f);
        if (random1 > (1.0f - AttackProbability) && dist < AttackDistance)
        {
            bool isHit = random < shootingAccuracy;

            if (isHit)
            {
                player.TakeDamage(damage);

            }
        }
        // The higher the accuracy is, the more likely the player will be hit
        
        /*if (hitPlayer)
        {
            
            RaycastHit hit;
            Vector3 direction = player.GetHeadPosition() - shootingPosition.position;
            if (Physics.Raycast(shootingPosition.position, direction, out hit))
            {
                
                Player player = hit.collider.GetComponentInParent<Player>();
                if (player)
                {
                    Debug.Log("ENTRA!!!!!!!!!!!!");
                    player.TakeDamage(damage);
                }
            }
        }*/
        currentShotsTaken++;
        if (currentShotsTaken >= currentMaxShotsToTake)
        {
            StartCoroutine(InitializeShootingCO());
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.GetHeadPosition() - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        health -= weapon.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemiesDefeated.Value = EnemiesDefeated.Value + 1;
            Debug.Log("Enemics derrotats " + EnemiesDefeated.Value);
            if (puntuation.text == "Score")
            {
                puntuation.text = "100";
                user.Value = Convert.ToInt32(puntuation.text);
                
            } else
            {
                puntuation.text = (Convert.ToInt32(puntuation.text) + 100).ToString();
                user.Value = Convert.ToInt32(puntuation.text);
               

            }
        }
        ParticleSystem effect = Instantiate(bloodSplatterFX, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint));
        effect.Stop();
        effect.Play();
    }


}