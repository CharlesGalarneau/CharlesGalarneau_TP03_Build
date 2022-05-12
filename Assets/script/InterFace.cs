using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interface : MonoBehaviour
{

    public Button ManaButton;
    public Button HealingButton;
    public Button StaminaButton;
    // Start is called before the first frame update
    void Start()
    {
        ManaButton.onClick.AddListener(ManaButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManaButtonClicked()
    {

    }
    public void HealingButtonClicked()
    {

    }
    public void StaminaButtonClicked()
    {

    }
}
