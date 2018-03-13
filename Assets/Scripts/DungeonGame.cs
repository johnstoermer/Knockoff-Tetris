using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGame : MonoBehaviour {
    private int redScore = 0;
    private int blueScore = 0;
    private int greenScore = 0;
    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public int playerMagicResist = 0;
    public int playerPhysicalResist = 0;
    public int enemyMaxHealth = 100;
    public int enemyHealth = 100;
    public int enemyMagicResist = 0;
    public int enemyPhysicalResist = 0;
    public int enemyMagicDamage = 0;
    public int enemyPhysicalDamage = 0;
    public int enemyAttackRate = 1;

	void Start () {
		
	}
	
	void Update () {

	}

    void playGame() {

    }

    void fight() {
        while (enemyHealth > 0) {
            StartCoroutine(damagePlayer());
        }
    }

    IEnumerator damagePlayer() {
        playerHealth -= enemyMagicDamage / (1 + playerMagicResist) + enemyPhysicalDamage / (1 + playerPhysicalResist);
        yield return new WaitForSeconds(enemyAttackRate);
    }

    void damageEnemy(int magicDamage, int physicalDamage) {
        enemyHealth -= magicDamage / (1 + enemyMagicResist) + physicalDamage / (1 + enemyPhysicalResist);
    }

    void healPlayer(int healing) {
        playerHealth += healing;
        if (playerHealth >= playerMaxHealth) {
            playerHealth = playerMaxHealth;
        }
    }

    public void updateScore(int redScore, int blueScore, int greenScore) {
        damageEnemy(redScore, blueScore);
        healPlayer(greenScore);
    }
}
