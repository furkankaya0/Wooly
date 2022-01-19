using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();
    public Transform Childs;
    //public Transform ChunkyBait;
    //public Transform PoisonousBait;
    public float MovSpeed= 1;
    //private int sec = 1;
    public int initialSize = 2;
    public GameObject food;
    public Color Cfood = Color.black;
    //Slider
    //public Slider SpeedSlider;
    //public float sliderValue;
    //SliderSpeedControl.difficulty;  
    
    //Score
    public Text ScoreText;
    public int score = 0;
    //Counter time 
    public Text CounterText;
    public int counter;
    private GameObject poisoned;


    private void Start()                        //Always start from beginning
    {
       StartCoroutine(CountFT());
       ResetState();
       Gameover();

    }

    private void Update()                   //controls of the Snake game with keyboard
    {
        //Debug.Log(MovSpeed);
        //WaitSec();
        if (Input.GetKeyDown(KeyCode.W) && _direction!=Vector2.down * MovSpeed)
        {
            _direction = Vector2.up * MovSpeed;
        }else if (Input.GetKeyDown(KeyCode.S) && _direction!= Vector2.up * MovSpeed)
        {
            _direction = Vector2.down* MovSpeed;
        }else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right * MovSpeed)
        {
            _direction = Vector2.left * MovSpeed;
        }else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left * MovSpeed)
        {
            _direction = Vector2.right* MovSpeed;
        }

        string v = (score).ToString();
        ScoreText.text = v;
        string z = counter.ToString();
        CounterText.text = z;
    }

    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i>0; i--)  //For loop for determining the position of new snake body part. 
        {
            _segments[i].position = _segments[i - 1].position;
        }


        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }

    private void RegularGrow()                                // creating clone of our body prefab with instantiate method, and creating at the position which we calculated in the for loop.
    {
        for (int i = 0; i < 1; i++)
       {
           Transform segment = Instantiate(this.Childs);

           segment.position = _segments[_segments.Count - 1].position;
           _segments.Add(segment);
            WaitSec();
            score += 10;
       }
       /*Transform segment1 = Instantiate(this.ChunkyBait);
       segment1.position = _segments[_segments.Count - 1].position;
       _segments.Add(segment1);*/

    }
    public void ChunkyGrow()
    {
        for (int i = 0; i < 3; i++)
        {
            RegularGrow();
            /*Transform segment = Instantiate(this.Childs);

            segment.position = _segments[_segments.Count - 1].position;
            _segments.Add(segment);
            WaitSec();*/
        }
    }

    public void PoisonousGrow()
    {
            Transform segment = _segments[_segments.Count - 1];
            Destroy(segment);
            score = score - 10;
 
    }

    private void ResetState()                             // Destroying all segments without initialsize part, destroying amount of _segments which added by player.
    {
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for(int i= 1; i<this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.Childs));
        }

        this.transform.position = Vector3.zero;
    }
    public void AdjustSpeed(float newSpeed)
    {
        
        MovSpeed = newSpeed;

    }

    public void Gameover()
    {
        //CountFT();
        if (score < 0)
        {
            FindObjectOfType<GameManager>().gameover();
        }
        else if (counter ==0) 
        {
            //FindObjectOfType<GameManager>().gameover();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)                                         //With the collision we carry out the our functions. If snake touches food, it will grow. If it touches border, it will reset.
    {
        
        //when snake touch to Food, create segment 
        if (other.tag == "FOOD")
        {
            food = GameObject.FindGameObjectWithTag("FOOD");
            StopAllCoroutines();
          if (food.GetComponent<SpriteRenderer>().material.color == Color.black)
          {

                PoisonousGrow();
                Debug.Log("Poison");
                StartCoroutine(CountFT());
            }
          else if (food.GetComponent<SpriteRenderer>().material.color == Color.white )
          {
                RegularGrow();
                Debug.Log("regular");
                StartCoroutine(CountFT());
            }
            else if (food.GetComponent<SpriteRenderer>().material.color == Color.yellow)
          {
                ChunkyGrow();
                Debug.Log("chunkkki");
                StartCoroutine(CountFT());
            }
        }
        else if ( other.tag == "OBSTACLE")
        {
           ResetState();
           FindObjectOfType<GameManager>().gameover();
            
        }
    }

    /*public void SpeedChange()
    {
        SliderSpeedControl.Speed = MovSpeed;
    }*/
    IEnumerator CountFT()
    {
        counter = 15;
        while (true)
        {
            for (int i = 15; i > 0; i--)
            {
                counter = counter - 1;
                yield return new WaitForSeconds(1);
                if(counter==0)
                {
                    FindObjectOfType<GameManager>().gameover();
                    StopAllCoroutines();
                }
            }
            yield return new WaitForSeconds(1);
        }


    }
    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1.0f);
    }
    /*public void ScoreValue(int newScore)
    {
        score += newScore;
        updateScore();

    }
    {
        textEditor.text = " " + score;
    }*/

}
