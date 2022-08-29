using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathRay : Weapon {
	
	[Header("Important Laser Components")]
	private LineRenderer _lineRenderer;
	public GameObject laserHitMarker;
	public Transform laserStartMarker;
	public Transform laserEndMarker;
	public ParticleSystem burnVFX;
	public ParticleSystem sparkVFX;
	public ParticleSystem eyeVFX;
	public CircleCollider2D beamHitBox;

	[Header("Laser Feedbacks")]
	public MMF_Player laserFeedbackPlayer;

	void Start() {
		_lineRenderer = GetComponent<LineRenderer>();
		audioSource = GetComponent<AudioSource>();
	}
	private void Update() {
		if (Keyboard.current.eKey.wasPressedThisFrame /*&& !laserFeedbackPlayer.IsPlaying || Gamepad.current.bButton.wasPressedThisFrame*/) {
			FireLaser();
		}

		if (laserFeedbackPlayer.IsPlaying) {
			burnVFX.gameObject.SetActive(true);
			sparkVFX.gameObject.SetActive(true);
			eyeVFX.gameObject.SetActive(true);
			_lineRenderer.SetPosition(0, transform.position);
			_lineRenderer.SetPosition(1, laserHitMarker.transform.position);
			burnVFX.transform.position = laserHitMarker.transform.position;
			sparkVFX.transform.position = laserHitMarker.transform.position;
			eyeVFX.transform.position = transform.position;
		}

		if (!laserFeedbackPlayer.IsPlaying) {
			audioSource.Stop();
			_lineRenderer.enabled = false;
			burnVFX.transform.position = laserStartMarker.position;
			sparkVFX.transform.position = laserStartMarker.position;
			eyeVFX.transform.position = transform.position;
			burnVFX.gameObject.SetActive(false);
			sparkVFX.gameObject.SetActive(false);
			eyeVFX.gameObject.SetActive(false);
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


