using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameManager Gamemanager;
    public Button RetourauMenu;
   
   
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = FindObjectOfType<GameManager>();

        RetourauMenu.onClick.AddListener(FermetureMenu);
        
        gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Gamemanager.isGameOver ==true)
        {
            OuvertureMenu();
        }
    }
    public void FermetureMenu()
    {
        SceneManager.LoadScene("Intro");
      //a changer la scene pour activer le main menu

    }
    
    
    public void OuvertureMenu()
    {
        Gamemanager.PauseJeu();
        gameObject.SetActive(true);
    }
}
