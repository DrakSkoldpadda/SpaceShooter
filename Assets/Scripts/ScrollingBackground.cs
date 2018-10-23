using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Material mat;
    public float scalar = 1;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = mat.GetTextureOffset("_MainTex");
        offset.x = Time.deltaTime * scalar;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
