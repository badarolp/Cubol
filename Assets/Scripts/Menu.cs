using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public Transform player;
    private float distanceToMove = 1f;
    private float moveSpeed = 3f;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private bool isMoving = false;
    private float t;

    public IEnumerator move()
    {
        isMoving = true;
        t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / distanceToMove);
            player.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

    public IEnumerator moveDireita()
    {
        if (!isMoving && FindObjectOfType<GameManager>().isPlaying)
        {
            startPosition = player.position;
            endPosition = player.position;
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            StartCoroutine(move());
        }
        yield return null;
    }

    public IEnumerator moveCima()
    {
        if (!isMoving && FindObjectOfType<GameManager>().isPlaying)
        {
            startPosition = player.position;
            endPosition = player.position;
            endPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z + distanceToMove);
            StartCoroutine(move());
        }
        yield return null;
    }

    public IEnumerator moveEsquerda()
    {
        if (!isMoving && FindObjectOfType<GameManager>().isPlaying)
        {
            startPosition = player.position;
            endPosition = player.position;
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
            StartCoroutine(move());
        }
        yield return null;
    }

    public IEnumerator moveBaixo()
    {
        if (!isMoving && FindObjectOfType<GameManager>().isPlaying)
        {
            startPosition = player.position;
            endPosition = player.position;
            endPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z - distanceToMove);
            StartCoroutine(move());
        }
        yield return null;
    }    
    public void BotaoD()
    {
        StartCoroutine(moveDireita());
    }

    public void BotaoW()
    {
        StartCoroutine(moveCima());
    }

    public void BotaoA()
    {
        StartCoroutine(moveEsquerda());
    }

    public void BotaoS()
    {
        StartCoroutine(moveBaixo());
    }

    public void BotaoCerto()
    {
        if (!isMoving)
        {
            StartCoroutine(movimentacaoCerta());
        }
    }

    public IEnumerator movimentacaoCerta()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveCima());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveCima());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveCima());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveCima());
        yield return new WaitForSeconds(1);        
        FindObjectOfType<GameManager>().EndGame();
    }

    public void BotaoZona()
    {
        if (!isMoving)
        {
            StartCoroutine(movimentacaoZonaVermelha());
        }
    }    

    public IEnumerator movimentacaoZonaVermelha()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveCima());
        yield return new WaitForSeconds(1);
        FindObjectOfType<GameManager>().EndGame();
    }

    public void BotaoBranco()
    {
        if (!isMoving)
        {
            StartCoroutine(movimentacaoInsuficiente());
        }
    }

    public IEnumerator movimentacaoInsuficiente()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        StartCoroutine(moveDireita());
        yield return new WaitForSeconds(1);
        FindObjectOfType<GameManager>().EndGame();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }    
}
