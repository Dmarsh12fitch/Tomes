using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellMesh : MonoBehaviour{

    Mesh mesh;

    // Start is called before the first frame update
    void Awake(){

        mesh = GetComponent<MeshFilter>().mesh;

    }

    void Start(){

        MakeMeshData();

    }

    void MakeMeshData(){

        //Placeholder

    }

}
