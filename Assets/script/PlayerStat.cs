using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float Hp = 25;
    public float Attack =1;
    public float Defence;
    public float mana = 25;
   public float Stamina= 25;
    public int HpMax = 25;
    public int manaMax = 25;
    public int StaminaMax = 25;
    public float staminaRunning = 5f;
    Animator animator;
    public AudioSource Deathsound;
    public float foix;
    public CharacterMovements Charactermovements;
    public float StaminaRegen =.25f;
    public float WalkingSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        Charactermovements = FindObjectOfType<CharacterMovements>();
        animator = GetComponent<Animator>();
        Hp = 25;
    }

    // Update is called once per frame
    void Update() 
    {

    }
    public void PlayerLoseLife()
    {
        Hp--;
        Debug.Log(Hp);
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
        Deathsound.Play();
    }
    public void StaminaRegeneration()
    {
        if ( Charactermovements.Isrunning == false)
            Stamina += StaminaRegen * Time.deltaTime;
        else
            return;
    }
    public void StaminaCost()
    {
        Stamina -=staminaRunning * Time.deltaTime;
    }
    public void UpgradeSpeed()
    {
        WalkingSpeed += WalkingSpeed * .05f;
        
    }
    public void UpgradeAttack()
    {
        Attack += 1;
    }
    public void UpgradeMaxHp()
    {
        HpMax += 5;
    }
    public void UpgradeMaxMana()
    {
        manaMax += 5;
    }
    public void UpgradeMaxStamina()
    {
        StaminaMax += 5;
    }
}
