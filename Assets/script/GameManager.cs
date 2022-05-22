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
    public int nbEnnemies;
    public GameObject obj;

    public bool isGameOver = false; //{ get; private set; }=false;
    
    // Start is called before the first frame update
    void Start()
    {
        StopPauseJeu();
        Interfacejeu = FindObjectOfType<InterfaceJeu>();
        
        if (IsRoundOver == false) 
        {

            Spawner();

        }
        Spawner();
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
  
    public void Spawner()
    {
        for (int i = 0; i < NbRound * 2; i++)
        { 
            Vector3 location = new Vector3(Random.Range(-spawnZoneX, spawnZoneX), spawnZoneY, Random.Range(-spawnZoneZ, spawnZoneZ));
             new WaitForSeconds(spawnInterval);
             obj = Instantiate(prefabSkeleton, location, Quaternion.identity);
             }
        nbEnnemies += 1;
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
        Time.timeScale = 0;
        Paused = true;
    }
    public void StopPauseJeu()
    {
        Paused = false;
        Time.timeScale = 1;

    }

    public void EndRound()
    { if (IsRoundOver)
        {
            NbRound++;
        }
    }
    public void DeleteEnnemies()
    {
        nbEnnemies--;
        Destroy(obj.gameObject);
            }
}   
