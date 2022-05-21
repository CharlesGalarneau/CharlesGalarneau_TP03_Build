using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionMenu : MonoBehaviour
{
    public Button FermerMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        FermerMenuButton.onClick.AddListener(FermerMenu);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FermerMenu()
    {

        gameObject.SetActive(false);
    }
    public void OuvertureMenuInstruction()
    {

        gameObject.SetActive(true);
    }
}
