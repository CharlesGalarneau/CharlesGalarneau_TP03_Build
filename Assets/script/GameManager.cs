using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;
    public bool Paused;
    const float spawnZoneX = 10f;
    const float spawnZoneY = 0f;
    const float spawnZoneZ = 10f;
    public GameObject prefabSkeleton;
    public Transform player;
    public Transform spawnLocation;
    public InterfaceMenu interfaceMenu;
    public int NbRound =0;
    
    public GameObject txtGameOver;
    float spawnInterval = 5f;
    public InterfaceJeu Interfacejeu;
    public DeathMenu Deathmenu;
    public bool IsRoundOver;
    public int nbEnnemies;
    public GameObject obj;
    public float RoundDelay = 5f;
    

    public bool isGameOver = false; //{ get; private set; }=false;
    
    // Start is called before the first frame update
    void Start()
    {
       

        StopPauseJeu();
        Interfacejeu = FindObjectOfType<InterfaceJeu>();
        Deathmenu = FindObjectOfType<DeathMenu>();
        #if !UNITY_EDITOR && UNITY_WEBGL
        UnityEngine.WebGLInput.captureAllKeyboardInput = false;
        #endif
    }

    // Update is called once per frame
    void Update()
    {

        if (nbEnnemies ==0 && IsRoundOver)
        {
            IsRoundOver = false;
            Spawner();
           
        }
        
        instance = this;

        EndRound();


        if (Input.GetKeyDown(KeyCode.P))
        {
           
            interfaceMenu.OuvertureMenu();
        }
    }
  
    public void Spawner()
    {
        //for (int i = 0; i < NbRound * 2; i++)
        { 
            Vector3 location = new Vector3(Random.Range(-spawnZoneX, spawnZoneX), spawnZoneY, Random.Range(-spawnZoneZ, spawnZoneZ));
             new WaitForSeconds(1f);
             obj = Instantiate(prefabSkeleton, location, Quaternion.identity);
            nbEnnemies += 1;
            
           obj.GetComponent<Ennemies>().SetTarget(player);

        }

       
    }
    public void TakeDamageEnnemies()
    {
       FindObjectOfType<Ennemies>().Hit();
    }
   
    public void TakeDamage()
    {
        Debug.Log("player take Damage");
        FindObjectOfType<PlayerStat>().PlayerLoseLife();
    }
    public void GameOver()
    {
        isGameOver = true;
        Deathmenu.OuvertureMenu();
        Time.timeScale = 0;
        
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
    { if (nbEnnemies ==0)
        {
            StartCoroutine(RoundStartDelay());
           // if (RoundDelay <=1f)
            {
                IsRoundOver =true;
                NbRound++;
            }
        }
    }
    public void DeleteEnnemies()
    {
        nbEnnemies--;
        
            }
    IEnumerator RoundStartDelay()
    {
        RoundDelay -= Time.deltaTime;
        yield return RoundDelay;
    }
}   
