using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの位置を調整するためのクラス
/// </summary>
public class CameraController : MonoBehaviour
{
    Vector3 distance;
    CharactorStatusKeeper keeper;

    // Start is called before the first frame update
    void Start()
    {
        keeper = GameObject.Find("CharactorStatusKeeper").GetComponent<CharactorStatusKeeper>();
        distance = transform.position - keeper.playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = keeper.playerPos + distance;
    }
}
