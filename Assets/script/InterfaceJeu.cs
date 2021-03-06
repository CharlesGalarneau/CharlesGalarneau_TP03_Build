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
    public Text GameOver;
    public int NbHealthPotion = 1;
    public int NbManaPotion =1;
    public int NbStaminaPotion=1 ;
    public Slider StaminaBar;
    public Slider ManaBar;
    public Slider HealthBar;
    public GameManager gameManager;
    public Button MenuPersonnageButton;
    public MenuPersonnage Menupersonnage;
    public AudioSource DrinkingSound;
   

    // Start is called before the first frame update
    void Start()
    {
        ManaButton.onClick.AddListener(ManaButtonClicked);
        MenuPersonnageButton.onClick.AddListener(MenuPersonnageButtonClicked);
        HealingButton.onClick.AddListener(HealingButtonClicked);
        StaminaButton.onClick.AddListener(StaminaButtonClicked);
        playerStat = FindObjectOfType<PlayerStat>();
        gameManager = FindObjectOfType<GameManager>();
       // Menupersonnage = FindObjectOfType<MenuPersonnage>();
       
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
        ManaBar.value = playerStat.mana;
        ManaBar.maxValue = playerStat.manaMax;
        StaminaBar.maxValue = playerStat.StaminaMax;
        HealthBar.maxValue = playerStat.HpMax;
        StaminaBar.value = playerStat.Stamina;
        HealthBar.value = playerStat.Hp;
    }
    public void ManaButtonClicked()
    {
        if (NbManaPotion > 0)
        {
            DrinkingSound.Play();
            AnimationMana.Play();
            NbManaPotion--;

        playerStat.ManaHealing();
        }
    }
    public void HealingButtonClicked()
    {
        if (NbHealthPotion > 0)
        {
            DrinkingSound.Play();
            AnimationHealth.Play();
            playerStat.HealthHealing();
            NbHealthPotion--;
        }
    }
    public void StaminaButtonClicked()
    {
        if (NbStaminaPotion > 0)
        {
            DrinkingSound.Play();
            AnimationStamina.Play();
        playerStat.StaminaHealing();
            NbStaminaPotion--;
        }
    
    }
    public void StaminaPotionBuy()
    {
        NbStaminaPotion++;
        playerStat.foix -= 2.5f;
    }
    public void ManaPotionBuy()
    {
        NbManaPotion++;
        playerStat.foix -= 5f;
    }
    public void HeathPotionBuy()
    {

        NbHealthPotion++;
        playerStat.foix -= 5;

    }
    public void IsGameOver()
    {
        if (gameManager.isGameOver)
        {
            this.gameObject.SetActive(false);
           
        }
    }
    public void MenuPersonnageButtonClicked()
    {
        Menupersonnage.OuvertureMenu();
    }
}
