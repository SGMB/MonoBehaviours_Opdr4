using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
public class RotaterObject : GameObject
{
    private float RotationSpeed;
    private Transform transform;

    public float Speed
    {
        get { return RotationSpeed; }
    }
    public RotaterObject(Transform trans, SpriteRenderer render, Texture2D texture, float speed) : base(trans, render)
    {
        render.Texture = texture;
        transform = trans;
        RotationSpeed = speed;
	}
    public RotaterObject(Transform trans, SpriteRenderer render, Texture2D texture, Vector2 origin, float speed) : base(trans, render)
    {
        render.Texture = texture;
        transform = trans;

        transform.Origin = origin;
        RotationSpeed = speed;
    }

    public override void Update(GameTime gameTime)
    {
        transform.Rotation += 0.03f * RotationSpeed;
        base.Update(gameTime);
    }
}
