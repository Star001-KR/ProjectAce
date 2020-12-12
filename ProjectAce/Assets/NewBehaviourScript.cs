using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Button UIButton;
    private bool PlayerSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        Player1.SetActive(true);
        Player2.SetActive(false);

        PlayerSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTextButtonCLick()
    {
        if(PlayerSwitch == true)
        {
            PlayerSwitch = false;
            Player1.SetActive(false);
            Player2.SetActive(true);
        }
        else
        {
            PlayerSwitch = true;
            Player1.SetActive(true);
            Player2.SetActive(false);
        }    
    }
}