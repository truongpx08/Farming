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
        });
    }

    private void InitializeEnvironment(TruongGameData gameData)
    {
        gameData.tilemap1.ForEach(tile1Data => { Environment.Instance.Tile1Factory.SpawnTile(tile1Data); });
        gameData.tilemap2.ForEach(tile2Data => { Environment.Instance.Tile2Factory.SpawnTile(tile2Data); });
    }


    private void InitializePlayer()
    {
        PlayerModel playerModel = new PlayerModel();
        PlayerController.Instance.Initialize(playerModel);
    }
}