using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public int darts;
    public float score;

    public Score(int darts, float score)
    {
        this.darts = darts;
        this.score = score;
    }
}
