using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMaster : MonoBehaviour
{
    public LogicaGioco logic;
    public GameManager gameManager;
    public Text questionText;
    public Text[] answerTexts;
    public GameObject panel1;
    public GameObject panel2;
    public Text panel2text;
    private int questionN;
    List<string> tutteLeDomande = new List<string>();
    public int scelta = 0;
    private bool scritto = false;
    public int punteggio = 0;

    List<string> listaRisposte = new List<string>();
    List<string> listaRisposte2 = new List<string>();
    List<string> listaRisposte3 = new List<string>();
    List<string> listaRisposte4 = new List<string>();
    List<string> listaRisposte5 = new List<string>();
    List<string> listaRisposte6 = new List<string>();
    List<string> listaRisposte7 = new List<string>();
    List<string> listaRisposte8 = new List<string>();
    List<string> listaRisposte9 = new List<string>();
    List<string> listaRisposte10 = new List<string>();
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        logic = FindObjectOfType<LogicaGioco>();
        questionN = 0;
        for (int i = 0; i < 10; i++)
        {
            string domandaEncoded = logic.ListaDomande.results[i].question;
            string domanda = gameManager.DecodeString(domandaEncoded);
            tutteLeDomande.Add(domanda);
        }

        listaRisposte = logic.GeneraRisposte(0);
        listaRisposte2 = logic.GeneraRisposte(1);
        listaRisposte3 = logic.GeneraRisposte(2);
        listaRisposte4 = logic.GeneraRisposte(3);
        listaRisposte5 = logic.GeneraRisposte(4);
        listaRisposte6 = logic.GeneraRisposte(5);
        listaRisposte7 = logic.GeneraRisposte(6);
        listaRisposte8 = logic.GeneraRisposte(7);
        listaRisposte9= logic.GeneraRisposte(8);
        listaRisposte10 = logic.GeneraRisposte(9);
    }

    void Update()
    {
        int indice = questionN - 1;
        switch (questionN)
        {
            case 0:
                questionN++;
                break;
            case 1:
                CheckClick(indice, listaRisposte);
                break;
            case 2:
                CheckClick(indice, listaRisposte2);
                break;
            case 3:
                CheckClick(indice, listaRisposte3);
                break;
            case 4:
                CheckClick(indice, listaRisposte4);
                break;
            case 5:
                CheckClick(indice, listaRisposte5);
                break;
            case 6:
                CheckClick(indice, listaRisposte6);
                break;
            case 7:
                CheckClick(indice, listaRisposte7);
                break;
            case 8:
                CheckClick(indice, listaRisposte8);
                break;
            case 9:
                CheckClick(indice, listaRisposte9);
                break;
            case 10:
                CheckClick(indice, listaRisposte10);
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel2text.text = "Hai totalizzato: " + punteggio + " punti!";
                break;
        }
    }


    public void CheckClick(int i, List<string> listaRisposte)
    {
        if (!scritto)
        {
            for (int j = 0; j < listaRisposte.Count; j++)
            {
                string risposta = gameManager.DecodeString(listaRisposte[j]);
                answerTexts[j].text = risposta;
            }
            questionText.text = tutteLeDomande[i];
            scritto = true;
        }

        if (scelta != 0)
        {
            punteggio = logic.RispostaCorretta(scelta, i, listaRisposte, punteggio);
            scritto = false;
            scelta = 0;
            questionN++;
        }
    }

    public void Tasto1()
    {
        scelta = 1;
    }

    public void Tasto2()
    {
        scelta = 2;
    }

    public void Tasto3()
    {
        scelta = 3;
    }

    public void Tasto4()
    {
        scelta = 4;
    }
}
