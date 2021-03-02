using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    public Image m_hpGauge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var target = Target.m_instance;
        m_hpGauge.fillAmount = (float) target.m_hp / target.m_max_hp;
    }
}
