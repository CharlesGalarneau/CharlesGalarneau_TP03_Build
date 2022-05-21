using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Button CommencerJeu;
    public Button OuvrirSon;
    public Button Instruction;
    public MenuVolume menuVolume;
    public InstructionMenu Instructionmenu;

    // Start is called before the first frame update
    void Start()
    {
       

        CommencerJeu.onClick.AddListener(CommencerJeuMenu);
        OuvrirSon.onClick.AddListener(OuvrirSonMenu);
        Instruction.onClick.AddListener(OuvertureMenuInstruction);
        gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public void CommencerJeuMenu()
    {
        SceneManager.LoadScene("SurvivalGame");
       
        //a changer la scene pour activer le main menu

    }


    public void OuvrirSonMenu()
    {

        menuVolume.OuvertureMenuSon();
    }
    public void OuvertureMenuInstruction()
    {

        Instructionmenu.OuvertureMenuInstruction();
    }
}
