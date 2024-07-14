using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class HexMap : MonoBehaviour
{
    public GameObject hexPrefab;

    public Material[] HexMaterials;
    public readonly int numRows=20;
    public readonly int numCols=40;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    public void GenerateMap()
    {
        for(int col=0; col < numCols; col++)
        {
            for(int row=0; row < numRows; row++)
            {
                Hex hex = new Hex(col, row);
                Vector3 pos = hex.PositionFromCamera(
                    Camera.main.transform.position,
                    numRows,
                    numCols
                    );

                GameObject hexGo =(GameObject) Instantiate(
                    hexPrefab,
                    pos,
                    Quaternion.identity,
                    this.transform);
                MeshRenderer h_meshRenderer = hexGo.GetComponentInChildren<MeshRenderer>();
                h_meshRenderer.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
                hexGo.GetComponent<HexComponent>().Hex=hex;
                hexGo.GetComponent<HexComponent>().HexMap = this;
            } 
            
        }
       
    }
}
