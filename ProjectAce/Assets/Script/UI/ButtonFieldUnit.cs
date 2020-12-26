using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonEnum;

public class ButtonFieldUnit : MonoBehaviour
{
    public Material[] fieldMaterial = new Material[3];
    private EFieldState currFieldState;
    private GameObject ParentObject;
    private int ParentObjectNum;
    private int ObjectNum;
    private UITab TabListObj;

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

    void Init()
    {
        TabListObj = GameObject.Find("Tab Item").GetComponent<UITab>();
        ParentObject = transform.parent.gameObject;
    }

    void RefreshField()
    {
        if (TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Empty)
            transform.GetComponent<Image>().material = fieldMaterial[0];

        else if (TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Ally)
            transform.GetComponent<Image>().material = fieldMaterial[1];

        else if (TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy
                || TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy_Start
                || TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1) == EFieldState.Enemy_End)
            transform.GetComponent<Image>().material = fieldMaterial[2];
    }

    void GetObjectNum()
    {
        ParentObjectNum = int.TryParse(SubStringRight(ParentObject.name, 2), out ParentObjectNum) ? ParentObjectNum : 404;
        if (ParentObjectNum == 404) Debug.Log(ParentObject.transform.name + " [ Fail TryParse ] ");

        ObjectNum = int.TryParse(SubStringRight(transform.name, 2), out ObjectNum) ? ObjectNum : 404;
        if (ParentObjectNum == 404) Debug.Log(transform.name + " [ Fail TryParse ] ");
    }

    string SubStringRight(string str, int value)
    {
        if (str.Length < value)
            return "String Length Over Error";
        else
            return str.Substring(str.Length - value);
    }
}
