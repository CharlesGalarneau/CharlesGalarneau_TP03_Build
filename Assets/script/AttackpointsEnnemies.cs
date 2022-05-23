using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackpointsEnnemies : MonoBehaviour
{
    public Collider HitPlayer;
    public Ennemies ennemies;
    // Start is called before the first frame update
    void Start()
    {
        ennemies = GetComponent<Ennemies>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider Other)
    {

        if (Other.CompareTag("Players"))
        {
           

            FindObjectOfType<Ennemies>().Attack();


        }
    }
}
