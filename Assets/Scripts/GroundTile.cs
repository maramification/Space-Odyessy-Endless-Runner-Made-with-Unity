
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject bluePrefab;
    [SerializeField] GameObject greenPrefab;
    [SerializeField] GameObject redPrefab;
    float[] spawnPoints = { -2.1f, 0.0f, 2.1f };
    




    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
       

    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }


    public void SpawnItems()
    {
        
        int spawnAnotherCoin = Random.Range(0, 2);
        int spawnAnotherObstacle = Random.Range(0, 2);
       

        int obstacleSpawnIndex = Random.Range(2, 5);
        int newSpawnIndex = Random.Range(2, 5);



        float xPos = GetRandomXPosition();
        float xPos2 = GetRandomXPosition();
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        if (spawnAnotherObstacle == 1)
        {
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
        

        while (newSpawnIndex == obstacleSpawnIndex)
        {
            newSpawnIndex = Random.Range(2, 5);

            if (newSpawnIndex != obstacleSpawnIndex)
            {
                break; // exit loop when a different index is found
            }
        }

        Transform newObstacleSpawnPoint = transform.GetChild(newSpawnIndex).transform;


        while ((xPos2 == xPos) || (xPos2 == spawnPoint.position.x) || (xPos2 == newObstacleSpawnPoint.position.x))
        {
            xPos2 = GetRandomXPosition();

            if (xPos2 != xPos)
            {
                break; // exit loop when a different index is found
            }
        }



        int itemToSpawn = Random.Range(0, 4);
        float zPos = spawnPoint.position.z;

        if (itemToSpawn == 0)
        {
            GameObject temp = Instantiate(redPrefab, transform);
            temp.transform.position = new Vector3(xPos, 0.5f, zPos);
        }


        else if (itemToSpawn == 1)
            {
                GameObject temp = Instantiate(greenPrefab, transform);
                temp.transform.position = new Vector3(xPos, 0.5f, zPos);
            }


        else if (itemToSpawn == 2)
        {
            GameObject temp = Instantiate(bluePrefab, transform);
            temp.transform.position = new Vector3(xPos, 0.5f, zPos);
        }


        else 
            {
               
                Instantiate(obstaclePrefab, newObstacleSpawnPoint.position, Quaternion.identity, transform);

            }

           
        if (spawnAnotherCoin == 1)
        {
            itemToSpawn = Random.Range(0, 3);

            if (itemToSpawn == 0)
            {
                GameObject temp = Instantiate(redPrefab, transform);
                temp.transform.position = new Vector3(xPos2, 0.5f, zPos);
            }


            else if (itemToSpawn == 1)
            {
                GameObject temp = Instantiate(greenPrefab, transform);
                temp.transform.position = new Vector3(xPos2, 0.5f, zPos);
            }


            else
            {
                GameObject temp = Instantiate(bluePrefab, transform);
                temp.transform.position = new Vector3(xPos2, 0.5f, zPos);
            }
        }

           

        
    }



float GetRandomXPosition()
{
    int randomIndex = (int)Random.Range(0, spawnPoints.Length);
    return spawnPoints[randomIndex];
}
}
