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
    private int[] currFieldLocation = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Init()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y/2, transform.position.z);

        fieldDeck = transform.parent.parent.GetChild(1).GetComponent<PlayerFieldDeck>();
        for (int Num1 = 0; Num1 < 7; Num1++)
            for (int Num2 = 0; Num2 < 7; Num2++)
            {
               switch (fieldDeck.GetFieldMap(Num1, Num2))
                {
                    case EFieldState.Enemy_Start:
                        currFieldLocation[0] = Num1;
                        currFieldLocation[1] = Num2;
                        rootHistory[Num1, Num2] = 1;
                        break;

                    case EFieldState.Empty:
                    case EFieldState.Ally:
                        rootHistory[Num1, Num2] = -1;
                        break;

                    case EFieldState.Enemy:
                    case EFieldState.Enemy_End:
                        rootHistory[Num1, Num2] = 0;
                        break;

                    default:
                        Debug.Log("Field State Is Wrong! Pos[ " + Num1 + ", " + Num2 + " ]");
                        break;
                }
            }
        moveCourse = EEnemyMoveCourse.Up; // 임시처리 사항
    }

    private bool ComparePosition(Vector3 _pos1, Vector3 _pos2)
    {
        return _pos1 == _pos2 ? true : false;
    }

    private EEnemyMoveCourse MoveCourceCheck()
    {
        //맵의 한계점 체크
        int _upValue = (currFieldLocation[0] == 6) ? -1 : 0;
        int _downValue = (currFieldLocation[0] == 0) ? -1 : 0;
        int _leftValue = (currFieldLocation[1] == 0) ? -1 : 0;
        int _rightValue = (currFieldLocation[1] == 6) ? -1 : 0;

        //방향별로 Empty 필드가 위치했는지 체크
        if (_upValue != -1) _upValue = (fieldDeck.GetFieldMap(currFieldLocation[0] + 1, currFieldLocation[1]) != EFieldState.Enemy) ? -1 : _upValue;
        if (_downValue != -1) _upValue = (fieldDeck.GetFieldMap(currFieldLocation[0] - 1, currFieldLocation[1]) != EFieldState.Enemy) ? -1 : _downValue;
        if (_leftValue != -1) _upValue = (fieldDeck.GetFieldMap(currFieldLocation[0], currFieldLocation[1] - 1) != EFieldState.Enemy) ? -1 : _leftValue;
        if (_rightValue != -1) _rightValue = (fieldDeck.GetFieldMap(currFieldLocation[0], currFieldLocation[1] + 1) != EFieldState.Enemy) ? -1 : _rightValue;

        //이동 가능한 경로가 없을 경
        if (_upValue == -1 && _downValue == -1 && _leftValue == -1 && _rightValue == -1)
        {
            Debug.Log("There Are No Pathes That Can Be Moved!");
            return EEnemyMoveCourse.Stop;
        }

        //방향별 히스토리 체크
        int _up = MoveHistoryCheck(EEnemyMoveCourse.Up);
        int _down = MoveHistoryCheck(EEnemyMoveCourse.Down);
        int _left = MoveHistoryCheck(EEnemyMoveCourse.Left);
        int _right = MoveHistoryCheck(EEnemyMoveCourse.Right);
        int _sumValue = 0;
            _sumValue += (_upValue != -1) ? _up : 0;
            _sumValue += (_downValue != -1) ? _down : 0;
            _sumValue += (_leftValue != -1) ? _left : 0;
            _sumValue += (_rightValue != -1) ? _right : 0;



        int _resultValue = Mathf.RoundToInt(Random.value * _sumValue - 0.5f);

        if (_sumValue / _up > 0)
        {
            //if (_up )
        }

        return EEnemyMoveCourse.Right;
    }

    private int MoveHistoryCheck(EEnemyMoveCourse _moveCource)
    {
        int _value = 0;

        int[] _checkPos = new int[2];
        _checkPos = currFieldLocation;

        int[] _plusPos = new int[2] { 0, 0 };
        _plusPos[0] = (_moveCource == EEnemyMoveCourse.Up) ? 1 : (_moveCource == EEnemyMoveCourse.Down) ? -1 : 0;
        _plusPos[1] = (_moveCource == EEnemyMoveCourse.Right) ? 1 : (_moveCource == EEnemyMoveCourse.Left) ? -1 : 0;

        while(true)
        {
            _checkPos[0] += _plusPos[0];
            _checkPos[1] += _plusPos[1];

            if (_checkPos[0] < 7 && _checkPos[1] < 7 && _checkPos[0] > -1 && _checkPos[1] > -1)
                return _value;

            if (fieldDeck.GetFieldMap(_checkPos[0], _checkPos[1]) != EFieldState.Enemy)
                return _value;

            _value += rootHistory[_checkPos[0], _checkPos[1]];
        }
    }

    private void Move()
    {
        switch (moveCourse)
        {
            case EEnemyMoveCourse.Up:
                SetPosition(this.transform, "z", +EnemySpeed);
                break;

            case EEnemyMoveCourse.Down:
                SetPosition(this.transform, "z", -EnemySpeed);
                break;

            case EEnemyMoveCourse.Left:
                SetPosition(this.transform, "x", -EnemySpeed);
                break;

            case EEnemyMoveCourse.Right:
                SetPosition(this.transform, "x", +EnemySpeed);
                break;
                 
            default:
                break;
        }
    }

    private void SetPosition(Transform _objTransform, string _axis, float _value)
    {
        switch (_axis)
        {
            case "x": case "X":
                _objTransform.position = new Vector3(_objTransform.position.x + _value, _objTransform.position.y, _objTransform.position.z);
                break;

            case "y": case "Y":
                _objTransform.position = new Vector3(_objTransform.position.x, _objTransform.position.y + _value, _objTransform.position.z);
                break;

            case "z": case "Z":
                _objTransform.position = new Vector3(_objTransform.position.x, _objTransform.position.y, _objTransform.position.z + _value);
                break;

            default:
                Debug.Log("Invalid [ _axis ] Value Input (Must Input X or Y or Z)");
                break;
        }
    }
}