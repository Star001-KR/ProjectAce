using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public class FieldState : MonoBehaviour
{
    private GameObject ParentObject;
    private int ParentObjectNum;
    private int ObjectNum;
    private PlayerFieldDeck fieldDeck;
    private string Player;
    public Material[] fieldMaterial = new Material[3];

    // Start is called before the first frame update
    void Start()
    {
        Init();
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
        ParentObject = transform.parent.gameObject;
        fieldDeck = ParentObject.transform.parent.GetComponent<PlayerFieldDeck>();

        Player = ParentObject.transform.parent.parent.name;

        GetObjectNum();
    }

    void GetObjectNum()
    {
        ParentObjectNum = int.TryParse(SubStringRight(ParentObject.name, 2), out ParentObjectNum) ? ParentObjectNum : 404;
        if (ParentObjectNum == 404) Debug.Log(ParentObject.transform.name + " [ Fail TryParse ] ");

        ObjectNum = int.TryParse(SubStringRight(transform.name, 2), out ObjectNum) ? ObjectNum : 404;
        if (ParentObjectNum == 404) Debug.Log(transform.name + " [ Fail TryParse ] ");
    }

    void RefreshField()
    {
        if (Player == "Player1" || Player == "Player2")
        {
            if (fieldDeck.GetFieldMap(ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Empty)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[0];

            else if (fieldDeck.GetFieldMap(ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Ally)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[1];

            else if (fieldDeck.GetFieldMap(ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy
                  || fieldDeck.GetFieldMap(ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy_Start
                  || fieldDeck.GetFieldMap(ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy_End)
                transform.GetComponent<MeshRenderer>().material = fieldMaterial[2];

            else
                Debug.Log("[ " + Player + "/" + ParentObjectNum + "/" + ObjectNum + " Refresh Field Error!");
        }
        else
            Debug.Log("Player Naming Error! : Player Name is [ Player1 ] or [ Player2 ]");
    }
}