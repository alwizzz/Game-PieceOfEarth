using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float rotateSpeed = 0.1f;

    [SerializeField] bool isMoving;
    [SerializeField] bool isAbleToMove;

    Animator playerAnimator;

    private void Start()
    {
        isMoving = false;
        isAbleToMove = true;

        playerAnimator = playerBody.GetComponentInChildren<Animator>();

        transform.position = GameMaster.GetSpawnPoint().position;
    }

    private void FixedUpdate()
    {
        if (isAbleToMove /* &&  levelMaster.GameHasStarted() */)
        {
            Move();
        }
    }

    void Move()
    {
        // "actual" movement vector is affected by blocker, while the other is not

        float xValue = Input.GetAxisRaw("Horizontal");
        float zValue = Input.GetAxisRaw("Vertical");

        // continous movement
        var actualXValue = xValue;
        var actualZValue = zValue;

        var movementVector = new Vector3(
            xValue * moveSpeed * Time.fixedDeltaTime,
            0f,
            zValue * moveSpeed * Time.fixedDeltaTime
        );

        var actualMovementVector = new Vector3(
            actualXValue * moveSpeed * Time.fixedDeltaTime,
            0f,
            actualZValue * moveSpeed * Time.fixedDeltaTime
        );


        transform.Translate(actualMovementVector);

        if (movementVector != Vector3.zero)
        {
            //if (!levelMaster.GameHasStarted()) { levelMaster.StartLevel(); }

            var toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(
                playerBody.transform.rotation,
                toRotation,
                rotateSpeed * Time.fixedDeltaTime
            );
        }

        UpdateIsMoving(movementVector);

    }

    public void SetIsAbleToMove(bool value)
    {
        isAbleToMove = value;
        if (!value) { UpdateIsMoving(Vector3.zero); } //force isMoving to be false
    }

    void UpdateIsMoving(Vector3 movementVector)
    {
        isMoving = (movementVector == Vector3.zero ? false : true);
        playerAnimator.SetBool("isMoving", isMoving);
    }


}
