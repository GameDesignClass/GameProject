using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StudyMinigameScript : MonoBehaviour
{
    [SerializeField] string[] wordBank = new string[] {"Test","Game","Generous","Finance","Obstacle",
    "Method","Treatment","Correspond","Lecture","Duke","Pocket","Horizon","Mold","Move","Parade","Pair",
    "Gallery","Thought","Sniff","Agony","Wagon","Chart","Tone","Shine"};
    [SerializeField] Text generatedText,progressText,scoreText,levelText,wordText,finalScoreText;
    [SerializeField] GameObject minigameWindow, resultsWindow;
    [SerializeField] InputField userInput;
    [SerializeField] bool gameIsOver = false;

    [SerializeField] int defaultNumOfWords = 5, numOfRounds = 3, addWordPerRound = 2, numOfWords = 0, score = 0, roundNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        roundNum = 1;
        gameIsOver = false;
        numOfWords = defaultNumOfWords;
        minigameWindow.SetActive(true);
        resultsWindow.SetActive(false);
        generateNewText();
        updateScore();
        updateRound();
    }

    //Should be called when the next round starts
    void nextRound()
    {
        if(roundNum<numOfRounds){
            generateNewText();
            roundNum++;
            updateRound();
        }else{
            gameIsOver = true;
            showResults();
        }
    }

    //Changes the number of words generated (Takes type int)
    public void setNumOfWords(int val)
    {
        numOfWords = val;
    }

    //Generates a new string for the user
    public void generateNewText()
    {
        generatedText.text = "";
        for(int i=0;i<numOfWords;i++){
            generatedText.text = generatedText.text + wordBank[Random.Range(0,wordBank.Length)] + " ";
        }
        generatedText.text = generatedText.text.Trim();
    }

    //When user presses submit button
    //Function should be called when OnClick() of button is called
    public void submitText()
    {
        checkText();
    }

    //Checks if the user input text is the same as the generated text
    void checkText()
    {
        if(generatedText.text == userInput.text){
            //If user gets it correct
            addScore();
            numOfWords = numOfWords+addWordPerRound;
            nextRound();
        }else{
            //If user gets it wrong
            nextRound();
        }
    }

    //Updates the users progress percentage(In terms of how many char typed)
    //Function should be called when OnValueChanged() of inputfield is called
    public void updateProgress()
    {
        float temp = (float)userInput.text.Length/generatedText.text.Length*100;
        progressText.text = "Progress: "+temp+"%";
    }

    void addScore()
    {
        if (!gameIsOver){
            score++;
            updateScore();
        }
    }

    void updateScore()
    {
        scoreText.text = "Score: "+score;
    }

    void updateRound()
    {
        levelText.text = "Level "+roundNum;
    }

    void showResults()
    {
        finalScoreText.text = score+"/"+numOfRounds;
        float finalScore = (float)score/numOfRounds;
        if(finalScore<1f && finalScore>=.6f){
            wordText.text = "Good!";
        }else if(finalScore>0f && finalScore<.6f){
            wordText.text = "Meh...";
        }else if(finalScore>=1f){
            wordText.text = "Perfect!";
        }else if(finalScore<=0f){
            wordText.text = "Terrible";
        }
        minigameWindow.SetActive(false);
        resultsWindow.SetActive(true);
    }
    public void continueToNextScene()
    {
        SceneManager.LoadScene("Scene2");
    }
}
