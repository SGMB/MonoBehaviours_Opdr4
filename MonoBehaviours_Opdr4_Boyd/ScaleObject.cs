using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
public class ScaleObject : GameObject
{
    private Transform transform;
    private float time;
    private float speed;

    public float Speed
    {
        get { return speed; }
    }
	public ScaleObject(Transform trans, SpriteRenderer render, Texture2D texture, float speed) : base(trans, render)
	{
        render.Texture = texture;
        transform = trans;
        this.speed = speed;
    }
    public ScaleObject(Transform trans, SpriteRenderer render, Texture2D texture, Vector2 origin, float speed) : base(trans, render)
    {
        render.Texture = texture;
        transform = trans;
        transform.Origin = origin;
        this.speed = speed;
    }

    public override void Update(GameTime gameTime)
    {
        time = (float)gameTime.TotalGameTime.TotalSeconds * speed;
        transform.Scale = new Vector2((MathF.Sin(time) + 1) / 2, (MathF.Sin(time) + 1) / 2);

        base.Update(gameTime);
    }
}
