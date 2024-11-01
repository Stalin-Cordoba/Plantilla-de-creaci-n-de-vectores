﻿using System;
public class Program
{
    static void Main()
    {
        Random Elemento = new Random();

        int Cantidad;
        string Opción, Confirmar;
        bool Seguir = false;

        //DEFINIR LA LONGITUD DEL VECTOR

        Console.WriteLine("Ingrese la cantidad de elementos del vector");
        while (true)
        {
            string Entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Entrada))
            {
                Console.WriteLine("Ingrese un número");
            }
            else if (int.TryParse(Entrada, out Cantidad))
            {
                if (Cantidad <= 0)
                {
                    Console.WriteLine("El vector debe tener al menos 1 elemento");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Ingrese el número correctamente");
            }
        }

        int[] Vector = new int[Cantidad];

        void IngresarNúmeros() //Función para la primera opción
        {
            int Número;

            Console.Clear();
            Console.WriteLine($"Ingrese los {Cantidad} elementos del vector (Sólo permite números enteros)");
            for (int i = 0; i < Cantidad; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}. ");
                    string EntradaN = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(EntradaN))
                    {
                        Console.WriteLine("Ingrese un número");
                    }
                    else if (int.TryParse(EntradaN, out Número))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el número correctamente");
                    }
                }

                Vector[i] = Número;
            }

        }

        void NúmerosAleatorios() //Función para la segunda opción
        {
            Console.Clear();

            int Rango_I, Rango_S;

            while (true)
            {

                Console.WriteLine("Primero especifique el intervalo (Es decir, los valores mínimos y máximos que van a tener los números");

                while (true)
                {
                    string EntradaRI = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(EntradaRI))
                    {
                        Console.WriteLine("Ingrese el rango inferior (Sólo permite números enteros)");
                    }
                    else if (int.TryParse(EntradaRI, out Rango_I))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Introduzca el rango inferior correctamente");
                    }
                }

                while (true)
                {
                    string EntradaRS = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(EntradaRS))
                    {
                        Console.WriteLine("Ingrese el rango superior (Solo permite números enteros)");
                    }
                    else if (int.TryParse(EntradaRS, out Rango_S))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Introduzca el rango superior correctamente");
                    }
                }

                if (Rango_I > Rango_S)
                {
                    Console.WriteLine("El rango inferior es mayor que el rango superior!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < Cantidad; i++)
            {
                Vector[i] = Elemento.Next(Rango_I, Rango_S + 1);
            }
        }

        Console.Clear();

        //ENTRADA DE NÚMEROS

        do
        {
            Console.WriteLine("¿Cómo desea ingresar los elementos del vector?");
            Console.WriteLine("1) Ingresarlos manualmente");
            Console.WriteLine("2) Que los elementos del vector sean números aleatorios");

            Opción = Console.ReadLine();

            switch (Opción)
            {
                case "1":
                    if (Cantidad >= 100)
                    {
                        Console.Clear();
                        Console.WriteLine("El vector es muy extenso, ingresar los números manualmente puede tomar mucho tiempo o una eternidad \n¿Seguro que quieres hacerlo de igual forma? (s/n)");

                        do
                        {
                            Confirmar = Console.ReadLine();

                            switch (Confirmar)
                            {
                                case "s":
                                    Seguir = true;
                                    break;

                                case "n":
                                    Seguir = false;
                                    break;

                                default:
                                    Console.WriteLine("Ingrese una opción correcta");
                                    break;
                            }
                        }
                        while (Confirmar != "s" && Confirmar != "n");

                        if (Seguir)
                        {
                            IngresarNúmeros();
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Seguir = true;

                        IngresarNúmeros();
                    }
                    break;

                case "2":
                    NúmerosAleatorios();
                    break;

                default:
                    Console.WriteLine("Ingrese una opción válida");
                    break;
            }

            if ((Opción == "1" && Seguir == true) || Opción == "2")
            {
                break;
            }
        }
        while (true);

        Console.Clear();

        Console.WriteLine("Vector:");
        Console.Write("[");
        for (int i = 0; i < Cantidad; i++)
        {
            Console.Write($"{Vector[i]}");

            if (i == Cantidad - 1)
            {
                Console.WriteLine("]");
                break;
            }
            else
            {
                Console.Write(", ");
            }
        }

        Console.ReadKey();
        Console.Clear();

    }
}