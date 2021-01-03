using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonEnum;

public class GameRules : MonoBehaviour
{
    public GameObject[] Player = new GameObject[2];
    public GameObject[] ShadowObject = new GameObject[2];
    public GameObject[] EnemyObject = new GameObject[1];
    private GameObject[] PlayerEnemy = new GameObject[2];
    private float[] RotationAngle = new float[2];
    private float[] RotationSpeed = new float[2];
    private bool PlayerSwitch;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5.0f)
        {
            EnemySpawn(EnemyObject[0]);
            timer = 0.0f;
        }
        ShadowRotation();
    }

    private void Init()
    {
        PlayerEnemy[0] = GetChildObject(Player[0], "Enemy");
        PlayerEnemy[1] = GetChildObject(Player[1], "Enemy");

        RotationAngle[0] = 0.0f;
        RotationSpeed[0] = 0.1f;

        RotationAngle[1] = 0.0f;
        RotationSpeed[1] = 0.2f;

        Player[0].SetActive(true);
        Player[1].SetActive(false);

        PlayerSwitch = true;
    }

    //Player 1,2 모두 적 스폰
    private void EnemySpawn(GameObject _enemyObject)
    {
        PlayerFieldDeck[] _playerFieldDeck = new PlayerFieldDeck[2];
        _playerFieldDeck[0] = GetChildObject(Player[0], "Field").GetComponent<PlayerFieldDeck>();
        _playerFieldDeck[1] = GetChildObject(Player[1], "Field").GetComponent<PlayerFieldDeck>();

        GameObject _targetParent1;
        GameObject _targetParent2;

        GameObject _enemyClone1;
        GameObject _enemyClone2;

        for (int Num1 = 0; Num1 < 7; Num1++)
            for(int Num2 = 0; Num2 < 7; Num2++)
            {
                if(_playerFieldDeck[0].FieldMap[Num1,Num2] == EFieldState.Enemy_Start)
                {
                    _targetParent1 = _playerFieldDeck[0].transform.GetChild(Num1 + 1).gameObject;
                    _targetParent1 = _targetParent1.transform.GetChild(Num2).gameObject;

                    _enemyClone1 = Instantiate(_enemyObject, _targetParent1.transform.position, _targetParent1.transform.rotation);
                    _enemyClone1.transform.SetParent(PlayerEnemy[0].transform);
                }

                if (_playerFieldDeck[1].FieldMap[Num1, Num2] == EFieldState.Enemy_Start)
                {
                    _targetParent2 = _playerFieldDeck[1].transform.GetChild(Num1 + 1).gameObject;
                    _targetParent2 = _targetParent2.transform.GetChild(Num2).gameObject;

                    _enemyClone2 = Instantiate(_enemyObject, _targetParent2.transform.position, _targetParent2.transform.rotation);
                    _enemyClone2.transform.SetParent(PlayerEnemy[1].transform);
                }
            }
    }

    //지정한 Player 만 적 스폰
    private void EnemySpawn(GameObject _Player, GameObject _enemyObject)
    {
        PlayerFieldDeck _playerFieldDeck = _Player.GetComponent<PlayerFieldDeck>();
    }

    private GameObject GetChildObject(GameObject _parentObject, string _childName)
    {
        int _childcount = _parentObject.transform.childCount;

        if (_childcount == 0)
        {
            Debug.Log("This GameObject doesn't have Child GameObject");
            return _parentObject.gameObject;
        }

        for(int Num = 0; Num < _childcount; Num++)
        {
            if (_parentObject.transform.GetChild(Num).name == _childName)
                return _parentObject.transform.GetChild(Num).gameObject;
        }

        Debug.Log("This GameObject doesn't have a child GameObject named [ " + _childName + " ]");
        return _parentObject.gameObject;
    }

    private void ShadowRotation()
    {
        RotationAngle[0] += RotationSpeed[0];
        RotationAngle[1] += RotationSpeed[1];

        ShadowObject[0].transform.SetPositionAndRotation(ShadowObject[0].transform.position, Quaternion.Euler(new Vector3(0, RotationAngle[0], 0)));
        ShadowObject[1].transform.SetPositionAndRotation(ShadowObject[1].transform.position, Quaternion.Euler(new Vector3(0, RotationAngle[1], 0)));
    }

    // Player Switch Button
    public void OnTextButtonCLick()
    {
        if(PlayerSwitch == true)
        {
            PlayerSwitch = false;
            Player[0].SetActive(false);
            Player[1].SetActive(true);
        }
        else
        {
            PlayerSwitch = true;
            Player[0].SetActive(true);
            Player[1].SetActive(false);
        }    
    }
}