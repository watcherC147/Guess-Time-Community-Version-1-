using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCameraMoved();
    }
    public void PanToHex(Hex hex)
    {

    }
    void CheckIfCameraMoved()
    {
        if (oldPosition != this.transform.position)
        {
            oldPosition= this.transform.position;

            HexComponent[] hexes=GameObject.FindObjectsOfType<HexComponent>();
            foreach (HexComponent hex in hexes)
            {
                hex.UpdatePosition();
            }
        }

    }
}
