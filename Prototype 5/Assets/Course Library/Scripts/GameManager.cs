using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour 

{ 
public List<GameObject> targets; 
private float spawnRate = 1.0f; 
private int score;
public TextMeshProUGUI scoreText;

void Start() { 

StartCoroutine(SpawnTarget()); 
score = 0;
UpdateScore(0);

    scoreText.text = "HELLO FROM HELL";
    scoreText.color = Color.red;
} 

IEnumerator SpawnTarget() { while (true) { yield return new WaitForSeconds(spawnRate); int index = Random.Range(0, targets.Count); Instantiate(targets[index]);
UpdateScore(5); } }

private void UpdateScore(int scoreToAdd) {
	score += scoreToAdd;
	scoreText.text = "Score: " + score; }

private void OnMouseDown() { Destroy(gameObject); } 

private void OnTriggerEnter(Collider other) { Destroy(gameObject); } void Update() { } }