using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje3D : MonoBehaviour
{
    public float HP_min;
    public float HP_max;
    public Image barra;

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = HP_min;
    }
}
