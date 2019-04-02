using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverSwitcher : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    AutoCameraMover auto;
    ManualCameraMover manual;

    // Start is called before the first frame update
    void Start()
    {
        auto =  MainCamera.GetComponent<AutoCameraMover>();
        manual = MainCamera.GetComponent<ManualCameraMover>();
        UseAutoMover();
    }

    public void UseAutoMover()
    {
        auto.enabled = true;
        manual.enabled = false;
    }

    public void UseManualMover()
    {
        auto.enabled = false;
        manual.enabled = true;
    }
}
