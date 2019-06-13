using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isPlayerTurn;
    public bool isEnemyMoving;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        isPlayerTurn = true;
        isEnemyMoving = false;
    }
}