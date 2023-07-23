using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string EFFECT_VOLUME_KEY = "effect volume";
    const string LEVEL_ONE_KEY = "level one";
    const string LEVEL_TWO_KEY = "level two";
    const string LEVEL_THREE_KEY = "level three";
    const string LEVEL_FOUR_KEY = "level four";
    const string LEVEL_FIVE_KEY = "level five";
    const string LEVEL_SIX_KEY = "level six";
    const string LEVEL_SEVEN_KEY = "level seven";
    const string LEVEL_EIGHT_KEY = "level eight";
    const string LEVEL_NINE_KEY = "level nine";
    const string LEVEL_TEN_KEY = "level ten";
    const string LEVEL_ELEVEN_KEY = "level eleven";
    const string LEVEL_TWELVE_KEY = "level twelve";
    const string LEVEL_THIRTEEN_KEY = "level thirteen";
    const string LEVEL_FOURTEEN_KEY = "level fourteen";
    const string LEVEL_FIFTEEN_KEY = "level fifteen";
    const string LEVEL_SIXTEEN_KEY = "level sixteen";
    const string LEVEL_SEVENTEEN_KEY = "level seventeen";
    const string LEVEL_EIGHTEEN_KEY = "level eighteen";
    const string LEVEL_NINETEEN_KEY = "level nineteen";
    const string LEVEL_TWENTY_KEY = "level twenty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;


    public static void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME));
    }
    public static float GetMasterVolume()
    {
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
        {
            return .8f;
        }
        else
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }      
    }

    public static void SetEffectVolume(float volume)
    {
        PlayerPrefs.SetFloat(EFFECT_VOLUME_KEY, Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME));
    }
    public static float GetEffectVolume()
    {
        if (!PlayerPrefs.HasKey(EFFECT_VOLUME_KEY))
        {
            return .8f;
        }
        return PlayerPrefs.GetFloat(EFFECT_VOLUME_KEY);

    }

    public static int GetLevelState(int level)
    {
        switch (level)
        {
            case 1:
                if (!PlayerPrefs.HasKey(LEVEL_ONE_KEY))
                {
                    return 1;
                }
                return PlayerPrefs.GetInt(LEVEL_ONE_KEY);
            case 2:
                return PlayerPrefs.GetInt(LEVEL_TWO_KEY);
            case 3:
                return PlayerPrefs.GetInt(LEVEL_THREE_KEY);
            case 4:
                return PlayerPrefs.GetInt(LEVEL_FOUR_KEY);
            case 5:
                return PlayerPrefs.GetInt(LEVEL_FIVE_KEY);
            case 6:
                return PlayerPrefs.GetInt(LEVEL_SIX_KEY);
            case 7:
                return PlayerPrefs.GetInt(LEVEL_SEVEN_KEY);
            case 8:
                return PlayerPrefs.GetInt(LEVEL_EIGHT_KEY);
            case 9:
                return PlayerPrefs.GetInt(LEVEL_NINE_KEY);
            case 10:
                return PlayerPrefs.GetInt(LEVEL_TEN_KEY);
            case 11:
                return PlayerPrefs.GetInt(LEVEL_ELEVEN_KEY);
            case 12:
                return PlayerPrefs.GetInt(LEVEL_TWELVE_KEY);
            case 13:
                return PlayerPrefs.GetInt(LEVEL_THIRTEEN_KEY);
            case 14:
                return PlayerPrefs.GetInt(LEVEL_FOURTEEN_KEY);
            case 15:
                return PlayerPrefs.GetInt(LEVEL_FIFTEEN_KEY);
            case 16:
                return PlayerPrefs.GetInt(LEVEL_SIXTEEN_KEY);
            case 17:
                return PlayerPrefs.GetInt(LEVEL_SEVENTEEN_KEY);
            case 18:
                return PlayerPrefs.GetInt(LEVEL_EIGHTEEN_KEY);
            case 19:
                return PlayerPrefs.GetInt(LEVEL_NINETEEN_KEY);
            case 20:
                return PlayerPrefs.GetInt(LEVEL_TWENTY_KEY);
            default:
                Debug.LogError("Invalid level number");
                return -1;
        }
    }

    public static void SetLevelsState(int level, int state)
    {
        switch (level)
        {
            case 1:
                PlayerPrefs.SetInt(LEVEL_ONE_KEY, state);
                break;
            case 2:
                PlayerPrefs.SetInt(LEVEL_TWO_KEY, state);
                break;
            case 3:
                PlayerPrefs.SetInt(LEVEL_THREE_KEY, state);
                break;
            case 4:
                PlayerPrefs.SetInt(LEVEL_FOUR_KEY, state);
                break;
            case 5:
                PlayerPrefs.SetInt(LEVEL_FIVE_KEY, state);
                break;
            case 6:
                PlayerPrefs.SetInt(LEVEL_SIX_KEY, state);
                break;
            case 7:
                PlayerPrefs.SetInt(LEVEL_SEVEN_KEY, state);
                break;
            case 8:
                PlayerPrefs.SetInt(LEVEL_EIGHT_KEY, state);
                break;
            case 9:
                PlayerPrefs.SetInt(LEVEL_NINE_KEY, state);
                break;
            case 10:
                PlayerPrefs.SetInt(LEVEL_TEN_KEY, state);
                break;
            case 11:
                PlayerPrefs.SetInt(LEVEL_ELEVEN_KEY, state);
                break;
            case 12:
                PlayerPrefs.SetInt(LEVEL_TWELVE_KEY, state);
                break;
            case 13:
                PlayerPrefs.SetInt(LEVEL_THIRTEEN_KEY, state);
                break;
            case 14:
                PlayerPrefs.SetInt(LEVEL_FOURTEEN_KEY, state);
                break;
            case 15:
                PlayerPrefs.SetInt(LEVEL_FIFTEEN_KEY, state);
                break;
            case 16:
                PlayerPrefs.SetInt(LEVEL_SIXTEEN_KEY, state);
                break;
            case 17:
                PlayerPrefs.SetInt(LEVEL_SEVENTEEN_KEY, state);
                break;
            case 18:
                PlayerPrefs.SetInt(LEVEL_EIGHTEEN_KEY, state);
                break;
            case 19:
                PlayerPrefs.SetInt(LEVEL_NINETEEN_KEY, state);
                break;
            case 20:
                PlayerPrefs.SetInt(LEVEL_TWENTY_KEY, state);
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

}