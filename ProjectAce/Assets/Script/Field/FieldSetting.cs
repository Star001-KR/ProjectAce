using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public class FieldSetting : MonoBehaviour
{
    public EFieldState[,] FieldMap = new EFieldState[7,7];

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {

    }

    public EFieldState GetFieldMap(int PosX, int PosY)
    {
        return FieldMap[PosX, PosY];
    }

    public void SetFieldMap(int PosX, int PosY, EFieldState Value)
    {
        
    }
}