﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<GameSession>().CountBlocks();
    }
}