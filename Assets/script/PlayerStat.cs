using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float Hp = 25;
    public float Attack =1;
    public float Defence =0;
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
    public Ennemies ennemies;
    public CalculStat Calculstat;
    private float AttackValue =1f;
    public bool Isinvincible = false;
    public float InvincibilityTimer = 15f;
    public ParticleSystem AnimationInvisibiity;
    public AudioSource InvisibilitySpell;

    // Start is called before the first frame update
    void Start()
    {
        ennemies = FindObjectOfType<Ennemies>();
        Calculstat = FindObjectOfType<CalculStat>();
        Charactermovements = FindObjectOfType<CharacterMovements>();
        animator = GetComponent<Animator>();
        Hp = 25;
        mana = 25;
        foix = 25;
        
    }
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update() 
    {
        ennemies = FindObjectOfType<Ennemies>();
        
        if  (InvincibilityTimer <= 1f)
        { Isinvincible = false;
            StopCoroutine(InvincibilityTimerF());
        }
    }
    public void PlayerLoseLife()
    {
        if (Isinvincible == true)
        {
            return;
        }
        else
        { 
            Hp -= ennemies.SkeletonAttack - Defence;

        Debug.Log(Hp);
        if (Hp <= 0)
        {
            PlayerDead();
            Debug.Log("Oof");
            FindObjectOfType<GameManager>().GameOver();

        }
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
    public void ManaMagicMissileCost()
    {
        mana -= 20;
    }
    public void UpgradeSpeed()
    {
        WalkingSpeed += WalkingSpeed * .05f;
        foix -= Calculstat.coutfoixSpeed;
        
    }
    public void UpgradeAttack()
    {
        Attack += 1;
        foix -= Calculstat.coutfoixAttack;
    }
    public void UpgradeMaxHp()
    {
        HpMax += 5;
        foix -= Calculstat.coutfoixHealhMax;
    }
    public void UpgradeMaxMana()
    {
        manaMax += 5;
        foix -= Calculstat.coutfoixManaMax;
    }
    public void UpgradeMaxStamina()
    {
        StaminaMax += 5;
        foix -= Calculstat.coutfoixStaminaMax;
    }
    public void Upgradedefence()
    {
        Defence += 1;
        foix -= Calculstat.coutfoixDefence;
    }
    public void IsinvicibleSpell()
    {
        InvisibilitySpell.Play();
        Isinvincible = true;
        InvincibilityTimer = 15f;
        StartCoroutine(InvincibilityTimerF());
    }
    public void heavyAttacks()
    {
        Attack = AttackValue * 1.25f;
    }
    IEnumerator InvincibilityTimerF()
    {
        for (float i = InvincibilityTimer;  i >= 0f; i-=Time.deltaTime)
        {
            InvincibilityTimer = i;
            Debug.Log(i);
            yield return InvincibilityTimer;
        }
       
       // yield return new WaitForSeconds(0f);
    }

}
