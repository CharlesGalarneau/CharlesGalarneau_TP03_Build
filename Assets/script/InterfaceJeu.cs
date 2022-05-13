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
    public Text txtBnPotionHealing;
    public Text txtBnPotionMana;
    public Text txtBnPotionStamina;
    float Timer;
    public Text txtTimer;
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
            Timer += Time.deltaTime;
            txtTimer.text = Timer.ToString();
            txtTimer.text = string.Format("{0:0}:{1:00}",
                   Mathf.Floor(Timer / 60),   // Minutes
                   Mathf.Floor(Timer) % 60);  // seconds
        txtBnPotionHealing.text = NbHealthPotion.ToString();
        txtBnPotionMana.text = NbManaPotion.ToString();
        txtBnPotionStamina.text = NbStaminaPotion.ToString();
    }
    public void ManaButtonClicked()
    {
        if (NbManaPotion > 0)
        {
            AnimationMana.Play();
            NbManaPotion--;

        playerStat.ManaHealing();
        }
    }
    public void HealingButtonClicked()
    {
        if (NbHealthPotion > 0)
        {
            AnimationHealth.Play();
            playerStat.HealthHealing();
            NbHealthPotion--;
        }
    }
    public void StaminaButtonClicked()
    {
        if (NbStaminaPotion > 0)
        {
            AnimationStamina.Play();
        playerStat.StaminaHealing();
            NbStaminaPotion--;
        }
    }
}
