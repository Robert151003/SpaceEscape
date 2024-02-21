using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressSaver : MonoBehaviour
{
    [Header("Level Completion")]
    public bool[] levels;

    private void Awake()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        for (int i = 0; i < data.levels.Length; i++)
        {
            levels[i] = data.levels[i];
        }
    }
}
