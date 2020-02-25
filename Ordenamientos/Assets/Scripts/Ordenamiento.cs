using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using System;
using TMPro;

// Se intento acomodar Canvas para cualquier resolucion de pantalla sin
// embargo las etiquetas aun se mueven dependiendo de la resolucion. La
// resolucion planeada es 1920x1080. Si las etiquetas se mueven, favor 
// considerar eje Y como tiempo en ms, con minimo de 0 y maximo de 36 y
// exe X como cantidad de elementos en el array, con minimo de 100 y 
//maximo de 3000.

public class Ordenamiento : MonoBehaviour
{

    public TMP_InputField inputField;
    public bool decision;
    public GameObject punto;

    public void guardarBB()
    {
        string numero = inputField.text;
        decision = true;
        CrearArray(numero);
    }

    public void guardarIns()
    {
        string numero = inputField.text;
        decision = false;
        CrearArray(numero);
    }
    
    void CrearArray(string canti)
    {
        long tiempo;
        System.Random rand = new System.Random();
        int cantidad=0;
        Int32.TryParse(canti, out cantidad);
        int[] ana = new int[cantidad];
        for (int i = 0; i<cantidad; i++)
        {
            int numero = rand.Next(1, 100);
            ana[i] = numero;
        }
        if (decision)
            tiempo = BubbleSort(ana);
        else
            tiempo = InsertSort(ana);
        print(tiempo);
        SpawnearPuntos(cantidad/100,tiempo);
    }
    public long BubbleSort(int[]lisDesConv)
    {
        Stopwatch tiempo = new Stopwatch();
        tiempo.Start();
        for (int j = 0; j <=lisDesConv.Length - 2; j++)
        {
            for (int i = 0; i <= lisDesConv.Length - 2; i++)
            {
                if (lisDesConv[i] > lisDesConv[i + 1])
                {
                    int temp = lisDesConv[i + 1];
                    lisDesConv[i + 1] = lisDesConv[i];
                    lisDesConv[i] = temp;
                }
            }
        }
        tiempo.Stop();
        foreach (int f in lisDesConv)
            print(f);
        print("Fin del Bubble Sort");
        return tiempo.ElapsedMilliseconds;

    }

    public long InsertSort(int[]lisDesConv)
    {
        Stopwatch tiempo = new Stopwatch();
        tiempo.Start();
        for (int i = 0; i < lisDesConv.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (lisDesConv[j - 1] > lisDesConv[j])
                {
                    int temp = lisDesConv[j - 1];
                    lisDesConv[j - 1] = lisDesConv[j];
                    lisDesConv[j] = temp;
                }
            }
        }
        tiempo.Stop();
        foreach (int f in lisDesConv)
            print(f);
        print("Fin del Insertion Sort");
        return tiempo.ElapsedMilliseconds;
    }
    
    public void SpawnearPuntos(int coorX, long coorY)
    {
        Vector3 posicion = new Vector3(coorX, 12, coorY);
        Instantiate(punto,posicion, Quaternion.identity);
        print("Fin de la graficacion");
    }

}
