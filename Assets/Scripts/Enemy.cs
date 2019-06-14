using UnityEngine;
using System.Collections;

public class Enemy : MovingObject
{
    public Transform player;
    public PlayerPos moveRoute;
    private bool isMoving = false;
    private bool isDoneMoving = false;
    private void Update()
    {
        if (player.position == new Vector3(-4, 0, 0) && !isDoneMoving)
        {
            if (!isMoving)
                StartCoroutine(toFollow());
        }
    }
    private IEnumerator toFollow()
    {
        isMoving = true;
        Vector3 nextPos;
        for (int i = 0; i < moveRoute.positionList.Count; i++)
        {
            nextPos = new Vector3(moveRoute.positionList[i][0], moveRoute.positionList[i][1], moveRoute.positionList[i][2]);
            if (i == moveRoute.positionList.Count - 1)  isDoneMoving = true;
            yield return StartCoroutine(SmoothMovement(nextPos));
        }
        isMoving = false;
    }
    protected override void OnCantMove<T>(T component)
    {
    }
}