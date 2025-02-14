using UnityEngine ;

public class RedZone : MonoBehaviour 
{
    private GameManager _gameManager;

    [SerializeField] private GameObject restartPanel;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerStay (Collider other) {
      Cube cube = other.GetComponent <Cube> () ;
      if (cube != null) {
         if (!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < .1f) 
         {
                restartPanel.SetActive(true);
         }
      }
   }
}
