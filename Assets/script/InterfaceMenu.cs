using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceMenu : MonoBehaviour
{
    public GameManager Gamemanager;
    public Button Retouraujeu;
    public Button Option;
    public MenuVolume menuVolume;
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = FindObjectOfType<GameManager>();

        Retouraujeu.onClick.AddListener(FermetureMenu) ;
        Option.onClick.AddListener(OvertureOption);
        gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void FermetureMenu()
    {
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
}
