using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class PlayerPos : ScriptableObject
{
    public List<float[]> positionList = new List<float[]>();
    // public float[] position;

    // public PlayerPos (Vector3 playerPos) {
    //     // position = new float[3];
    //     float[] newPos = new float[] {playerPos.x, playerPos.y, playerPos.z};
    //     positionList.Add(newPos);

    //     // position[0] = playerPos.x;
    //     // position[1] = playerPos.y;
    //     // position[2] = playerPos.z;
    // }
    public void AddNewPos(Vector3 newPos)
    {
        positionList.Add(new float[] { newPos.x, newPos.y, newPos.z });
    }
}