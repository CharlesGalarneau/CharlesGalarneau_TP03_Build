using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    public PlayerStat Playerstat;
    public float CoutMagicMissile = 5;
    public MagicMissile Magicmissile;
    public Transform Castpoints;
    public GameObject MagicMissileObject;
    public Ennemies ennemies;
    public AudioSource Sonmagie;
    public float CoutfoixShield = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Playerstat = FindObjectOfType<PlayerStat>();
        //Magicmissile = FindObjectOfType<MagicMissile>();

    }

    // Update is called once per frame
    void Update()
    {
        ennemies = FindObjectOfType<Ennemies>();
    }

    public void SpellMagicMissile()
    {
       
        
        if (Playerstat.mana >= CoutMagicMissile)
        {
            GameObject projectile = Instantiate(MagicMissileObject, Castpoints.position, Castpoints.rotation);
            MagicMissile bullet = projectile.GetComponent<MagicMissile>();
            //bullet.ReachEnnemies(ennemies.transform);
            Sonmagie.Play();


        }
    }
    void MagicMissileCost()
    {

    }
    public void FaithShield()
    {
        if (Playerstat.mana >= CoutfoixShield)
        {
            Playerstat.IsinvicibleSpell();
        }
    }
    public void CoutFaithShield()
    { }
}
