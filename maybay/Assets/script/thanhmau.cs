using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class thanhmau : MonoBehaviour
{
    public Image _thanhmau;

    // Start is called before the first frame update
    public void capnhatthanhmau(float nowhp, float maxhp)
    {
        _thanhmau.fillAmount = nowhp/maxhp;
    }

}
