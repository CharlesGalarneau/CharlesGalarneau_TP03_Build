using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float Hp = 100;
    public float Attack =1;
    public float Defence =0;
    public float mana = 100;
   public float Stamina= 100;
    public int HpMax = 100;
    public int manaMax = 100;
    public int StaminaMax = 100;
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
        Hp = 100;
        mana = 100;
        Stamina = 100;
        HpMax = 100;
        HpMax = 100;
        StaminaMax = 100;
        manaMax = 100;
        foix = 50;
        
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
            Hp += 10;
        
        }
        Debug.Log(Hp);
    }
    public void ManaHealing()
    {
        if (mana <= manaMax)
        {
            mana += 10;
        
        
        }
        Debug.Log(mana);
    }
    public void StaminaHealing()
    {
        if (Stamina <= StaminaMax)
        {
            Stamina += 10;
        
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
        mana -= 50;
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
        HpMax += 10;
        foix -= Calculstat.coutfoixHealhMax;
    }
    public void UpgradeMaxMana()
    {
        manaMax += 10;
        foix -= Calculstat.coutfoixManaMax;
    }
    public void UpgradeMaxStamina()
    {
        StaminaMax += 10;
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
    // PROF: Pourquoi y a-t-il des fonctions de sorts dans le script de stats?
    public void heavyAttacks()
    {
        //Attack = Attack + 1f;
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
