using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isPlaying = true;

    public float restartDelay = 1f;

    public GameObject ParabensUI;

    public GameObject TenteNovamenteUI;
    
    public void Parabens()
    {
        Invoke("SetParabensActive", 1f);
        isPlaying = false;
        EndGame();
    }

    public void TenteNovamente()
    {
        Invoke("SetTenteNovamenteActive", 1f);
        isPlaying = false;
        EndGame();
    }    

    public void EndGame()
    {
        if(isPlaying)
        {
            Invoke("SetTenteNovamenteActive", 1f);
            TenteNovamenteUI.SetActive(true);
        }
    }

    void SetTenteNovamenteActive()
    {
        TenteNovamenteUI.SetActive(true);
    }

    void SetParabensActive()
    {
        ParabensUI.SetActive(true);
    }    
}