﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<DontDestroyOnLoad>().Length == 2)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }

  
}
