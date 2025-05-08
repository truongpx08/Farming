using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataManager : DataAbstract<DataManager>
{
    private const string DefaultDataFileName = "DefaultData.json";

    protected override void Start()
    {
        StartCoroutine(AutoSaveRoutine());
    }

    private IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            ImportSceneToData();
            SaveData();
            Debug.Log("Auto-saved game data!");
        }
    }

    protected override void OnDataLoaded()
    {
    }

    protected override void SetDefaultData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>($"Data/DefaultData");
        if (jsonFile != null)
        {
            this.gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
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
        this.gameData = new GameData();
        Environment.Instance.Tilemap1.Tiles.ForEach(tile => { this.gameData.tilemap1.Add(tile.Data); });
        Environment.Instance.Tilemap2.Tiles.ForEach(tile => { this.gameData.tilemap2.Add(tile.Data); });
        GamePlayUI.Instance.InventoryPanel.Slots.ForEach(slot =>
            this.gameData.inventoryData.items.Add(slot.Item != null ? slot.Item.ItemData.Data : null));
    }

    [Button]
    public void CreateDefaultJson()
    {
        string json = JsonUtility.ToJson(this.gameData, true);

        string folderPath = Application.dataPath + "/Resources/Data";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        File.WriteAllText(folderPath + $"/{DefaultDataFileName}", json);

        AssetDatabase.Refresh(); // Cập nhật Project view
        Debug.Log($"Saved {DefaultDataFileName} to Resources!");
    }

    private void OnApplicationQuit()
    {
        ImportSceneToData();
        SaveData();
    }
}