using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour
{
    public Transform target;

    public static NavMeshAgent agent;
    GameObject Weapon;
    float hitpoints;
    Animator Animator;
    PlayerStat playerStat;
    public float foixgagne =5;
    public float SkeletonAttack;
    public int NbRound =1;
    public GameManager Gamemanager;
    int attacksCooldown = 5;
    bool IsAttacking;
    public static bool IsinRange =false;

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
        InvokeRepeating("PlayerProximityCheck", 0.1f, 0.25f);
        Animator.SetFloat("Horizontal", 1f);
        Animator.SetFloat("Vertical", 1f);
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


                
                Animator.SetFloat("Horizontal", 0f);
                Animator.SetFloat("Vertical", 0f);
                
                StartCoroutine(Attacks());
                
                StopCoroutine(Attacks());
                Attack();
                
            }
            else
            {
                Animator.SetFloat("Horizontal", 1f);
                Animator.SetFloat("Vertical", 1f);
                
            }
           
        }
    }

    // Skelete s'est fait tiré
    public void Hit()
    {
        hitpoints-= playerStat.Attack;
        Debug.Log("Dommage Taken");
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
    public void Attack()
    {
        if (attacksCooldown == 0)
        {
            if (IsAttacking)
               
            FindObjectOfType<GameManager>().TakeDamage();
            attacksCooldown = 5;
        }
        else
            attacksCooldown--;
    }
    IEnumerator Attacks()
    {
        if (attacksCooldown == 0)
        {

            Animator.SetBool("IsAttacking", true);
            yield return new WaitForSeconds(1f); 
            IsAttacking = true;
            yield return new WaitForSeconds(.1f);
            Animator.SetBool("IsAttacking", false);
            IsAttacking = false;
            yield return new WaitForSeconds(.1f);
        }

    }
    
   
}
