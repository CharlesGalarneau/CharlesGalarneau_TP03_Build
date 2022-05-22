using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackpoints : MonoBehaviour
{
    public Collider Hitennemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ennemies ennemies = GetComponent<Ennemies>();
    }
    private void OnTriggerEnter()
    {

        if (Hitennemies.CompareTag("ennemies"))
        {
            Debug.Log("FIUCKER");
            
            FindObjectOfType<Ennemies>().Hit();

        }
    }
}
