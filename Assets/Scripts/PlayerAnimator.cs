using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private	Animator animator;
	private	MovementRigidbody2D	movement;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		movement = GetComponentInParent<MovementRigidbody2D>();
	}

	public void UpdateAnimation(float x)
	{
		// ??/?? ????? ????? ???? ??
		if ( x != 0 )
		{
			// ?첨???? ????????? ??/?? ???? : ???? ???? ??
			SpriteFlipX(x);
		}

		animator.SetBool("isJump", !movement.IsGrounded);

		// ???? ??? ??????
		if ( movement.IsGrounded )
		{
			// velocityX?? 0??? "Idle", velocityX?? 0.5??? "Walk", velocityX?? 1??? "Run" ???
			animator.SetFloat("velocityX", Mathf.Abs(x));
		}
		// ???? ??? ???? ??????
		else
		{
			// velocityY?? ??????? "JumpDown", velocityY?? ?????? "JumpUp" ???
			animator.SetFloat("velocityY", movement.Velocity.y);
		}
	}

	// SpriteRenderer ????????? Filp?? ????? ??????? ???????? ??
	// ??? ????? ????? ????? ??????? ??????
	// ?첨?????? ???? ??? ??????? ?????? ??????? ??? ????
	// ????????? ????? ???? Transform.Scale.x?? -1, 1?? ???? ????
	private void SpriteFlipX(float x)
	{
		transform.parent.localScale = new Vector3((x < 0 ? -1 : 1), 1, 1);
	}

	// player 슬라이딩 애니메이션
	public void StartSliding()
	{
		Debug.Log("슬라이딩 애니메이션 시작");
	}

    public void StopSliding()
    {
        Debug.Log("슬라이딩 애니메이션 종료");
    }

	// player 장풍 애니메이션
	public void JangPoongShooting()
	{
		Debug.Log("장풍 애니메이션");
	}
}


