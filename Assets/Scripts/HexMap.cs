using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public GameObject hexPrefab;

    public Material[] HexMaterials;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    public void GenerateMap()
    {
        for(int col=0; col < 10; col++)
        {
            for(int row=0; row < 10; row++)
            {
                Hex hex = new Hex(col, row);

                Instantiate(hexPrefab, hex.Position(), Quaternion.identity, this.transform);
            }
        }
    }
}
