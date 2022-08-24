using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour {
	
	public Transform playerCube;
	[Header("Important Laser Components")]
	private LineRenderer _lineRenderer;
	public GameObject laserHitMarker;
	public Transform laserStartMarker;
	public Transform laserEndMarker;
	private LayerMask _whatGetsHitMask;
	public ParticleSystem burnVFX;
	public AudioSource audioSource;
	public CircleCollider2D beamHitBox;

	[Header("Laser Stats")]
	private readonly float _laserRange = 3.5f;
	public float laserDamage = .05f;
	
	[Header("Laser Feedbacks")]
	public MMF_Player laserFeedbackPlayer;

	void Start() {
		_lineRenderer = GetComponent<LineRenderer>();
		audioSource = GetComponent<AudioSource>();
	}
	private void Update() {
		if (Keyboard.current.eKey.wasPressedThisFrame) {
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
	public void FireLaserV1(Vector2 dir) {
		
		if (Keyboard.current.spaceKey.isPressed || Gamepad.current.bButton.isPressed) {
			_lineRenderer.enabled = true;

			var position = transform.position;
			RaycastHit2D hit = Physics2D.Raycast(position, dir, _laserRange, _whatGetsHitMask);
			_lineRenderer.SetPosition(0, position);
			
			if (hit && hit.distance < _laserRange) {
				_lineRenderer.SetPosition(1, hit.point);

			} else {
				_lineRenderer.SetPosition(1, laserHitMarker.transform.position);
			}
			
			if (hit) {
				if (hit.transform.CompareTag("Enemy")) {
					IDmgAndHpInterface enemyHit = hit.collider.GetComponent<IDmgAndHpInterface>();
					enemyHit.TakeDamage(0.05f);
					MMFloatingTextSpawnEvent.Trigger(0, hit.point, laserDamage.ToString(), Vector3.up, .5f);
				}
			}
		} else {
			_lineRenderer.enabled = false;
		}

	}
}


