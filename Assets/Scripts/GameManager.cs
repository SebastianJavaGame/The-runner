using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform camTransform;
    public Text textPoints;
    public Transform groundOne;
    public Transform groundTwo;
    public GameObject[] prefabsObstacles;

    private static List<GameObject> platforms;
    private int score;
    private List<Obstacle> obstacles;

    public static float LastPlatform { get; set; }

    void Start()
    {
        obstacles = new List<Obstacle>();
        platforms = new List<GameObject>();
        score = 0;
        InitializeObstacle();
        int firstObstacle = UnityEngine.Random.Range(0, obstacles.Count);
        platforms.Add(Instantiate(obstacles[firstObstacle].Prefab, new Vector3(UnityEngine.Random.Range(8, 20), obstacles[firstObstacle].PosY, 0), camTransform.rotation));
    }

    void Update()
    {
        if (groundOne.position.x < groundTwo.position.x)
        {
            if ((int)groundTwo.position.x == (int)camTransform.position.x - 8)
            {
                groundOne.position = new Vector2(groundTwo.position.x + 18f, groundOne.position.y);
            }
        }
        else
        {
            if ((int)groundOne.position.x == (int)camTransform.position.x - 8)
            {
                groundTwo.position = new Vector2(groundOne.position.x + 18, groundTwo.position.y);
            }
        }

        if (platforms.Count != 0)
        {
            foreach (var platform in platforms)
            {
                if (platform != null)
                    if (platform.transform.position.x < camTransform.position.x - 12 || platform.transform.position.y < camTransform.position.y - 8)
                    {
                        Destroy(platform);
                        platforms.Remove(platform);

                    }
            }
            Debug.Log(platforms.Count + " obstacles count");
        }

        SpawnGroundObstacles();
    }

    void SpawnGroundObstacles()
    {
        if (platforms.Count > 0 && platforms[0] != null)
            if (platforms.Count > 0 && camTransform.position.x > platforms[0].transform.position.x && platforms.Count < 2)
            {
                int randomSpawnX = UnityEngine.Random.Range(15, 30);
                int randomNumberObstacle = UnityEngine.Random.Range(0, obstacles.Count);
                platforms.Add(Instantiate(obstacles[randomNumberObstacle].Prefab, new Vector3(platforms[platforms.Count - 1].transform.position.x + randomSpawnX, obstacles[randomNumberObstacle].PosY, 0), camTransform.rotation));
            }
    }

    private void InitializeObstacle()
    {
        obstacles.Add(new Obstacle(1.2f, prefabsObstacles[0]));
        obstacles.Add(new Obstacle(1.3f, prefabsObstacles[1]));
    }
}
