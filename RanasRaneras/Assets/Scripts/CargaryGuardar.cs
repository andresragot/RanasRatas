using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CargaryGuardar : MonoBehaviour
{
    private string RutaArchivo;

    public GameManager a;
    static bool Primeravez;
    

    // Start is called before the first frame update
    public void Awake()
    {
        RutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (Primeravez)
        {
            Cargar();
            Primeravez = false;
        }
    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(RutaArchivo);
        DatosAGuardar datos = new DatosAGuardar();
        bf.Serialize(file, datos);

        file.Close();
    }

    public void Cargar()
    {
        if (File.Exists(RutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(RutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            a.Vida1 = datos.CorazonesRes;
            //a.Vida2 = datos.CorazonesRes;

        }
       
    }

    [System.Serializable]
    class DatosAGuardar
    {
        public int CorazonesRes;

    }
}
