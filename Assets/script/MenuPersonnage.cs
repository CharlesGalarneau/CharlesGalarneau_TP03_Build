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
    public Text TestMaxStamina;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        Playerstat = FindObjectOfType<PlayerStat>();
        Interfacejeu = FindObjectOfType<InterfaceJeu>();
        Retouraujeu.onClick.AddListener(FermetureMenu);
        UpgradeSpeed.onClick.AddListener(UpgradeSpeedButton);
        UpgradeAttack.onClick.AddListener(UpgradeAttackButton);
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
        Playerstat.UpgradeSpeed();
        UpgradeSound.Play();
    }
    public void UpgradeMaxHealthButton()
    {
        
        Playerstat.UpgradeMaxHp();
        UpgradeSound.Play();
    }
    public void UpgradeMaxManaButton()
    {
        Playerstat.UpgradeMaxMana();
        UpgradeSound.Play();
    }
    public void UpgradeMaxStaminaButton()
    {
        Playerstat.UpgradeMaxStamina();
        UpgradeSound.Play();
    }
    public void UpgradeAttackButton()
    {
        Playerstat.UpgradeAttack();
        UpgradeSound.Play();
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
}

