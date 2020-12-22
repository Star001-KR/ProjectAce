using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldState : MonoBehaviour
{
    private GameObject ParentObejct;
    private int ParentObejctNum;
    private int ObjectNum;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
          
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

        ParentObejctNum = int.TryParse(SubStringRight(ParentObejct.name, 2), out ParentObejctNum) ? ParentObejctNum : 404;
        if (ParentObejctNum == 404) Debug.Log(ParentObejct.transform.name + " [ Fail TryParse ] ");

        ObjectNum = int.TryParse(SubStringRight(transform.name, 2), out ObjectNum) ? ObjectNum : 404;
        if (ParentObejctNum == 404) Debug.Log(transform.name + " [ Fail TryParse ] ");
    }
}
