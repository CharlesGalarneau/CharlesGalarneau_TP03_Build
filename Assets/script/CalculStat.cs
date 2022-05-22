using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculStat : MonoBehaviour
{
    public float coutfoixAttack =25;
    public float coutfoixSpeed =25;
    public float coutfoixDefence= 25;
    public float coutfoixHealhMax =10;
    public float coutfoixManaMax = 10;
    public float coutfoixStaminaMax= 10;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DefenceUpgradeValueCost()
    {
        coutfoixDefence = coutfoixDefence * 1.15f;
    }
    public void AttackUpgradeValueCost()
    {
        coutfoixAttack = coutfoixAttack * 1.15f;
    }
    public void SpeedUpgradeValueCost()
    {
        coutfoixSpeed = coutfoixSpeed * 1.15f;
    }
    public void ManaMaxUpgradeValueCost()
    {
        coutfoixManaMax = coutfoixManaMax * 1.15f;
    }
    public void StaminaMaxUpgradeValueCost()
    {
        coutfoixStaminaMax = coutfoixStaminaMax * 1.15f;
    }
    public void HealthMaxUpgradeValueCost()
    {
        coutfoixHealhMax = coutfoixHealhMax * 1.15f;
    }
}



