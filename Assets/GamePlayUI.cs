using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : TruongSingleton<GamePlayUI>
{
    [SerializeField] private InventoryPanel inventoryPanel;
    public InventoryPanel InventoryPanel => this.inventoryPanel;
    [SerializeField] private ItemPanel itemPanel;
    public ItemPanel ItemPanel => this.itemPanel;
}