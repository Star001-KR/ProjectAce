using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSettingInit : MonoBehaviour
{
    public GameObject saveButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveButtonActivate();
    }

    public void TryDeckSettingInit()
    {
        Transform FieldRowObject;

        for(int RowNum = 0; RowNum < transform.childCount; RowNum++)
        {
            FieldRowObject = transform.GetChild(RowNum);

            for(int UnitNum = 0; UnitNum < FieldRowObject.childCount; UnitNum++)
                FieldRowObject.GetChild(UnitNum).GetComponent<ButtonFieldUnit>().Init();
        }
    }

    public void SaveButtonActivate()
    {
        Transform FieldRowObject;

        for (int RowNum = 0; RowNum < transform.childCount; RowNum++)
        {
            FieldRowObject = transform.GetChild(RowNum);

            for (int UnitNum = 0; UnitNum < FieldRowObject.childCount; UnitNum++)
                if (FieldRowObject.GetChild(UnitNum).GetComponent<ButtonFieldUnit>().isChange == true)
                {
                    saveButton.SetActive(true);
                    return;
                }
        }
        
        saveButton.SetActive(false);
    }
}
