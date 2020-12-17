using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject ShadowObject_Player1;
    public GameObject ShadowObject_Player2;
    public Button UIButton;
    private bool PlayerSwitch;
    private float RotationShadow_Player1;
    private float RotationShadow_Player2;
    private float RotationSpeed_Player1;
    private float RotationSpeed_Player2;

    // Start is called before the first frame update
    void Start()
    {
        RotationShadow_Player1 = 0.0f;
        RotationShadow_Player2 = 0.0f;
        RotationSpeed_Player1 = 0.1f;
        RotationSpeed_Player2 = 0.2f;

        Player1.SetActive(true);
        Player2.SetActive(false);

        PlayerSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotationShadow_Player1 += RotationSpeed_Player1;
        RotationShadow_Player2 += RotationSpeed_Player2;

        ShadowObject_Player1.transform.SetPositionAndRotation(ShadowObject_Player1.transform.position, Quaternion.Euler(new Vector3(0, RotationShadow_Player1, 0)));
        ShadowObject_Player2.transform.SetPositionAndRotation(ShadowObject_Player2.transform.position, Quaternion.Euler(new Vector3(0, RotationShadow_Player2, 0)));
    }

    public void OnTextButtonCLick()
    {
        if(PlayerSwitch == true)
        {
            PlayerSwitch = false;
            Player1.SetActive(false);
            Player2.SetActive(true);
        }
        else
        {
            PlayerSwitch = true;
            Player1.SetActive(true);
            Player2.SetActive(false);
        }    
    }
}