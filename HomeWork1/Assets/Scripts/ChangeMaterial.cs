using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private MeshRenderer _mesh;
    
    private  void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

   
   private void Update()
    {
        _mesh.material.color=Color.Lerp (Color.white, Color.black, Mathf.Abs(Mathf.Sin(Time.time)));
    }
}
