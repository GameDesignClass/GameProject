using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataStore : MonoBehaviour
{
    [SerializeField] Color wrongLetterColor;
    [SerializeField] Color letterInWordColor;
    [SerializeField] Color letterInRightPlaceColor;

    static Color wrongLetter;
    static Color letterInWord;
    static Color letterInRightPlace;

    private void Awake()
    {
        wrongLetter = wrongLetterColor;
        letterInWord = letterInWordColor;
        letterInRightPlace = letterInRightPlaceColor;
    }

    public static Color GetWrongLetterColor() 
    { 
        return wrongLetter;
    }

    public static Color GetLetterInWordColor() 
    { 
        return letterInWord; 
    }

    public static Color GetLetterInRightPlaceColor() 
    {
        return letterInRightPlace;
    }
}
