using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for CCryptorEngine
/// </summary>
public class CCryptorEngine
{
    private string key;
    public CCryptorEngine()
    {
        //
        // TODO: Add constructor logic here
        //
        key = "ABCDEFGHIJKLMÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz|-";
    }
    
    public static string Decrypt(string textoEncriptado)
    {
        string clave = "ABCDEFGHIJKLMÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz|-";
        byte[] llave;
        string newText = "";
        if (textoEncriptado.IndexOf(" ") != -1)
        {
            newText = textoEncriptado.Replace(' ', '+');
        }
        else { newText = textoEncriptado; }
        byte[] arreglo = Convert.FromBase64String(newText); // Arreglo donde guardaremos la cadena descovertida.

        // Ciframos utilizando el Algoritmo MD5.
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
        md5.Clear();

        //Ciframos utilizando el Algoritmo 3DES.
        TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
        tripledes.Key = llave;
        tripledes.Mode = CipherMode.ECB;
        tripledes.Padding = PaddingMode.PKCS7;
        ICryptoTransform convertir = tripledes.CreateDecryptor();
        byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
        tripledes.Clear();

        string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
        return cadena_descifrada; // Devolvemos la cadena
    }
}