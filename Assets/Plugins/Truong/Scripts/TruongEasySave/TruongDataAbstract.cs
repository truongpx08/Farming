using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

/// <summary>
/// Inherit this class to save and load data
/// </summary>
public abstract class TruongDataAbstract<T> : TruongSingleton<T>
{
    [SerializeField] private string dataPath;
    [SerializeField] protected TruongGameData gameData;
    public TruongGameData GameData => gameData;

    protected override void SetVariableToDefault()
    {
        base.SetVariableToDefault();
        dataPath = Path.Combine(Application.persistentDataPath, TruongConstant.FILE_NAME);
    }

    public void TryLoadLocalData(Action<TruongGameData> onComplete)
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
        gameData = JsonUtility.FromJson<TruongGameData>(decrypted);
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

    private void OnApplicationQuit()
    {
        SaveData();
    }
}