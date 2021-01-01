using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public class PlayerFieldDeck : MonoBehaviour
{
    public EFieldState[,] FieldMap = new EFieldState[7,7];

    private void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        if (transform.parent.name == "Player1")
            FieldMap = TEMPUserDB.FieldMap_Player1;
        else if (transform.parent.name == "Player2")
            FieldMap = TEMPUserDB.FieldMap_Player2;
        else
            Debug.Log(transform.name + " PlayerFieldDeck / Init Function Error!");
    }

    public EFieldState GetFieldMap(int PosX, int PosY)
    {
        return FieldMap[PosX, PosY];
    }

    public void SetFieldMap(int PosX, int PosY, EFieldState Value)
    {
        FieldMap[PosX, PosY] = Value;
    }
}