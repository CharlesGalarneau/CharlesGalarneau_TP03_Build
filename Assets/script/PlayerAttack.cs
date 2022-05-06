using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    bool IsAttackingLight;
    bool IsAttackingHeavy;
    bool IsAttackingUnarmed;
    bool IsattackingArmed;
    float AttackDammage;
    float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButtonDown(0) && IsAttackingLight && IsAttackingUnarmed)
        {
            AttacklightUnarmed();
        }

    }
    void AttacklightUnarmed()
    {

    }
    void AttackHeavyUnarmed()
    {
    }
    void AttacklightArmed()
    {

    }
    void AttackHeavyArmed()
    {
    }
}
    

