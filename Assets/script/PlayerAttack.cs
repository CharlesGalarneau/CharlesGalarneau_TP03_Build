using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool IsAttackingLight = true;
    bool IsAttackingHeavy =true;
    bool IsAttackingUnarmed =true;
    bool IsattackingArmed;
    float AttackDamage;
    float attackSpeed;
    public bool Isarmed = false;
    public GameObject PunchPoints;
    public Animator Animator;
    public int ChargeHeavy = 0;
    public PlayerSpell playerspell;
    public PlayerStat playerstat;
    public Transform attackpoints;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Ennemies ennemies;
    // Start is called before the first frame update;
    void Start()
    {
        playerspell = FindObjectOfType<PlayerSpell>();
        playerstat = FindObjectOfType<PlayerStat>();
        Animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ennemies = GetComponent<Ennemies>();
        if (Input.GetKeyDown(KeyCode.Keypad1) && playerstat.mana >=20 )
        {
            
            MagicMissileAttack();
            playerspell.SpellMagicMissile();
            playerstat.ManaMagicMissileCost();
            //Animator.SetBool("IsCasting", false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && playerstat.mana >= 20)
        {

            MagicMissileAttack();
            playerspell.FaithShield();
            playerstat.ManaMagicMissileCost();
            //Animator.SetBool("IsCasting", false);
        }
        if (Input.GetMouseButtonDown(0) && IsAttackingUnarmed && IsAttackingLight)
        {

            AttacklightUnarmed();


        }
        if (Input.GetMouseButtonDown(1) && IsAttackingHeavy && IsAttackingUnarmed)
        {
           // ChargeHeavy = 1;

            //StartCoroutine(HeavyDelay());
            //if (Input.GetMouseButtonUp(1) && ChargeHeavy == 0)
            //{
                AttackHeavyUnarmed();
            //}
        }
        if (Input.GetMouseButtonDown(0) && IsAttackingLight && IsAttackingUnarmed)
        {
            AttacklightUnarmed();
        }
        if (Input.GetMouseButtonDown(0) && IsAttackingLight && IsAttackingUnarmed)
        {
            AttacklightUnarmed();
        }
        if (Input.GetMouseButtonDown(0) && IsAttackingLight && IsAttackingUnarmed)
        {
            AttacklightUnarmed();
        }
        if (Input.GetMouseButtonUp(0))
        { 
            Animator.SetBool("IsAttackingLight", false);
        Animator.SetBool("IsEquipt", false);
            Animator.SetBool("IsAttackingHeavy", false);
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            Animator.SetBool("IsAttackingLight", false);
            Animator.SetBool("IsEquipt", false);
            Animator.SetBool("IsAttackingHeavy", false);

        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Animator.SetBool("IsCasting", false);

        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            Animator.SetBool("IsCasting", false);

        }

    }
    IEnumerator HeavyDelay()
    {
        
        yield return  new WaitForSeconds(2f);
        ChargeHeavy = 0;
        IsAttackingHeavy =true;
    }
    void AttacklightUnarmed()
    {
        Animator.SetBool("IsAttackingLight", true);
        Animator.SetBool("IsEquipt", false);
        //Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        //foreach (Collider collider in colliders)
        //{
            
        //   // Rigidbody rb = collider.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    { ennemies.Hit(); }
        //    else
        //        return;
        //}
    }
    void AttackHeavyUnarmed()
    {
        Animator.SetBool("IsAttackingHeavy", true);
        Animator.SetBool("IsEquipt", false);
        playerstat.heavyAttacks();
        StopCoroutine(HeavyDelay());
    }
    void AttacklightArmed()
    {
        Animator.SetBool("IsAttackingLight", true);
        Animator.SetBool("IsEquipt", true);

    }
    void AttackHeavyArmed()
    {
        Animator.SetBool("IsAttackingHeavy", true);
        Animator.SetBool("IsEquipt", true);
        StopCoroutine(HeavyDelay());
    }
    void MagicMissileAttack()
    {
        Animator.SetBool("IsCasting", true);
        
    }

}
    

