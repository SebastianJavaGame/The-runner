using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public float SpaceWidth { get; }
    public float SpaceHeight { get; }

    public int ScoreAdd { get; }
    public float PlayerSpeed { get; }

    public GameObject Prefab { get; }

    public static float PlayerSpeedTemporary { get; set; }

    public Platform(float spaceWidth, float spaceHeight, int scoreAdd, float playerSpeed, GameObject prefab)
    {
        SpaceWidth = spaceWidth;
        SpaceHeight = spaceHeight;
        ScoreAdd = scoreAdd;
        PlayerSpeed = playerSpeed;
        Prefab = prefab;
    }
}
