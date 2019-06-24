using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector] public bool isPlayerTurn = true;
    private bool isEnemyMoving = false;
    [SerializeField] private float turnDelay = 0.1f;
    public List<float[]> positionList = new List<float[]>();
    public List<Enemy> enemiesList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        enemiesList = new List<Enemy>();
    }

    private void Update()
    {
        //Check that isPlayerTurn or isEnemyMoving or doingSetup are not currently true.
        if (isPlayerTurn || isEnemyMoving)
            //If any of these are true, return and do not start MoveEnemies.
            return;

        //Start moving enemies.
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy enemyScript)
    {
        enemiesList.Add(enemyScript);
    }

    public void PassMoveRoute(List<Vector3> moveRoute)
    {
        for (int i = 0; i < moveRoute.Count; i++)
        {
            if (enemiesList[i].positionList.Count > 0)
                continue;
            enemiesList[i].positionList = moveRoute;
            break;
        }
    }

    private IEnumerator MoveEnemies()
    {
        //While enemiesMoving is true player is unable to move.
        isEnemyMoving = true;

        //Wait for turnDelay seconds, defaults to .1 (100 ms).
        yield return new WaitForSeconds(turnDelay);

        //If there are no enemies spawned (IE in first level):
        if (enemiesList.Count == 0)
        {
            //Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
            yield return new WaitForSeconds(turnDelay);
        }

        //Loop through List of Enemy objects.
        for (int i = 0; i < enemiesList.Count; i++)
        {
            //Call the MoveEnemy function of Enemy at index i in the enemies List.
            enemiesList[i].moveEnemy();

            //Wait for Enemy's moveTime before moving next Enemy, 
            yield return new WaitForSeconds(enemiesList[i].moveTime);
        }
        //Once Enemies are done moving, set playersTurn to true so player can move.
        isPlayerTurn = true;

        //Enemies are done moving, set isEnemyMoving to false.
        isEnemyMoving = false;
    }
}