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
    float radius = 1f;
    bool allowWrapEastWest=true;
    bool allowWrapNorthSouth=false;
    public Vector3 Position()
    {
        float height = HexHeight();
        float width = HexWidth();

        float vert = height * 0.75f;
        float horizontal = width;


        return new Vector3(horizontal * (this.col + this.row / 2f), 0, vert * this.row);
    }
    public float HexHeight()
    {
        return radius * 2;
    }
    public float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }
    public float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f;
    }
    public float HexHorizontalSpacing()
    {
        return HexWidth();
    }
    public Vector3 PositionFromCamera(Vector3 cameraPosition,float numRows,float numCols)
    {
        float mapHeight=numRows*HexVerticalSpacing();
        float mapWidth=numCols*HexHorizontalSpacing();
        Vector3 position=Position();

        if (allowWrapEastWest)
        {
            float howManyWidthsFromCamera = (position.x - cameraPosition.x) / mapWidth;

            if (howManyWidthsFromCamera > 0)
                howManyWidthsFromCamera += 0.5f;
            else
                howManyWidthsFromCamera -= 0.5f;
            int howManyWidthsToFix = (int)howManyWidthsFromCamera;
            position.x -= howManyWidthsToFix * mapWidth;
        }
        if (allowWrapNorthSouth)
        {
            float howManyHeightsFromCamera = (position.z- cameraPosition.z) / mapHeight;

            if (howManyHeightsFromCamera > 0)
                howManyHeightsFromCamera += 0.5f;
            else
                howManyHeightsFromCamera -= 0.5f;
            int howManyHeightsToFix = (int)howManyHeightsFromCamera;
            position.z -= howManyHeightsToFix * mapHeight;
           
        } 
        return position;
    }
}
