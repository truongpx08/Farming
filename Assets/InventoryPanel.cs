using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slots = new();
    public List<InventorySlot> Slots => this.slots;
    [SerializeField] private InventoryActive active;
    public InventoryActive Active => this.active;
    [SerializeField] private InventoryInitializer initializer;
    public InventoryInitializer Initializer => this.initializer;
}