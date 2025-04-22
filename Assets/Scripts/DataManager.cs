using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataManager : TruongDataAbstract<DataManager>
{
    private const string DefaultDataFileName = "DefaultData.json";

    protected override void OnDataLoaded()
    {
    }

    protected override void SetDefaultData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>($"Data/DefaultData");
        if (jsonFile != null)
        {
            this.gameData = JsonUtility.FromJson<TruongGameData>(jsonFile.text);
            Debug.Log("Loaded default data in resources");
        }
        else
        {
            Debug.LogError("Không tìm thấy file JSON trong Resources.");
        }
    }

    [Button]
    private void ImportSceneToData()
    {
        this.gameData.tilemap1.Clear();
        Environment.Instance.Tilemap1.Tiles.ForEach(tile => { this.gameData.tilemap1.Add(tile.Data); });

        this.gameData.tilemap2.Clear();
        Environment.Instance.Tilemap2.Tiles.ForEach(tile => { this.gameData.tilemap2.Add(tile.Data); });
    }

    [Button]
    public void CreateDefaultJson()
    {
        ImportSceneToData();
        string json = JsonUtility.ToJson(this.gameData, true);

        string folderPath = Application.dataPath + "/Resources/Data";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        File.WriteAllText(folderPath + $"/{DefaultDataFileName}", json);

        AssetDatabase.Refresh(); // Cập nhật Project view
        Debug.Log($"Saved {DefaultDataFileName} to Resources!");
    }
}