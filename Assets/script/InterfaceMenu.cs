using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceMenu : MonoBehaviour
{
    public GameManager Gamemanager;
    public Button Retouraujeu;
    public Button Option;
    public Button QuitterJeu;
    public MenuVolume menuVolume;
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = FindObjectOfType<GameManager>();

        Retouraujeu.onClick.AddListener(FermetureMenu) ;
        Option.onClick.AddListener(OvertureOption);
        QuitterJeu.onClick.AddListener(QuitterJeuMenu);
        gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void FermetureMenu()
    {
        Gamemanager.StopPauseJeu();
        gameObject.SetActive(false);
       
    }
    public void OvertureOption()
    {
        menuVolume.OuvertureMenuSon();
    }
    public void OuvertureMenu()
    {
        Gamemanager.PauseJeu();
        gameObject.SetActive(true);
    }
    public void QuitterJeuMenu()
    {
        SceneManager.LoadScene("Intro");
        //a changer la scene pour activer le main menu

    }
}
