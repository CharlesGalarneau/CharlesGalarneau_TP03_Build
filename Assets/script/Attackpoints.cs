using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackpoints : MonoBehaviour
{
    public Collider Hitennemies;
    public GameObject ennemies;
    public PlayerAttack PlayerAttack;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttack =FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        ennemies = FindObjectOfType<GameObject>();
    }
    private void OnTriggerEnter(Collider Other)
    {

        if (Other.CompareTag("ennemies") && PlayerAttack.IsAttacking == true )
        {
           
            GameObject DeathEnnemies = Other.GetComponent<GameObject>();

           // Destroy(ennemies);
            FindObjectOfType<GameManager>().TakeDamageEnnemies();


        }
        else
            return;
    }
}
