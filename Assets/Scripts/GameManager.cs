using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform camTransform;
    public Text textPoints;
    public GameObject[] prefabGroundObstacles;
    public Transform groundOne;
    public Transform groundTwo;

    private static List<GameObject> platforms;
    private float randomSpawnX;
    private int score;

    public static float LastPlatform { get; set; }

    void Start()
    {
        platforms = new List<GameObject>();
        randomSpawnX = UnityEngine.Random.Range(8, 20);
        score = 0;
        platforms.Add(Instantiate(prefabGroundObstacles[0], new Vector3(randomSpawnX, 1.3f, 0), camTransform.rotation));
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
        if (platforms[0] != null)
            if (platforms.Count > 0 && camTransform.position.x > platforms[0].transform.position.x && platforms.Count < 2)
            {
                randomSpawnX = UnityEngine.Random.Range(15, 30);
                platforms.Add(Instantiate(prefabGroundObstacles[UnityEngine.Random.Range(0, prefabGroundObstacles.Length)], new Vector3(platforms[platforms.Count - 1].transform.position.x + randomSpawnX, 1.3f, 0), camTransform.rotation));
            }
    }
}
