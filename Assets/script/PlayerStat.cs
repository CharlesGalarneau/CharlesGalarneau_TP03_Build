using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    float Hp ;
    float Attack;
    float Defence;
    float mana;
    float Stamina;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Hp = 5;
    }

    // Update is called once per frame
    void Update() 
    {

    }
    public void PlayerLoseLife()
    {
        Hp--;
        if (Hp <= 0)
        {
            PlayerDead();
            Debug.Log("Oof");
            FindObjectOfType<GameManager>().GameOver();
            
        }
    }
    void Healing()
    {
        
    }
    public void PlayerDead()
    {
        animator.SetBool("IsDead", true);
    }
}
