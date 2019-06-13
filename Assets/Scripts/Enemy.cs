using UnityEngine;

public class Enemy : MovingObject
{
    public Transform player;
    public PlayerPos moveRoute;
    private void Update()
    {
        if (player.position == new Vector3(-4, 0, 0))
        {
            Vector3 nextPos;
            for (int i = 0; i < moveRoute.positionList.Count; i++)
            {
                nextPos = new Vector3(moveRoute.positionList[i][0], moveRoute.positionList[i][1], moveRoute.positionList[i][2]);
                StartCoroutine(SmoothMovement(nextPos));
            }
        }
    }
    protected override void OnCantMove<T>(T component)
    {
    }
}