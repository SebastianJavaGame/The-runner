﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Slider slider;
    public Text textLevel;

    public static int LevelRace { get; set; }

    private int requreScoreToUpgrade;

    void Awake()
    {
        LevelRace = 1;
    }

    void Start()
    {
        requreScoreToUpgrade = 20;
        slider.wholeNumbers = true;
        slider.minValue = 0;
        slider.maxValue = requreScoreToUpgrade;
    }

    void Update()
    {
        UpgradeSlider();
        if (DeathCollision.ScoreSlider >= requreScoreToUpgrade && LevelRace < GameManager.CountObstacles)
            UpgradeLevel();
    }

    public void UpgradeLevel()
    {
        requreScoreToUpgrade = (int)(requreScoreToUpgrade * 1.8f);
        LevelRace++;
        textLevel.text = "Level " + LevelRace;
        slider.maxValue = requreScoreToUpgrade;
        DeathCollision.ScoreSlider = 0;
        Player.UpgradeSpeed();
    }

    public void UpgradeSlider()
    {
        slider.value = DeathCollision.ScoreSlider;
    }
}
