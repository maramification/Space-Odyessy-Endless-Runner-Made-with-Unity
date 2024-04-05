
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    



    public void SpawnTile (bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;


        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnItems();
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i< 15; i++)
        {
            if (i < 1)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
          
        }
    }
}
