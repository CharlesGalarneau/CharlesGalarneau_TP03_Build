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
    int HpMax = 25;
    int manaMax = 25;
    int StaminaMax = 25;
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
    public void HealthHealing()
    {
       if (Hp <= HpMax)
        {
            Hp += 5;
        
        }
        Debug.Log(Hp);
    }
    public void ManaHealing()
    {
        if (mana <= manaMax)
        {
            mana += 5;
        
        
        }
        Debug.Log(mana);
    }
    public void StaminaHealing()
    {
        if (Stamina <= StaminaMax)
        {
            Stamina += 5;
        
        }
        Debug.Log(Stamina);
    }
    public void PlayerDead()
    {
        animator.SetBool("IsDead", true);
    }

}
