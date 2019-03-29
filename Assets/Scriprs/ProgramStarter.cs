#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramStarter : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        var names = DebugStaticClass.GiveData();

        for (int i = 0; i < names.Length; i++)
        {
            var obj = Instantiate(playerPrefabs[i]);
            obj.GetComponent<Player>().charactorName = names[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
