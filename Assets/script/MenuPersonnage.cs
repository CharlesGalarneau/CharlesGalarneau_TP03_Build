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
    }
    public void UpgradeMaxHealthButton()
    {
        Playerstat.UpgradeMaxHp();
    }
    public void UpgradeMaxManaButton()
    {
        Playerstat.UpgradeMaxMana();
    }
    public void UpgradeMaxStaminaButton()
    {
        Playerstat.UpgradeMaxStamina();
    }
    public void UpgradeAttackButton()
    {
        Playerstat.UpgradeAttack();
    }
    public void BuyheatlhPotionButton()
    {
        Interfacejeu.HeathPotionBuy();
    }
    public void BuyManaPotionButton()
    {
        Interfacejeu.ManaPotionBuy();
    }
    public void BuyStaminaPutionButton()
    {
        Interfacejeu.StaminaPotionBuy();
    }
}

