using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
public class Rotater : MonoBehaviour
{
    private float RotationSpeed;

    public float Speed
    {
        get { return RotationSpeed; }
    }

    public Rotater(float speed)
    {
        RotationSpeed = speed;
    }
    public override void UpdateMono(GameTime gameTime, GameObject gamer)
    {
        gamer.Transform.Rotation += 0.03f * RotationSpeed;
        base.UpdateMono(gameTime, gamer);
    }
}
