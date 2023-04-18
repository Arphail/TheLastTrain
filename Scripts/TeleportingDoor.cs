using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private PlayerTeleporter _teleporter;

    public void OnInteract()
    {
        _teleporter.Teleport(_destinationPoint);
    }
}
