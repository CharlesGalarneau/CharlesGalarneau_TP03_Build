using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    public static GameManager instance;
    public bool Paused;
    const float spawnZoneX = 6f;
    const float spawnZoneY = 0f;
    const float spawnZoneZ = 6f;
    public GameObject prefabSkeleton;
    public Transform player;
    public Transform spawnLocation;
    public InterfaceMenu interfaceMenu;
    public int NbRound =1;
    
    public GameObject txtGameOver;
    float spawnInterval = 5f;
    public InterfaceJeu Interfacejeu;
    public bool IsRoundOver;

    public bool isGameOver = false; //{ get; private set; }=false;
    
    // Start is called before the first frame update
    void Start()
    {
        Interfacejeu = FindObjectOfType<InterfaceJeu>();
        if (IsRoundOver == false) 
        { 
        StartCoroutine(Spawner());
        }
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            interfaceMenu.OuvertureMenu();
        }
    }
  


    IEnumerator Spawner()
    {
        while (true)
        {
            for (int i = 0; i < NbRound; i++)
            {

           
            // Déterminer la position du zombie
            Vector3 location = new Vector3(Random.Range(-spawnZoneX, spawnZoneX), spawnZoneY, Random.Range(-spawnZoneZ, spawnZoneZ));

            // Un indicateur circulaire apparaitra à cette position pour que le joueur puisse s'en éloigner
            Vector3 indicatorLocation = location;
            indicatorLocation.y = 0.03f;
            spawnLocation.position = indicatorLocation;

            // Attendre un léger interval avant de le faire spawn
            yield return new WaitForSeconds(spawnInterval);

            // Spawn du zombie
            GameObject obj = Instantiate(prefabSkeleton, location, Quaternion.identity).gameObject;

            // Dire au zombie de pourchasser le joueur
            obj.GetComponent<Ennemies>().SetTarget(player);

            spawnInterval -= 0.25f;

            if (spawnInterval < 1f)
                spawnInterval = 1f;
            }
        }

    }
    public void TakeDamage()
    {
        Debug.Log("player take Damage");
        FindObjectOfType<PlayerStat>().PlayerLoseLife();
    }
    public void GameOver()
    {
        isGameOver = true;
        Interfacejeu.IsGameOver();
        StopAllCoroutines();
        
    }
    public void PauseJeu()
    {
        Paused = true;
        
    }
    public void StopPauseJeu()
    {
        Paused = false;

    }

    public void EndRound()
    { if (IsRoundOver)
        {
            NbRound++;
        }
    }
}   
