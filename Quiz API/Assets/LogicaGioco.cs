using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGioco : MonoBehaviour
{
    public ListaDomande ListaDomande;
    public int Punti;

    // Start is called before the first frame update
    void Start()
    {
        ListaDomande = GameManager.GetDomandeFromWeb();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal List<string> GeneraRisposte(int indice)
    {
        return ListaDomande.results[indice].GeneraRisposte();
    }

    internal int RispostaCorretta(int opzione, int indice, List<string> listaRisposte, int punteggi)
    {
        return ListaDomande.results[indice].RispostaCorretta(opzione, listaRisposte, punteggi);
    }
}
