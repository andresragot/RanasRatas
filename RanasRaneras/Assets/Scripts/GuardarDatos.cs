using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GuardarDatos : MonoBehaviour
{
    private int corazon1;
    private string NArchivo;
    // Start is called before the first frame update
    private void Awake()
    {
        NArchivo = Application.persistentDataPath + " / datos.data";
       // Debug.Log(Application.persistentDataPath);
    }
    void Start()
    {
        Cargar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Guardar()
    {
        if (File.Exists(NArchivo)) { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(NArchivo);

        DatosaGuardar datos = new DatosaGuardar();
        datos.corazon = corazon1;

        bf.Serialize(file, datos);

        file.Close();
        }
        else
        {
            corazon1 = 1;
        }
    }

    void Cargar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(NArchivo, FileMode.Open);

        DatosaGuardar datos = (DatosaGuardar)bf.Deserialize(file);

        corazon1 = datos.corazon;

        file.Close();
    }

    [Serializable]
    class DatosaGuardar
    {
        public int corazon;

      //  public DatosaGuardar(int corazon)
        //{
          //  this.corazon1 = corazon;
        //}
    }
}
