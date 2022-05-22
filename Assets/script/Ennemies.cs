using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ennemies : MonoBehaviour
{
    public Transform target;

    public NavMeshAgent agent;
    GameObject Weapon;
    public float hitpoints;
    Animator Animator;
    PlayerStat playerStat;
    public float foixgagne =5;
    public float SkeletonAttack;
    public float SkeletonDefence;
    public int NbRound =1;
    public GameManager Gamemanager;
    int attacksCooldown = 5;
    public bool IsAttacking;
    public static bool IsinRange =false;
    public bool IsDead=false;
    public GameObject Player;
    public Ennemies ennemies;
    public float MaxLifeValue;
    public Slider LifeBar;
    public Rigidbody rb;
    public Collider PlayerHit;
    public Vector3 objectif;


    void Start()
    {

        //target = Player.transform.Find("Player");
        // La quantité de tir du joueur pour tué le zombie (entre 2 et 3)
        //hitpoints = Random.Range(2, 6);

        //ennemies = GetComponent<Ennemies>();
        agent = GetComponent<NavMeshAgent>();
        

        NbRound = Gamemanager.NbRound;
        hitpoints = NbRound * 2;
        SkeletonAttack = NbRound;
        SkeletonDefence = NbRound -1;
        foixgagne = NbRound * 5;

        



        playerStat = FindObjectOfType<PlayerStat>();
        //InvokeRepeating("UpdateDestination", 0.1f, 1f);
        
    }
    private void Awake()
    {

        
        Animator = GetComponent<Animator>();
        Gamemanager = FindObjectOfType<GameManager>();
        
        rb = GetComponent<Rigidbody>();
        
       
    }
    private void Update()
    {
        //objectif = target.position;
        Debug.Log(target.position);
        ennemies = GetComponent<Ennemies>();
       
        
        MaxLifeValue = Gamemanager.NbRound * 5;
        LifeBar.maxValue = MaxLifeValue;
        LifeBar.value = hitpoints;
        InvokeRepeating("UpdateDestination", 0.1f, 2.5f);
        InvokeRepeating("PlayerProximityCheck", 0.1f, 2.5f);
       
        
    }

    // Le zombie se fait assigné sa cible (le joueur)
    public void SetTarget(Transform t)
    {


        agent = GetComponent<NavMeshAgent>();

        target = t;
        agent.SetDestination(target.position);
        // À toutes les secondes, le zombie ajustera la position de sa cible


        // À toutes les 0.5s, le zombie vérifie si le joueur est a proximité (si oui, c'est game over)
        //InvokeRepeating("PlayerProximityCheck", 0.1f, 0.25f);
        Animator.SetFloat("Horizontal", 1f);
        Animator.SetFloat("Vertical", 1f);
       
       

       
       

    }
    public void UpdateDestination()
    {
        
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
                
                
              
                
            }
            else
            {
                StopCoroutine(Attacks());
                Animator.SetFloat("Horizontal", 1f);
                Animator.SetFloat("Vertical", 1f);
                
            }
           
        }
    }

    // Skelete s'est fait tiré
    public void Hit()
    {
        hitpoints -= playerStat.Attack;// -SkeletonDefence;
        Debug.Log(hitpoints);
        if (hitpoints <= 0)
            Die();
    }

    // Le boneboy meurt
    public void Die()
    {
        CancelInvoke("UpdateDestination");
        CancelInvoke("PlayerProximityCheck");
        playerStat.foix += foixgagne;
        Animator.SetBool("Isdead", true);
        
       Destroy(this.gameObject);
       Gamemanager.DeleteEnnemies();
        IsDead =true;
    }
    public void Attack()
    {
       
               
            FindObjectOfType<GameManager>().TakeDamage();

    }
    IEnumerator Attacks()
    {
      

            Animator.SetBool("IsAttacking", true);
            
            yield return new WaitForSeconds(1f); 
            IsAttacking = true;
        
        yield return new WaitForSeconds(.1f);
            Animator.SetBool("IsAttacking", false);
            IsAttacking = false;
            yield return new WaitForSeconds(.1f);
        

    }
    //private void OnTriggerEnter(Collider collider)
    //{

    //   // if (collider.CompareTag("Player"))
    //    {
    //        //PlayerStat Player = collider.GetComponent<PlayerStat>();

    //        Attack();


    //    }
    //}


}
