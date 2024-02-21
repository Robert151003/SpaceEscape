using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] levels;

    public PlayerData(progressSaver player)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = player.levels[i];
        }
    }
}
