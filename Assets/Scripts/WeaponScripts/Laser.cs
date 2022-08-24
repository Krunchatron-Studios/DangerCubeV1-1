using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : Weapon {
	
	[Header("Important Laser Components")]
	private LineRenderer _lineRenderer;
	public GameObject laserHitMarker;
	public Transform laserStartMarker;
	public Transform laserEndMarker;
	public ParticleSystem burnVFX;
	public CircleCollider2D beamHitBox;

	[Header("Laser Feedbacks")]
	public MMF_Player laserFeedbackPlayer;

	void Start() {
		_lineRenderer = GetComponent<LineRenderer>();
		audioSource = GetComponent<AudioSource>();
	}
	private void Update() {
		if (Keyboard.current.eKey.wasPressedThisFrame || Gamepad.current.bButton.wasPressedThisFrame) {
			FireLaser();
		}

		if (laserFeedbackPlayer.IsPlaying) {
			burnVFX.gameObject.SetActive(true);
			_lineRenderer.SetPosition(0, transform.position);
			_lineRenderer.SetPosition(1, laserHitMarker.transform.position);
			burnVFX.transform.position = laserHitMarker.transform.position;
		}

		if (!laserFeedbackPlayer.IsPlaying) {
			audioSource.Stop();
			_lineRenderer.enabled = false;
			burnVFX.transform.position = laserStartMarker.position;
			burnVFX.gameObject.SetActive(false);
			beamHitBox.gameObject.SetActive(false);
		}
	}
	public void FireLaser() {
		if (!laserFeedbackPlayer.IsPlaying) {
			audioSource.Play();
		}
		
		_lineRenderer.enabled = true;
		beamHitBox.gameObject.SetActive(true);
		Vector3 position = transform.position;
		_lineRenderer.SetPosition(0, position);
		laserFeedbackPlayer?.PlayFeedbacks();
	}
	
}


