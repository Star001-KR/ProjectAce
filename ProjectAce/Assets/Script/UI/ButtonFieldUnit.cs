using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonEnum;

public class ButtonFieldUnit : MonoBehaviour
{
    public Material[] fieldMaterial = new Material[3];
    public EFieldState currFieldState;
    private GameObject ParentObject;
    private int ParentObjectNum;
    private int ObjectNum;
    private UITab TabListObj;
    public bool isChange;

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

    public void Init()
    { 
        TabListObj = GameObject.Find("Tab Item").GetComponent<UITab>();
        ParentObject = transform.parent.gameObject;

        GetObjectNum();

        currFieldState = TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1);

        isChange = false;
    }

    void RefreshField()
    {
        if (currFieldState == EFieldState.Empty)
            transform.GetComponent<Image>().material = fieldMaterial[0];

        else if (currFieldState == EFieldState.Ally)
            transform.GetComponent<Image>().material = fieldMaterial[1];

        else if (currFieldState == EFieldState.Enemy
                || currFieldState == EFieldState.Enemy_Start
                || currFieldState == EFieldState.Enemy_End)
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

    public void OnFieldUintButtonClick()
    {
        if (currFieldState == EFieldState.Empty)
            currFieldState = EFieldState.Ally;
        else if (currFieldState == EFieldState.Ally)
            currFieldState = EFieldState.Enemy;
        else if (currFieldState == EFieldState.Enemy)
            currFieldState = EFieldState.Empty;
        else
            Debug.Log("Can't Chage Field State!");

        if (currFieldState != TEMPUserDB.GetFieldState(TabListObj.selectTabNum.ToString(), ParentObjectNum - 1, ObjectNum - 1))
            isChange = true;
        else
            isChange = false;

        RefreshField();
    }
}
