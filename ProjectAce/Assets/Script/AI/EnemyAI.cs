using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public class EnemyAI : MonoBehaviour
{
    public float EnemySpeed;
    private PlayerFieldDeck fieldDeck;
    private int[,] rootHistory = new int[7,7];
    private EEnemyMoveCourse moveCourse;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fieldDeck.name);
    }

    private void Init()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y/2, transform.position.z);

        fieldDeck = transform.parent.parent.GetChild(1).GetComponent<PlayerFieldDeck>();
        for (int Num1 = 0; Num1 < 7; Num1++)
            for (int Num2 = 0; Num2 < 7; Num2++)
                rootHistory[Num1, Num2] = 0;
        moveCourse = EEnemyMoveCourse.Up;
    }

    private bool ComparePosition(Vector3 _pos1, Vector3 _pos2)
    {
        return _pos1 == _pos2 ? true : false;
    }

    private void Move()
    {
        switch (moveCourse)
        {
            case EEnemyMoveCourse.Up:
                break;

            case EEnemyMoveCourse.Down:
                break;

            case EEnemyMoveCourse.Left:
                break;

            case EEnemyMoveCourse.Right:
                break;
                 
            default:
                break;
        }
    }
}