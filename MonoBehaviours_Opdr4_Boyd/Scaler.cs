using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
public class Scaler : MonoBehaviour
{
    private float time;
    private float speed;
    public float Speed
    {
        get { return speed; }
    }
	public Scaler(float speed)
	{
        this.speed = speed;
    }

    public override void UpdateMono(GameTime gameTime, GameObject gamer)
    {
        time = (float)gameTime.TotalGameTime.TotalSeconds * speed;
        gamer.Transform.Scale = new Vector2((MathF.Sin(time) + 1) / 2, (MathF.Sin(time) + 1) / 2);

        base.UpdateMono(gameTime, gamer);
    }
}
