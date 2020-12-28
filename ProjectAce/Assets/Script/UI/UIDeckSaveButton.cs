using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeckSaveButton : MonoBehaviour
{
    public UITab playerTab;
    public Transform deckSettingUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeckSaveButtonClick()
    {
        Transform FieldRowObject;

        for (int RowNum = 0; RowNum < deckSettingUI.transform.childCount; RowNum++)
        {
            FieldRowObject = deckSettingUI.transform.GetChild(RowNum);

            for (int UnitNum = 0; UnitNum < FieldRowObject.childCount; UnitNum++)
                TEMPUserDB.SetFieldState(playerTab.selectTabNum.ToString(), RowNum, UnitNum, FieldRowObject.GetChild(UnitNum).GetComponent<ButtonFieldUnit>().currFieldState);
        }

        this.gameObject.SetActive(false);
    }
}
