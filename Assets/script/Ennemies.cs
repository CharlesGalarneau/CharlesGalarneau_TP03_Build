using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;
    GameObject Weapon;
    int hitpoints;
    

    void Start()
    {
        // La quantité de tir du joueur pour tué le zombie (entre 2 et 3)
        //hitpoints = Random.Range(2, 4);

      
    }

    // Le zombie se fait assigné sa cible (le joueur)
    public void SetTarget(Transform t)
    {
        agent = GetComponent<NavMeshAgent>();

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
        //if (GameManager.instance.isGameOver)
            //return;

        // Ajuster la cible
        agent.SetDestination(target.position);
    }

    void PlayerProximityCheck()
    {
        // Si le jeu est finit, on ne fait rien
        if (GameManager.instance.isGameOver)
            return;

        // Récupère tous les colliders à proximité
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.4f);

        foreach (var item in colliders)
        {
            // Si l'un des collider est celui du joueur, il meurt
            if (item.name == "Player")
                FindObjectOfType<GameManager>().GameOver();
        }
    }

    // Zombie s'est fait tiré
    public void Shot()
    {
        hitpoints--;

        if (hitpoints < 1)
            Die();
    }

    // Le zombie meurt
    public void Die()
    {
        CancelInvoke("UpdateDestination");
        Destroy(gameObject);
    }
   
}
