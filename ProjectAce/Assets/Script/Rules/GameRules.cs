using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //EnemySpawn(EnemyObject[0], GetChildObject(Player[0], "SpawnPoint").transform);
            EnemySpawn(EnemyObject[0], PlayerEnemy[0].transform);
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

    private void EnemySpawn(GameObject _enemyObject, Transform _enemySpawnPoint)
    {
        GameObject _enemyClone = Instantiate(_enemyObject, _enemySpawnPoint);
        _enemyClone.transform.SetParent(PlayerEnemy[0].transform);
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