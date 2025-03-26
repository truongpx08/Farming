// Assets/Scripts/Player/Models/PlayerModel.cs

public class PlayerModel
{
    public float MoveSpeed { get; private set; }
    public float RotateSpeed { get; private set; }

    public PlayerModel(float moveSpeed = 3f, float rotateSpeed = 15f)
    {
        MoveSpeed = moveSpeed;
        RotateSpeed = rotateSpeed;
    }
}