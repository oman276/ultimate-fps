using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireNum;
    public WallPanel wallPanel;

    // Start is called before the first frame update
    void Start()
    {
        wallPanel = GetComponentInParent<WallPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        this.transform.position = new Vector3(100f, 100f, 100f);
        wallPanel.WireSnipped(wireNum);
    }
}
