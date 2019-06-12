using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLightScript : MonoBehaviour
{

    public float m_FlashingLightDelta = 5f;
    public GameObject m_FlashingLight;

    float m_TimerDelta = 0f;
    bool m_LightEnabled = false;

    void Update()
    {
        if (Time.time > m_TimerDelta)
        {
            m_TimerDelta = m_FlashingLightDelta + Time.time;
            SwitchLightActive();
        }
    }

    void SwitchLightActive()
    {
        m_LightEnabled = !m_FlashingLight;
        m_FlashingLight.SetActive(m_LightEnabled);
    }
}
