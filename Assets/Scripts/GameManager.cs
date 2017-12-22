using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform camTransform;
    public Text textPoints;
    public GameObject prefabSimpleObstacle;
    public Transform groundOne;
    public Transform groundTwo;

    private static List<GameObject> platforms;
    private float randomSpawnX;
    private int score;

    public static float LastPlatform { get; set; }

    void Start()
    {
        platforms = new List<GameObject>();
        randomSpawnX = UnityEngine.Random.Range(3, 10);
        score = 0;
        //platforms.Add(Instantiate(prefabSimpleObstacle, new Vector3(randomSpawnX, 1.3f, 0), camTransform.rotation));
    }

    void Update()
    {
        if (groundOne.position.x < groundTwo.position.x)
        {
            if ((int)groundTwo.position.x == (int)camTransform.position.x -8)
            {
                groundOne.position = new Vector2(groundTwo.position.x + 18f, groundOne.position.y);
            }
        }
        else
        {
            if ((int)groundOne.position.x == (int)camTransform.position.x -8)
            {
                groundTwo.position = new Vector2(groundOne.position.x + 18, groundTwo.position.y);
            }
        }

        if (platforms.Count != 0)
        {
            foreach (var platform in platforms)
            {
                if (platform.transform.position.x < camTransform.position.x - 12 || platform.transform.position.y < camTransform.position.y - 8)
                {
                    Destroy(platform);
                    platforms.Remove(platform);

                }
            }
            Debug.Log(platforms.Count + " obstacles count");
        }

        //SpawnSimpleObstacle();
    }

    void SpawnSimpleObstacle()
    {
        if(camTransform.position.x > prefabSimpleObstacle.transform.position.x && platforms.Count < 2)
        {
            randomSpawnX = UnityEngine.Random.Range(6, 15);
            platforms.Add(Instantiate(prefabSimpleObstacle, new Vector3(prefabSimpleObstacle.transform.position.x + randomSpawnX, 1.4f, 0), camTransform.rotation));
        }
    }
}
