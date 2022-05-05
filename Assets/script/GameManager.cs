using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{


    public static GameManager instance;
    const float spawnZoneX = 6f;
    const float spawnZoneY = 0.6f;
    const float spawnZoneZ = 6f;
    public GameObject prefabSkeleton;
    public Transform player;
    public Transform spawnLocation;

    
    public GameObject txtGameOver;
    float spawnInterval = 5f;

    public bool isGameOver = false; //{ get; private set; }=false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        isGameOver = true;
        
        Time.timeScale = 0f;
    }


    IEnumerator Spawner()
    {
        while (true)
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
