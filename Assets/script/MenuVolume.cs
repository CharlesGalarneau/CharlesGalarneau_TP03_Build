using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class MenuVolume : MonoBehaviour
{
    public Button FermerButton;
    public Slider SonPrincipale;
    public Slider SonMusique;
    public Slider SonEffet;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        SonPrincipale.onValueChanged.AddListener(Sonprincipale) ;
        SonMusique.onValueChanged.AddListener(Sonmusique);
        SonEffet.onValueChanged.AddListener(Soneffet);
        FermerButton.onClick.AddListener(FermerMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sonprincipale(float value)
    {
        audioMixer.SetFloat("SonMaster", Mathf.Log(value) * 20f);
    }
    public void Sonmusique(float value)
    {
        audioMixer.SetFloat("SonMusique", Mathf.Log(value) * 20f);
    }
    public void Soneffet(float value)
    {
        audioMixer.SetFloat("SonEffet", Mathf.Log(value) * 20f);
    }
    public void FermerMenu()
    {
        Debug.Log("testson");
        gameObject.SetActive(false);
    }
    public void OuvertureMenuSon()
    {
        
        gameObject.SetActive(true);
    }
}
