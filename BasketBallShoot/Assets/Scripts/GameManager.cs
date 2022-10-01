using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("Ball Settings")]
    [SerializeField] GameObject[] balls;
    [SerializeField] Transform firePoint;
    [SerializeField] float forceValue;
    int ballIndex;
    [Header("Level Settings")]
    [SerializeField] int targetBallCount;
    [SerializeField] int currentBallCount;
    int correctBall;//hedefe atýlan top sayýsý
    public Slider levelSlider;
    public Text remainingBallsText;

    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text gameOverText, levelCompletedText;
    public bool isPressed;
    void Start()
    {
        levelSlider.maxValue = targetBallCount;
        remainingBallsText.text = currentBallCount.ToString();
    }
    public void BallEntared()
    {
        correctBall++;
        levelSlider.value = correctBall;
        if(correctBall == targetBallCount)
        {
            endGamePanel.gameObject.SetActive(true);
            levelCompletedText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (currentBallCount ==0 && correctBall != targetBallCount)
        {
            endGamePanel.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void BallWrongTarget()
    {
        if (currentBallCount == 0)
        {
            endGamePanel.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (currentBallCount + correctBall < targetBallCount)
        {
            endGamePanel.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)&&isPressed==false)
        {
            if (currentBallCount > 0)
                currentBallCount--;

            remainingBallsText.text = currentBallCount.ToString();
            balls[ballIndex].transform.SetPositionAndRotation(firePoint.transform.position, firePoint.transform.rotation);
            balls[ballIndex].SetActive(true);
            balls[ballIndex].GetComponent<Rigidbody>().AddForce(balls[ballIndex].transform.TransformDirection(30, 90, 90) * forceValue, ForceMode.Force);

            if (balls.Length - 1 == ballIndex)
                ballIndex = 0;
            else
                ballIndex++;
        }
#endif

#if !UNITY_EDITOR
        Touch touch;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                currentBallCount--;
                remainingBallsText.text = currentBallCount.ToString();
                balls[ballIndex].transform.SetPositionAndRotation(firePoint.transform.position, firePoint.transform.rotation);
                balls[ballIndex].SetActive(true);
                balls[ballIndex].GetComponent<Rigidbody>().AddForce(balls[ballIndex].transform.TransformDirection(30, 90, 90) * forceValue, ForceMode.Force);

                if (balls.Length - 1 == ballIndex)
                    ballIndex = 0;
                else
                    ballIndex++;
            }
        }
#endif
    }
}
