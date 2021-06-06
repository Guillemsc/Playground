using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVsync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 61;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
