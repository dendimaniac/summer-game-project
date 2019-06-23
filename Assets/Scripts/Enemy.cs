using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MovingObject
{
    public Transform player;
    private int currentIndex = 0;

    protected override void Start()
    {
        GameManager.instance.AddEnemyToList(this);
        base.Start();
    }

    public void moveEnemy()
    {
        if (positionList.Count == 0)
            return;
        int xDir = 0;
        int yDir = 0;
        Vector3 nextPos;
        nextPos = positionList[currentIndex + 1];
        xDir = Mathf.RoundToInt(nextPos.x - positionList[currentIndex].x);
        yDir = Mathf.RoundToInt(nextPos.y - positionList[currentIndex].y);
        AttemptMove(xDir, yDir);
        currentIndex++;
        if (currentIndex == positionList.Count - 1)
        {
            currentIndex = 0;
        }
    }

    protected override void AttemptMove(int xDir, int yDir)
    {
        base.AttemptMove(xDir, yDir);
    }

    protected override void OnCantMove<T>(T component)
    {
    }
}