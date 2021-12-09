using System.Collections;
using System.Collections.Generic;
using CustomMath;
using MathDebbuger;
using UnityEngine;

public class Soluciones : MonoBehaviour
{
    public enum ejercicios
    {
        Uno,
        Dos,
        Tres
    }
    public float angle;
    public ejercicios ejercicio = ejercicios.Uno;

    public Transform ejer1;

    public List<Vector3> ejer2;
    public Transform ejer2_1;
    public Transform ejer2_2;
    public Transform ejer2_3;

    public List<Vector3> ejer3;
    public Transform ejer3_1;
    public Transform ejer3_2;
    public Transform ejer3_3;
    public Transform ejer3_4;
    public Vector3 ejer3RotationPoint = new Vector3(5f,5f,0.0f);
    public Vector3 ejer3RotationAxis;
    public float rotationOpen;

    // Start is called before the first frame update
    void Start()
    {
        rotationOpen = Vec3.Distance(new Vec3(ejer3RotationPoint), new Vec3(transform.right*10f));
        ejer3RotationAxis = ejer3RotationPoint.normalized;
        VectorDebugger.EnableCoordinates();
        VectorDebugger.AddVector(ejer1.position,Color.red,"Rojo");
        ejer2.Add(Vector3.zero);
        ejer2.Add(ejer2_1.forward*10f);
        ejer2.Add(ejer2_2.up*10f + ejer2_1.forward * 10f);
        ejer2.Add(ejer2_3.forward * 10f + ejer2_2.up * 10f + ejer2_1.forward * 10f);
        VectorDebugger.AddVectorsSecuence(ejer2,true,Color.blue,"Azul");
        ejer3.Add(Vector3.zero);
        ejer3.Add(ejer3_1.forward * 10f);
        ejer3.Add(ejer3_2.up * 10f + ejer3_1.forward * 10f);
        ejer3.Add(ejer3_3.forward * 10f + ejer3_2.up * 10f + ejer3_1.forward * 10f);
        ejer3.Add(ejer3_4.up * 10f + ejer3_3.forward * 10f + ejer3_2.up * 10f + ejer3_1.forward * 10f);
        VectorDebugger.AddVectorsSecuence(ejer3, true, Color.yellow, "Amarillo");
        VectorDebugger.EnableEditorView();
    }

    // Update is called once per frame
    void Update()
    {
        switch(ejercicio){
            case ejercicios.Uno:
                ejer1.rotation *= Quats.AngleAxis(angle,new Vec3(transform.up));
                VectorDebugger.UpdatePosition("Rojo",ejer1.forward*10);
                break;
            case ejercicios.Dos:
                ejer2_1.rotation *= Quats.AngleAxis(angle, new Vec3(transform.up));

                ejer2[1] = ejer2_1.forward * 10f;
                ejer2[2] = ejer2_2.up * 10f + ejer2_1.forward * 10f;
                ejer2[3] = ejer2_3.forward * 10f + ejer2_2.up * 10f + ejer2_1.forward * 10f;

                VectorDebugger.UpdatePositionsSecuence("Azul",ejer2);
                break;
            case ejercicios.Tres:
                
                ejer3_1.rotation *= Quats.AngleAxis(angle,new Vec3(ejer3RotationAxis));
                ejer3_3.rotation *= Quats.AngleAxis(angle, new Vec3(ejer3RotationAxis));

                ejer3[1] = ejer3_1.forward * rotationOpen + ejer3_1.position;
                ejer3[2] = ejer3_2.position;
                ejer3[3] = ejer3_3.forward * rotationOpen + ejer3_3.position;
                ejer3[4] = ejer3_4.position;

                VectorDebugger.UpdatePositionsSecuence("Amarillo", ejer3);
                break;
        }
    }
}
