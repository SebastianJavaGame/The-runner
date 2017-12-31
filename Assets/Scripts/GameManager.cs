using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform camTransform;
    public Transform groundOne;
    public Transform groundTwo;
    public GameObject coin;
    public GameObject[] prefabsObstacles;

    public static int CountObstacles { get; set; }
    public static float LastPlatform { get; set; }

    private List<Obstacle> obstacles;
    private List<GameObject> coins;
    private static List<GameObject> platforms;

    void Start()
    {
        obstacles = new List<Obstacle>();
        coins = new List<GameObject>();
        platforms = new List<GameObject>();
        InitializeObstacle();
        int firstObstacle = UnityEngine.Random.Range(0, 1);
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
                    if (platform.transform.position.x < camTransform.position.x - FallowCamera.disappearScreen)
                    {
                        Destroy(platform);
                        platforms.Remove(platform);
                    }
            }
            Debug.Log(platforms.Count + " obstacles count");
        }

        if(coins.Count != 0)
        {
            foreach(var coin in coins)
            {
                if(coin != null)
                {
                    if(coin.transform.position.x < camTransform.position.x - FallowCamera.disappearScreen)
                    {
                        Destroy(coin);
                        coins.Remove(coin);
                    }
                }
            }
        }

        SpawnGroundObstacles();
    }

    void SpawnGroundObstacles()
    {
        if (platforms.Count > 0 && platforms[0] != null)
            if (platforms.Count < 3)
            {
                float firstObstacle = platforms[platforms.Count - 1].transform.position.x;
                int randomSpawnX = UnityEngine.Random.Range(10, 30);
                int randomNumberObstacle = UnityEngine.Random.Range(0, Level.LevelRace +1);
                platforms.Add(Instantiate(obstacles[randomNumberObstacle].Prefab, new Vector3(platforms[platforms.Count - 1].transform.position.x + randomSpawnX, obstacles[randomNumberObstacle].PosY, 0), camTransform.rotation));
                float secondObstacle = platforms[platforms.Count - 1].transform.position.x;
                float spaceCoins = (secondObstacle - firstObstacle) / 3;

                for(int i = 0; i < 3; i++)
                {
                    coins.Add(Instantiate(coin, new Vector3((firstObstacle + (i+1) * spaceCoins) - spaceCoins /2, 1.5f, 0), camTransform.rotation));
                }
            }
    }

    private void InitializeObstacle()
    {
        obstacles.Add(new Obstacle(1.2f, prefabsObstacles[0]));
        obstacles.Add(new Obstacle(1.3f, prefabsObstacles[1]));
        obstacles.Add(new Obstacle(1.45f, prefabsObstacles[2]));
        obstacles.Add(new Obstacle(-0.2f, prefabsObstacles[3]));
        obstacles.Add(new Obstacle(11.5f, prefabsObstacles[4]));

        CountObstacles = obstacles.Count;
    }
}
