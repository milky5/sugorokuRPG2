#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour
{
    [SerializeField] Program program;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, -60, 60) * 7 * Time.deltaTime);

        if (transform.position.y < 1)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;

            //サイコロ落下終わったので
            program.isDiceFinishedFalling = true;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //サイコロがすでに落下をはじめていたら
            if (rb.useGravity) return;

            //[戻る]ボタンがクリックされているか確認
            var result = IsUGUIHit(Input.mousePosition);

            //[戻る]ボタンをクリックしていた場合
            if (result) gameObject.SetActive(false);

            //[戻る]ボタンはクリックされておらず、かつサイコロも落下していないとき
            if (!result && rb.useGravity == false)
            {
                //サイコロを落下させる
                rb.useGravity = true;

                //[戻る]ボタンを押せなくする
                program.isDiceBeganToFall = true;

            }
        }
    }

    public static bool IsUGUIHit(Vector3 _scrPos) // Input.mousePosition
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = _scrPos;
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, result);
        return (result.Count > 0);
    }
}
