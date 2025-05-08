using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Sirenix.OdinInspector;

/// <summary>
/// Inherit this class to save and load data
/// </summary>
public abstract class DataAbstract<T> : TruongSingleton<T>
{
    [SerializeField] private string dataPath;
    [SerializeField] protected GameData gameData;
    public GameData GameData => gameData;

    protected override void SetVariableToDefault()
    {
        base.SetVariableToDefault();
        dataPath = Path.Combine(Application.persistentDataPath, TruongConstant.FILE_NAME);
    }

    public void TryLoadLocalData(Action<GameData> onComplete = null)
    {
        if (!File.Exists(dataPath))
        {
            Debug.Log("Init data");
            SetDefaultData();
            SaveData();
            OnDataLoaded();
            onComplete?.Invoke(this.gameData);
            return;
        }

        try
        {
            SetGameData();
            OnDataLoaded();
            onComplete?.Invoke(this.gameData);
            Debug.Log($"Load data successfully with path: \n  {dataPath}");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            SetDefaultData();
            SaveData();
            OnDataLoaded();
            onComplete?.Invoke(this.gameData);
        }
    }

    private void SetGameData()
    {
        string data = GetDataJson();
        string decrypted = TruongVirtual.XOROperator(data, TruongConstant.KEY);
        gameData = JsonUtility.FromJson<GameData>(decrypted);
    }

    protected abstract void OnDataLoaded();
    protected abstract void SetDefaultData();

    [Button]
    public void SaveData()
    {
        string origin = JsonUtility.ToJson(gameData);
        string encrypted = TruongVirtual.XOROperator(origin, TruongConstant.KEY);
        File.WriteAllText(dataPath, encrypted);
        Debug.Log("Save data \n " + dataPath);
    }

    private string GetDataJson()
    {
        return File.ReadAllText(dataPath);
    }
}