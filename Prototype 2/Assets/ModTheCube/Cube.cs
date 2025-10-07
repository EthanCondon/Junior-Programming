using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.7f, 1.6f, 0.0f, 0.5f);
    }
    
    void Update()
    {
        transform.Rotate(40.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
