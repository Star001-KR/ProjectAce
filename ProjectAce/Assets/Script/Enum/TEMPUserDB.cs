using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public static class TEMPUserDB
{
    public static int[] startPoint_Player1 = new int[2] { 0, 0 };
    public static int[] endPoint_Player1 = new int[2] { 0, 1 };
    public static EFieldState[,] FieldMap_Player1 = new EFieldState[7, 7]
    {
        {EFieldState.Enemy_Start, EFieldState.Enemy_End, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Ally, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty}
    };

    public static int[] startPoint_Player2 = new int[2] { 0, 0 };
    public static int[] endPoint_Player2 = new int[2] { 1, 0 };
    public static EFieldState[,] FieldMap_Player2 = new EFieldState[7, 7]
    {
        {EFieldState.Enemy_Start, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Enemy_End, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Ally, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty}
    };

    public static EFieldState GetFieldState(string PlayerName, int PosX, int PosY)
    {
        if (PlayerName == "Player1" || PlayerName == (0).ToString())
            return FieldMap_Player1[PosX, PosY];

        else if (PlayerName == "Player2" || PlayerName == (1).ToString())
            return FieldMap_Player2[PosX, PosY];

        else
        {
            Debug.Log("GetFieldState Function Error!");
            return EFieldState.Empty;
        }
    }

    public static void SetFieldState(string _playerName, int _posX, int _posY, EFieldState _state)
    {
        if (_playerName == "Player1")
            FieldMap_Player1[_posX, _posY] = _state;

        else if (_playerName == "Player2")
            FieldMap_Player2[_posX, _posY] = _state;

        else
            Debug.Log("SetFieldState Function Error!");
    }
}
