using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HungreBar : MonoBehaviour
{

    public Image hungreBar;
    private void Start()
    {
        hungreBar.fillAmount = 0;
        
    }
    public void SatietyLevel(float maxValue,float increaseValue)
    {
        hungreBar.fillAmount = increaseValue/maxValue;
    }
}
