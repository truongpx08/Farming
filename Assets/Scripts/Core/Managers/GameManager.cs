using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : TruongSingleton<GameManager>
{
    protected override void Start()
    {
        // Khởi tạo game
        DataManager.Instance.TryLoadLocalData((gameData) =>
        {
            InitializeEnvironment(gameData);
            InitializePlayer();
            InitializeFocus();
            ItemPanel.Instance.InitializeButtons();
            // ItemPanel.Instance.ItemButtons[0].OnButtonClicked();
        });
    }

    private void InitializeFocus()
    {
        FocusController.Instance.DisableModel();
    }

    private void InitializeEnvironment(TruongGameData gameData)
    {
        gameData.tilemap1.ForEach(tileData =>
        {
            var tile = Environment.Instance.Tile1Factory.SpawnTile(tileData);
            tile.SetData(tileData);
            Environment.Instance.Tilemap1.Tiles.Add(tile);
        });
        gameData.tilemap2.ForEach(tileData =>
        {
            var tile = Environment.Instance.Tile2Factory.SpawnTile(tileData);
            tile.SetData(tileData);
            Environment.Instance.Tilemap2.Tiles.Add(tile);
        });
    }


    private void InitializePlayer()
    {
        PlayerModel playerModel = new PlayerModel();
        PlayerController.Instance.Initialize(playerModel);
    }
}