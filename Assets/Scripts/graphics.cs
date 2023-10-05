using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphics : MonoBehaviour
{
    public void low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void medium()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void high()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void ultra()
    {
        QualitySettings.SetQualityLevel(3);
    }
}
