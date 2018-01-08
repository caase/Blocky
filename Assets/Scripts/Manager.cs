﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager instance = null;

    public static int highScore;
    public static int gemCount = 10;
    public static List<string> sceneOrder = new List<string>();

    public static bool soundEnabled;
    public static bool vibEnabled;

    public static List<int> colorList = new List<int>(); 
    public static List<int> circleList = new List<int>();

    public List<int> circleList2 = new List<int>();

    public static bool loadColors;
    public static int previousScore;

    void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance == null) {
            instance = this;
        }

        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("colorList_1"))
        {

            loadColors = true;

            colorList.Clear();
            for (int i = 0; i < PlayerPrefs.GetInt("colorListCount"); i++)
            {
                colorList.Add(-1);
            }
            for (int i = 1; i < colorList.Count; i++)
            {
                colorList[i] = PlayerPrefs.GetInt("colorList_" + i);
            }

            circleList.Clear();
            for (int i = 0; i < PlayerPrefs.GetInt("circleListCount"); i++)
            {
                circleList.Add(-1);
            }
            for (int i = 1; i < PlayerPrefs.GetInt("circleListCount"); i++)
            {
                circleList[i] = PlayerPrefs.GetInt("circleList_" + i);
            }
        }

        else 
        {
            loadColors = false;
        }

        if (PlayerPrefs.HasKey("previousScore")) {
            previousScore = PlayerPrefs.GetInt("previousScore");
        }

    }

    void Start()
    {
        if (PlayerPrefs.HasKey("soundEnabled")) {
            if (PlayerPrefs.GetInt("soundEnabled") == 1)
            {
                soundEnabled = true;
            }
            else
            {
                soundEnabled = false;
            }
        }

        if (PlayerPrefs.HasKey("vibEnabled"))
        {
            if (PlayerPrefs.GetInt("vibEnabled") == 1)
            {
                vibEnabled = true;
            }
            else
            {
                vibEnabled = false;
            }
        }

        if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else {
            highScore = 0;
        }
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }

    public static void SaveScene() 
    {
        PlayerPrefs.SetInt("colorListCount", colorList.Count);
        PlayerPrefs.SetInt("circleListCount", circleList.Count);

        for (int i = 1; i < colorList.Count; i++)
        {
            PlayerPrefs.SetInt("colorList_" + i, colorList[i]);
        }

        for (int i = 1; i < circleList.Count; i++)
        {
            PlayerPrefs.SetInt("circleList_" + i, circleList[i]);
        }

        PlayerPrefs.SetInt("previousScore", previousScore);
    }

    public static void SaveSoundSettings()
    {
        if (soundEnabled) {
            PlayerPrefs.SetInt("soundEnabled", 1);
        }
        else {
            PlayerPrefs.SetInt("soundEnabled", 0);
        }
    }

    public static void SaveVibSettings()
    {
        if (vibEnabled)
        {
            PlayerPrefs.SetInt("vibEnabled", 1);
        }
        else
        {
            PlayerPrefs.SetInt("vibEnabled", 0);
        }
    }
}

