using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool IsAttackingLight = true;
    bool IsAttackingHeavy;
    bool IsAttackingUnarmed =true;
    bool IsattackingArmed;
    float AttackDammage;
    float attackSpeed;
    public bool Isarmed = false;
    public GameObject PunchPoints;
    public Animator Animator;
    public int ChargeHeavy = 0;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && IsAttackingUnarmed  && IsAttackingLight)
        {
           
                AttacklightUnarmed();


        }
        if (Input.GetMouseButtonDown(1) && IsAttackingHeavy && IsAttackingUnarmed)
        {
            ChargeHeavy = 1;

            StartCoroutine(HeavyDelay());
            if (Input.GetMouseButtonUp(1) && ChargeHeavy == 0)
            {
                AttackHeavyUnarmed();
            }
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
        Animator.SetBool("IsAttackingUnarmed", true);
    }
    void AttackHeavyUnarmed()
    {
        Animator.SetBool("IsAttackingHeavy", true);
        Animator.SetBool("IsAttackingUnarmed", true);
        StopCoroutine(HeavyDelay());
    }
    void AttacklightArmed()
    {
        Animator.SetBool("IsAttackingLight", true);
        Animator.SetBool("IsAttackingArmed", true);

    }
    void AttackHeavyArmed()
    {
        Animator.SetBool("IsAttackingHeavy", true);
        Animator.SetBool("IsAttackingArmed", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemies"))
        {

            Ennemies ennemies = other.GetComponent<Ennemies>();

            
        }
    }
}
    

