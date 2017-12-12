using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour {
    const int CountLevel = 2;

    public float[] width;
    public float[] height;
    public float[] spaceWidth;
    public float[] spaceHeight;

    public int[] scoreAdd;
    public float[] playerSpeed;

    public GameObject prefab;

    public static Platform[] Steps { get; set; }
    public static int ActualLevel { get; set; }
    public static bool ChangeLevel { get; set; }

    void Start()
    {
        ChangeLevel = false;
        ActualLevel = 0;

        Steps = new Platform[10];
        Steps[0] = new Platform(5.5f, 2f, 1, 5f, prefab);
        Steps[1] = new Platform(8f, 2.2f, 2, 8f, prefab);
    }

    public static void UpgradeLevel()
    {
        Platform.PlayerSpeedTemporary = Steps[ActualLevel].PlayerSpeed;
        ActualLevel++;
        ChangeLevel = true;
    }
}
