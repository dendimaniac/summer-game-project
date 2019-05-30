using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTilePos : MonoBehaviour
{
    [HideInInspector]
    public Tilemap tileMap = null;

    void Start()
    {
        tileMap = transform.GetComponentInParent<Tilemap>();
        MovementManagement.GetTilePos(tileMap);
    }
}
