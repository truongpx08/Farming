using System;
using UnityEngine;

public class ParentRotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    private Transform target;

    private void Start()
    {
        this.target = transform.parent;
    }

    [ContextMenu("Rotate 90 Degrees")]
    public void Rotate90Degrees()
    {
        this.target.Rotate(rotationAxis, 90f);
    }
}