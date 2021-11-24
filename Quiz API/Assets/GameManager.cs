using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static string url = "https://opentdb.com/api.php?amount=10&type=multiple&encode=base64";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string DecodeString(string toDecode)
    {
        byte[] data = Convert.FromBase64String(toDecode);
        string decodedString = Encoding.UTF8.GetString(data);
        return decodedString;
    }

    static string GetFromWeb(string webUrl)
    {
        HttpWebRequest request = WebRequest.CreateHttp(webUrl);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string risposta = reader.ReadToEnd();
                    return risposta;
                }
            }
        }
    }

    public static ListaDomande GetDomandeFromWeb()
    {
        string JSONDomande = GetFromWeb(url);
        try
        {
            ListaDomande domande = JsonUtility.FromJson<ListaDomande>(JSONDomande);
            return domande;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }

    }
}
