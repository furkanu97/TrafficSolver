using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject[] puzzlePieces;
    public NavMeshAgent[] cars;
    public GameManager gameManager;
    public void Go(string text)
    {
        var txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;

        surface.BuildNavMesh();
        gameManager.agentCount = cars.Length;

        foreach (var car in cars)
        {
            car.GetComponent<CarController>().SetOwnDestination();
            car.GetComponent<NavMeshAgent>().isStopped = false;
            car.GetComponent<BoxCollider>().enabled = true;
        }
        
        foreach (var puzzlePiece in puzzlePieces)
        {
            puzzlePiece.GetComponent<Draggable>().isDraggable = false;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    public void NextScene()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex + 1);
    }
}
