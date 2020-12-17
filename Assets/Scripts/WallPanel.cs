using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPanel : MonoBehaviour
{

    public int correctWire;
    public bool isActive = false;

    public SnippingController snippingController;

    // Start is called before the first frame update
    void Start()
    {
        snippingController = FindObjectOfType<SnippingController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WireSnipped(int cutWire)
    {
        if(cutWire == correctWire)
        {
            print("Correct!");
            isActive = true;
        }
        else
        {
            snippingController.EndGame();
        }
    }
}
