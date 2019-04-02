using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCameraMover : MonoBehaviour
{
    [SerializeField] float speed;
    bool isCanMove;
    int way;

    // Update is called once per frame
    void Update()
    {
        if (isCanMove)
        {
            gameObject.transform.Translate(new Vector3(way, 0, 0) * speed);
        }
    }

    public void OnMouseDown(int way)
    {
        this.way = way;
        isCanMove = true;
    }

    public void OnMouseUp()
    {
        isCanMove = false;
    }
}
