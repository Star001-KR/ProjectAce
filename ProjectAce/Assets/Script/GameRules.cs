using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public GameObject[] Player = new GameObject[2];
    public GameObject[] ShadowObject = new GameObject[2];
    private float[] RotationAngle = new float[2];
    private float[] RotationSpeed = new float[2];
    private bool PlayerSwitch;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ShadowRotation();
    }

    private void Init()
    {
        RotationAngle[0] = 0.0f;
        RotationSpeed[0] = 0.1f;

        RotationAngle[1] = 0.0f;
        RotationSpeed[1] = 0.2f;

        Player[0].SetActive(true);
        Player[1].SetActive(false);

        PlayerSwitch = true;
    }

    private void ShadowRotation()
    {


        RotationAngle[0] += RotationSpeed[0];
        RotationAngle[1] += RotationSpeed[1];

        ShadowObject[0].transform.SetPositionAndRotation(ShadowObject[0].transform.position, Quaternion.Euler(new Vector3(0, RotationAngle[0], 0)));
        ShadowObject[1].transform.SetPositionAndRotation(ShadowObject[1].transform.position, Quaternion.Euler(new Vector3(0, RotationAngle[1], 0)));
    }

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