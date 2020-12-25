﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;

public static class TEMPUserDB
{
    public static EFieldState[,] FieldMap_Player1 = new EFieldState[7, 7]
    {
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty}
    };


    public static EFieldState[,] FieldMap_Player2 = new EFieldState[7, 7]
    {
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty},
        {EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty, EFieldState.Empty}
    };

    public static EFieldState GetFieldState(string PlayerName, int PosX, int PosY)
    {
        if (PlayerName == "Player1")
            return FieldMap_Player1[PosX, PosY];

        else if (PlayerName == "Player2")
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
