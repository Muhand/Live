using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    // NOTE we are going to use integer to represent boolean variables
    //0 - False
    //1 - True
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }
    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(IsMusicOn);
    }

    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, difficulty);
    }
    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(EasyDifficulty);
    }

    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, difficulty);
    }
    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(MediumDifficulty);
    }
    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, difficulty);
    }
    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(HardDifficulty);
    }

    public static void SetEasyDifficultyHighScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, difficulty);
    }
    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, difficulty);
    }
    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyHighScore);
    }
    public static void SetHardDifficultyHighScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, difficulty);
    }
    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyHighScore);
    }

    public static void SetEasyDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, difficulty);
    }
    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, difficulty);
    }
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyCoinScore);
    }
    public static void SetHardDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, difficulty);
    }
    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyCoinScore);
    }
}
