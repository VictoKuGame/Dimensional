using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameControlManage : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    public static int width = 5;
    [SerializeField]
    [Range(1, 50)]
    public static int height = 5;
    public static int enemyHealth = 1;
    public static int playerStrength=1;
    public static int level=1;
    public static int numOfEnemiesAtSpawn=1;
}
