using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellMesh : MonoBehaviour{

    //Hold the mesh for the triangle that represents the fire spell
    Mesh mesh;

    //The verticies that connect the mesh
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Awake(){

        mesh = GetComponent<MeshFilter>().mesh;

    }

    void Start(){

        //Fill the vertices to create the fire triangle
        vertices = new Vector3[] { new Vector3(0, 0, 0.25f), new Vector3(-2, 0, 2), new Vector3(2, 0, 2) };
        triangles = new int[] { 0, 1, 2 };

        //Clear the mesh and then add those vertices
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        //Create a collider and make it surround the mesh
        MeshCollider collider = gameObject.GetComponent<MeshCollider>();
        collider.sharedMesh = mesh;

    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Brush"){

            Destroy(other);

        }

    }
}
