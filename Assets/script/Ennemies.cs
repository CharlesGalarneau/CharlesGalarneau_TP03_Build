using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;
    GameObject Weapon;
    float hitpoints;
    Animator Animator;
    PlayerStat playerStat;
    public float foixgagne =5;
    public float SkeletonAttack;
    public int NbRound =1;
    public GameManager Gamemanager;

    void Start()
    {
        Gamemanager = FindObjectOfType<GameManager>();
        // La quantité de tir du joueur pour tué le zombie (entre 2 et 3)
        hitpoints = Random.Range(2, 6);

        playerStat = FindObjectOfType<PlayerStat>();
    }
    private void Update()
    {
        NbRound = Gamemanager.NbRound;
        SkeletonAttack = NbRound * 5;
        foixgagne = NbRound * 5;
    }

    // Le zombie se fait assigné sa cible (le joueur)
    public void SetTarget(Transform t)
    {
        agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        target = t;

        // À toutes les secondes, le zombie ajustera la position de sa cible
        InvokeRepeating("UpdateDestination", 0.1f, 1f);

        // À toutes les 0.5s, le zombie vérifie si le joueur est a proximité (si oui, c'est game over)
        InvokeRepeating("PlayerProximityCheck", 0.1f, 0.5f);
        UpdateDestination();
       
    }

    void UpdateDestination()
    {
        // Si le jeu est finit, on ne fait rien
        if (GameManager.instance.isGameOver)
            return;
        if (GameManager.instance.Paused)
            return;

        // Ajuster la cible
        agent.SetDestination(target.position);
    }

    void PlayerProximityCheck()
    {
        // Si le jeu est finit, on ne fait rien
        if (GameManager.instance.isGameOver)
            return;

        // Récupère tous les colliders à proximité
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (var item in colliders)
        {
            // Si l'un des collider est celui du joueur, il meurt
            if (item.name == "Player")
            {
                Animator.SetBool("IsAttacking", true);
                
                Debug.Log(Animator.GetBool("IsAttacking"));
                FindObjectOfType<GameManager>().TakeDamage();
            }
            
            else
            {
                Animator.SetBool("IsAttacking", false);
            }
        }
    }

    // Skelete s'est fait tiré
    public void Hit()
    {
        hitpoints-= playerStat.Attack;

        if (hitpoints <= 0)
            Die();
    }

    // Le boneboy meurt
    public void Die()
    {
        CancelInvoke("UpdateDestination");
        playerStat.foix += foixgagne;
        Destroy(gameObject);
    }
   
}
