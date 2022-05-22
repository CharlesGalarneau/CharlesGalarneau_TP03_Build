using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonLifeBar : MonoBehaviour
{
    public Ennemies ennemies;
    public  float MaxLifeValue;
    public Slider LifeBar;
    public GameManager Gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        ennemies = FindObjectOfType<Ennemies>();
        //ennemies = GetComponent<Ennemies>();
        Gamemanager = FindObjectOfType<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        MaxLifeValue = Gamemanager.NbRound * 2;
        LifeBar.maxValue = MaxLifeValue;
        LifeBar.value = ennemies.hitpoints;
    }
}
