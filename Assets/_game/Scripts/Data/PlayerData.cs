using UnityEngine;

namespace _game.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [field:Header("Movement")] 
        [field:SerializeField] public float moveSpeed { get; private set; }
        [field:SerializeField] public float jumpPower{ get; private set; }
        
        [field: SerializeField] public  float rotateSpeed { get; private set; }
        
        [field:Header("Fly")] 
        [field:SerializeField] public float flySpeed { get; private set; }
        
        [field: SerializeField] public  float flyRotateSpeed { get; private set; }

        [field: SerializeField] public float rotateSmoth { get; private set; } = 40;
        [field:Header("Physics")] 
        [field:SerializeField] public LayerMask groundLayer{ get; private set; }
        
        [field:SerializeField] public LayerMask obstacleLayer{ get; private set; }

        [field:SerializeField] public float groundDistance{ get; private set; }

    }
}