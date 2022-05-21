using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    public PlayerStat Playerstat;
    public float CoutMagicMissile = 20;
    public MagicMissile Magicmissile;
    public Transform Castpoints;
    public GameObject MagicMissileObject;
    // Start is called before the first frame update
    void Start()
    {
        Playerstat = FindObjectOfType<PlayerStat>();
        //Magicmissile = FindObjectOfType<MagicMissile>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpellMagicMissile()
    {
        if (Playerstat.mana >= CoutMagicMissile)
        {
            GameObject projectile = Instantiate(MagicMissileObject, Castpoints.position, Castpoints.rotation);
            MagicMissile bullet = projectile.GetComponent<MagicMissile>();
            //bullet.ReachEnnemies(Ennemies);
            //audioSource.PlayOneShot(Son, 0.5f);
            //AnimationTir.Play();

        }
    }
    void MagicMissileCost()
    {

    }
}
