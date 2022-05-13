using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterfaceJeu : MonoBehaviour
{

    public Button ManaButton;
    public Button HealingButton;
    public Button StaminaButton;
    public ParticleSystem AnimationMana;
    public ParticleSystem AnimationStamina;
    public ParticleSystem AnimationHealth;
    public PlayerStat playerStat;
    public int NbHealthPotion = 1;
    public int NbManaPotion =1;
    public int NbStaminaPotion=1 ;
    // Start is called before the first frame update
    void Start()
    {
        ManaButton.onClick.AddListener(ManaButtonClicked);
        HealingButton.onClick.AddListener(HealingButtonClicked);
        StaminaButton.onClick.AddListener(StaminaButtonClicked);
        playerStat = FindObjectOfType<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManaButtonClicked()
    {
        if (NbManaPotion > 0)
        {
            AnimationMana.Play();

        playerStat.ManaHealing();
        }
    }
    public void HealingButtonClicked()
    {
        if (NbHealthPotion > 0)
        {
            AnimationHealth.Play();
            playerStat.HealthHealing();
        }
    }
    public void StaminaButtonClicked()
    {
        if (NbStaminaPotion > 0)
        {
            AnimationStamina.Play();
        playerStat.StaminaHealing();
        }
    }
}
