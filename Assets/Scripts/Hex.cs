using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex
{

    public Hex(int _col, int _row)
    {
        this.col = _col;
        this.row = _row;
        this.s = -(col + row);
    }

    public readonly int col;
    public readonly int row;
    public readonly int s;

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;
    public Vector3 Position()
    {
        float radius = 1f;
        float height = radius * 2;
        float width = WIDTH_MULTIPLIER * height;

        float vert = height * 0.75f;
        float horizontal = width;


        return new Vector3(horizontal * (this.col + this.row / 2f), 0, vert * this.row);
    }
}
