using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの位置を調整するためのクラス
/// </summary>
public class AutoCameraMover : MonoBehaviour
{
    Vector3 distance;
    [SerializeField] CharactorStatusKeeper keeper;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - keeper.playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = keeper.playerPos + distance;
    }
}
