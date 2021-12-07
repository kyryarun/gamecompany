using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain_UI_Control : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        ExPlain_Off();
    }

    void ExPlain_Off()
    {
        if(UIManager.GetIntstance().m_Explain_UI.activeSelf && Input.GetMouseButtonDown(0))
        {
            UIManager.GetIntstance().m_Explain_UI.SetActive(false);
        }
    }
}
