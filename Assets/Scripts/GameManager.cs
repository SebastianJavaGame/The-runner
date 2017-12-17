using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform camTransform;
    public Text textPoints;

    private GameObject prefab;
    private static List<GameObject> platforms;
    private int score;

    public static float LastPlatform { get; set; }

    void Start()
    {
        score = 0;
        platforms = new List<GameObject>();
        InvokeRepeating("ChooseLevel", 1, 0.5f);
    }

    void Update()
    {
        if (BaseLevel.Steps[BaseLevel.ActualLevel].StepCount <= BaseLevel.StepRequired)
        {
            score = 0;
            BaseLevel.UpgradeLevel();
        }

        if (platforms.Count != 0)
        {
            foreach (var platform in platforms)
            {
                if (platform.transform.position.x < camTransform.position.x - 12 || platform.transform.position.y < camTransform.position.y - 8)
                {
                    Destroy(platform);
                    platforms.RemoveAt(0);
                }
            }
        }
    }

    void ChooseLevel()
    {
        if (platforms.Count == 0)
        {
            prefab = BaseLevel.Steps[BaseLevel.ActualLevel].Prefab;
            GameObject step = Instantiate(prefab, new Vector3(20f, -3f, 0f), camTransform.rotation);
            platforms.Add(step);
            BaseLevel.StepRequired++;
        }
        else if (platforms.Count < 6)
        {
            prefab = BaseLevel.Steps[BaseLevel.ActualLevel].Prefab;
            GameObject step = Instantiate(prefab, new Vector3(platforms[platforms.Count - 1].transform.position.x + BaseLevel.Steps[BaseLevel.ActualLevel].SpaceWidth,
                                                            platforms[platforms.Count - 1].transform.position.y + BaseLevel.Steps[BaseLevel.ActualLevel].SpaceHeight, 0), camTransform.rotation);
            platforms.Add(step);
            BaseLevel.StepRequired++;
        }

        score += BaseLevel.Steps[BaseLevel.ActualLevel].ScoreAdd;
        textPoints.text = "Score: " + score + " step: " + (BaseLevel.Steps[BaseLevel.ActualLevel].StepCount - BaseLevel.StepRequired);

        if (BaseLevel.ChangeLevel)
        {
            if (LastPlatform < camTransform.transform.position.x)
                BaseLevel.ChangeLevel = false;
        }
        else
        {
            if (platforms.Count > 0)
                LastPlatform = platforms[platforms.Count - 1].transform.position.x;
        }
    }

    public static List<Transform> GetPlatforms()
    {
        List<Transform> list = new List<Transform>();

        foreach (var element in platforms)
        {
            list.Add(element.gameObject.transform);
        }

        return list;
    }
}
