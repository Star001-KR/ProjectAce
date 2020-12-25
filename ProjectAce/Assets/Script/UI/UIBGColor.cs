using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBGColor : MonoBehaviour
{
    public float[] RGB = new float[3];
    public float[] changeValue = new float[3];
    private bool colorSwitch;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshColor();
    }

    void Init()
    {
        colorSwitch = true;
        transform.GetComponent<Image>().material.color = SetColor(RGB[0] / 255, RGB[1] / 255, RGB[2] / 255);
    }

    private Color SetColor(float _r, float _g, float _b)
    {
        Color _Color = new Color(_r, _g, _b);

        return _Color;
    }

    private void RefreshColor()
    {
        if (colorSwitch == true)
        {
            for (int Num = 0; Num < 3; Num++)
            {
                RGB[Num] += changeValue[Num];
                if (RGB[Num] > 254)
                    colorSwitch = false;
            }
        }
        else
        {
            for (int Num = 0; Num < 3; Num++)
            {
                RGB[Num] -= changeValue[Num];
                if (RGB[Num] < 1)
                    colorSwitch = true;
            }
        }

        transform.GetComponent<Image>().material.color = SetColor(RGB[0] / 255, RGB[1] / 255, RGB[2] / 255);
    }
}
