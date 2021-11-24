using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Domanda
{
    // Start is called before the first frame update
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public string[] incorrect_answers;


    public List<string> GeneraRisposte()
    {
        List<string> listaRisposte = new List<string>(incorrect_answers);
        listaRisposte.Add(correct_answer);
        for (int i = 0; i < listaRisposte.Count; i++)
        {
            string temp = listaRisposte[i];
            int randomIndex = UnityEngine.Random.Range(i, listaRisposte.Count);
            listaRisposte[i] = listaRisposte[randomIndex];
            listaRisposte[randomIndex] = temp;
        }
        return listaRisposte;
    }

    public int RispostaCorretta(int opzione, List<string> listaDaCorreggere, int punteggi)
    {

        if (listaDaCorreggere[(opzione-1)].Equals(correct_answer))
        {
            Debug.Log("Corretto!");
            return punteggi + 1;
        }
        else
        {
            return punteggi;
        }
    }
}
