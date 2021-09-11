using UnityEngine;

public class TPShadow : MonoBehaviour
{
    [SerializeField] Transform player = null;
    Animator anim = null;

    bool isPlaced;

    public bool IsPlaced { get => isPlaced; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isPlaced = false;
    }

    void Update()
    {
        if (!isPlaced) transform.position = player.position;
    }

    public void Place()
    {
        isPlaced = true;
        anim.SetBool("IsPlaced", isPlaced);
    }

    public void ChasePlayer()
    {
        isPlaced = false;
        anim.SetBool("IsPlaced", isPlaced);
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }
}
