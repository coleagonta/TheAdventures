using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    void Start()
    {
        Debug.Log(gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).name);
    }
}
