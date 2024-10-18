using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Text currentScoreTxt;
    [SerializeField] private Text BestScoreTxt;

    private Rigidbody2D _rb2d;
    private float fuel = 100f;

    Transform RocketTransform;
    

    float score = 0;
    
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;


    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
        

        score = gameObject.transform.position.y;

    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        

        if(fuel > 0)
        {
            _rb2d.AddForce(Vector3.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
        }
        
    }

    public void Update()
    {
        float y = gameObject.transform.position.y;

        if(score < y)
        {
            score = y;
        }

        currentScoreTxt.text = $"{y.ToString("N2")} M";
        BestScoreTxt.text = $"HIGH : {score.ToString("N2")} M";
    }

    public void OnClickRetryBtn()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
