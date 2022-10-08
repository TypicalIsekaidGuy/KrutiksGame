using UnityEngine;
using static PlayerControls;

public class PlayerControls : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Camera camera;
    public PlayerMovement movement;
    [SerializeField] private Mesh player_mesh;
    [SerializeField] private Mesh[] character_meshes;
    [SerializeField] private Material[] character_materials;
    public enum PLAYER_CHARACTERS {Sol,Ray};
    public static PLAYER_CHARACTERS current_player_character = PLAYER_CHARACTERS.Sol;
    // Start is called before the first frame update
    void Start()
    {
        current_player_character = PLAYER_CHARACTERS.Sol;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z  - 5.74f);
    }
    public void ChangeCharacter(int s)
    {
        if ((int)current_player_character != s)
        {
            current_player_character = (PLAYER_CHARACTERS) s;
            player_mesh = character_meshes[s];
            GetComponent<MeshFilter>().mesh = player_mesh;
            GetComponent<MeshRenderer>().material = character_materials[s];

        }
    }
    public void UseAbility()
    {
        switch (current_player_character)
        {
            case PLAYER_CHARACTERS.Sol:
                gameManager.obstaclesForSol.BreakObstacle();
                break;
            case PLAYER_CHARACTERS.Ray:
                gameManager.obstaclesForRay.BreakObstacle();
                break;
        }
    }
    public void ChangeLocation(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }
}
