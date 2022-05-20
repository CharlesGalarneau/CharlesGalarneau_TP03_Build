using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPersonnage : MonoBehaviour
{
    public Button Retouraujeu;
    public GameManager gameManager;
    public Button UpgradeSpeed;
    public Button UpgradeAttack;
    public Button UpgradeMaxHp;
    public Button UpgradeMaxMana;
    public Button UpgradeMaxStamina;
    public PlayerStat Playerstat;
    public Button BuyHealthPotion;
    public Button BuyStaminaPotion;
    public Button BuyManaPotion;
    public InterfaceJeu Interfacejeu;
    public AudioSource UpgradeSound;
    public float foix = 25f;
    public Text TextFoix;
    public Text TextAttaque;
    public Text TextSpeed;
    public Text TextMaxHealth;
    public Text TextMaxMana;
    public Text TextMaxStamina;
    public Text TextDefence;
    public Button UpgradeDefence;
    public CalculStat Calculstat;
    public Text TextCoutDefence;
    public Text TextCoutMaxStamina;
    public Text TextCoutMaxHealth;
    public Text TextCoutMaxMana;
    public Text TextCoutSpeed;
    public Text TextCoutAttack;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        Playerstat = FindObjectOfType<PlayerStat>();
        Calculstat = FindObjectOfType<CalculStat>();
        Interfacejeu = FindObjectOfType<InterfaceJeu>();
        Retouraujeu.onClick.AddListener(FermetureMenu);
        UpgradeSpeed.onClick.AddListener(UpgradeSpeedButton);
        UpgradeAttack.onClick.AddListener(UpgradeAttackButton);
        UpgradeDefence.onClick.AddListener(UpgradeDefenceButton);
        UpgradeMaxMana.onClick.AddListener(UpgradeMaxManaButton);
        UpgradeMaxStamina.onClick.AddListener(UpgradeMaxStaminaButton);
        UpgradeMaxHp.onClick.AddListener(UpgradeMaxHealthButton);
        BuyManaPotion.onClick.AddListener(BuyManaPotionButton);
        BuyHealthPotion.onClick.AddListener(BuyheatlhPotionButton);
        BuyStaminaPotion.onClick.AddListener(BuyStaminaPutionButton);
        gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        foix = Playerstat.foix;
        TextFoix.text = Playerstat.foix.ToString();
        TextFoix.text = Playerstat.foix.ToString();
        TextFoix.text = Playerstat.foix.ToString();
        TextFoix.text = Playerstat.foix.ToString();
        TextMaxStamina.text = Playerstat.StaminaMax.ToString();
        TextMaxHealth.text = Playerstat.HpMax.ToString();
        TextMaxMana.text = Playerstat.manaMax.ToString();
        TextAttaque.text = Playerstat.Attack.ToString();
        TextDefence.text = Playerstat.Defence.ToString();
        TextSpeed.text = Playerstat.WalkingSpeed.ToString();
        TextCoutSpeed.text = Calculstat.coutfoixSpeed.ToString();
        TextCoutMaxMana.text = Calculstat.coutfoixManaMax.ToString();
        TextCoutMaxHealth.text = Calculstat.coutfoixHealhMax.ToString();
        TextCoutMaxStamina.text = Calculstat.coutfoixStaminaMax.ToString();
        TextCoutAttack.text = Calculstat.coutfoixAttack.ToString();
        TextCoutDefence.text = Calculstat.coutfoixDefence.ToString();
    }
    void FermetureMenu()
    {
        gameObject.SetActive(false);
        gameManager.StopPauseJeu();
    }
    public void OuvertureMenu()
    {
        gameManager.PauseJeu();
        gameObject.SetActive(true);
    }
    public void UpgradeSpeedButton()
    {
        if (foix >= Calculstat.coutfoixSpeed)
        {
        Playerstat.UpgradeSpeed();
        Calculstat.SpeedUpgradeValueCost();
        UpgradeSound.Play();
    }
}
    public void UpgradeMaxHealthButton()
    {
        if (foix >= Calculstat.coutfoixHealhMax)
        {
            Playerstat.UpgradeMaxHp();
            Calculstat.HealthMaxUpgradeValueCost();
            UpgradeSound.Play();
    }
}
    public void UpgradeMaxManaButton()
    {
        if (foix >= Calculstat.coutfoixManaMax)
        {
            Playerstat.UpgradeMaxMana();
            Calculstat.ManaMaxUpgradeValueCost();
        UpgradeSound.Play();
    }
}
    public void UpgradeMaxStaminaButton()
    {
        if (foix >= Calculstat.coutfoixStaminaMax)
        {
            Playerstat.UpgradeMaxStamina();
            Calculstat.StaminaMaxUpgradeValueCost();
        UpgradeSound.Play();
    }
}
    public void UpgradeAttackButton()
    {
        if (foix >=Calculstat.coutfoixAttack)
        {
            Playerstat.UpgradeAttack();
            Calculstat.AttackUpgradeValueCost();
        UpgradeSound.Play();
            
    }
}
    public void BuyheatlhPotionButton()
    {
        if (foix >=5)
        { 
        Interfacejeu.HeathPotionBuy();
        UpgradeSound.Play();
        }
    }
    public void BuyManaPotionButton()
    {
        if (foix >= 5)
        {
            Interfacejeu.ManaPotionBuy();
            UpgradeSound.Play();
        }
    }
    public void BuyStaminaPutionButton()
    {
            if (foix >= 2.5)
            {
                Interfacejeu.StaminaPotionBuy();
                UpgradeSound.Play();
        }
    }
    public void UpgradeDefenceButton()
    {
        if (foix >= Calculstat.coutfoixDefence)
        {
            Playerstat.Upgradedefence();
            Calculstat.DefenceUpgradeValueCost();
        UpgradeSound.Play();
        }
    }
}

