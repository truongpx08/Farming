using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FocusController : TruongSingleton<FocusController>
{
    [SerializeField] private GameObject model;
    public Tile2 TargetTile { get; private set; }

    protected override void FixedUpdate()
    {
        if (PlayerController.Instance.InputHandler.MoveDirection == Vector3.zero) return;
        var currentItem = PlayerController.Instance.CurrentItemController.CurrentItem;
        if (currentItem == null) return;

        switch (currentItem.type)
        {
            case ItemType.None:
                break;
            case ItemType.Rotation:
                NearestTileFinder nearestTileFinder = new NearestTileFinder();
                Tile2 nearestTile2 = nearestTileFinder.GetNearestTile2InFront();

                if (nearestTile2 != null && nearestTile2.Data.isOwnedByPlayer &&
                    (currentItem.usableTile2Types.Contains(Tile2Type.All) ||
                     currentItem.usableTile2Types.Contains(nearestTile2.Data.type)))
                {
                    this.model.SetActive(true);
                    this.transform.position = new Vector3(nearestTile2.Data.position.x, 0,
                        nearestTile2.Data.position.z);
                    this.TargetTile = nearestTile2;
                    return;
                }

                DisableModel();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void DisableModel()
    {
        this.model.SetActive(false);
    }
}