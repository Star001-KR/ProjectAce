using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public class FieldState : MonoBehaviour
{
    private GameObject ParentObejct;
    private int ParentObejctNum;
    private int ObjectNum;
    private FieldSetting PlayerFieldSetting;
    private string Player;
    public Material[] fieldMaterial = new Material[3];
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
        GetObjectNum();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshField();
    }

    string SubStringRight(string str, int value)
    {
        if (str.Length < value)
            return "String Length Over Error";
        else
            return str.Substring(str.Length - value);
    }

    void Init()
    {
        ParentObejct = transform.parent.gameObject;
        PlayerFieldSetting = ParentObejct.transform.parent.GetComponent<FieldSetting>();

        Player = ParentObejct.transform.parent.parent.name;
    }

    void GetObjectNum()
    {
        ParentObejctNum = int.TryParse(SubStringRight(ParentObejct.name, 2), out ParentObejctNum) ? ParentObejctNum : 404;
        if (ParentObejctNum == 404) Debug.Log(ParentObejct.transform.name + " [ Fail TryParse ] ");

        ObjectNum = int.TryParse(SubStringRight(transform.name, 2), out ObjectNum) ? ObjectNum : 404;
        if (ParentObejctNum == 404) Debug.Log(transform.name + " [ Fail TryParse ] ");
    }

    void RefreshField()
    {
        if (Player == "Player1" || Player == "Player2")
        {
            if (TEMPUserDB.GetFieldState(Player, ParentObejctNum - 1, ObjectNum - 1) == EFieldState.Empty)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[0];

            else if (TEMPUserDB.GetFieldState(Player, ParentObejctNum - 1, ObjectNum - 1) == EFieldState.Ally)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[1];

            else if (TEMPUserDB.GetFieldState(Player, ParentObejctNum - 1, ObjectNum - 1) == EFieldState.Enemy
                  || TEMPUserDB.GetFieldState(Player, ParentObejctNum - 1, ObjectNum - 1) == EFieldState.Enemy_Start
                  || TEMPUserDB.GetFieldState(Player, ParentObejctNum - 1, ObjectNum - 1) == EFieldState.Enemy_End)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[2];

            else
                Debug.Log("[ " + Player + "/" + ParentObejctNum + "/" + ObjectNum + " Refresh Field Error!");
        }
        else
            Debug.Log("Player Naming Error! : Player Name is [ Player1 ] or [ Player2 ]");
    }
}
