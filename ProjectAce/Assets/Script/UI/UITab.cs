using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonEnum;

public class UITab : MonoBehaviour
{
    public Button[] TabButton;
    public ETabButtonState[] TabButtonState;
    public Material material_Select;
    public Material material_UnSelect;

    // Start is called before the first frame update
    void Start()
    {
        TabButtonRefresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TabButtonRefresh()
    {
        for(int Num = 0; Num < TabButton.Length; Num++)
        {
            if (TabButtonState[Num] == ETabButtonState.Select)
                TabButton[Num].GetComponent<Image>().material = material_Select;
            else if (TabButtonState[Num] == ETabButtonState.Unselect)
                TabButton[Num].GetComponent<Image>().material = material_UnSelect;
            else
                Debug.Log(transform.name + " TabButtonRefresh Function Error!");
        }
    }

    public void OnTabButtonClick(int _Index)
    {
        for (int Num = 0; Num < TabButton.Length; Num++)
        {
            if (Num == _Index)
                TabButtonState[Num] = ETabButtonState.Select;
            else
                TabButtonState[Num] = ETabButtonState.Unselect;
        }

        TabButtonRefresh();
    }
}
