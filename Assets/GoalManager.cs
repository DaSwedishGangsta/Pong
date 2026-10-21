using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    TMP_Text goalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalText = GetComponent<TMP_Text>();
        //Hämtar en referens till texten på samma
        //objekt som denna kod sitter på
    }

    // Update is called once per frame
    void Update()
    {
        //Uppdaterar texten på skärmen
        goalText.text = player1Score + " - " + player2Score;
    }
}