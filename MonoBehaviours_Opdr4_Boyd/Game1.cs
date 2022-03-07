using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoBehaviours_Opdr4_Boyd
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int clicked;
        private bool CLICKASDBIUAS;

        Texture2D _texture;
        RotaterObject[] _rotatorObj;
        BounceObject[] _bouncerObj;
        ScaleObject[] _scaleObj;

        Transform[] transRot;
        Transform[] transBounce;
        Transform[] transScale;

        SpriteFont _font;
        Viewport viewPort;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Content.RootDirectory = "Content";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            viewPort = GraphicsDevice.Viewport;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("Shield");
            _font = Content.Load<SpriteFont>("ButtonFont");

            #region Rotation Values
            //transform array
            /// Is zodat ik meerdere transforms kan gebruiken met de zelfde naam.
            transRot = new Transform[]
            {
                new Transform(),
                new Transform(),
                new Transform(),
                new Transform(),
                new Transform()
            };

            SpriteRenderer rendererRot = new SpriteRenderer();

            _rotatorObj = new RotaterObject[]
            {
                new RotaterObject(transRot[0], rendererRot, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 3),
                new RotaterObject(transRot[1], rendererRot, _texture, 5),
                new RotaterObject(transRot[2], rendererRot, _texture, new Vector2(_texture.Width, 0), 12),
                new RotaterObject(transRot[3], rendererRot, _texture, new Vector2(_texture.Width, _texture.Height), 9),
                new RotaterObject(transRot[4], rendererRot, _texture, new Vector2(0, _texture.Height), 1)
            };

            //position rotation objects
            _rotatorObj[0].transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            _rotatorObj[1].transform.Position = new Vector2(viewPort.Width / 3, viewPort.Height / 4);
            _rotatorObj[2].transform.Position = new Vector2(viewPort.Width / 1.5f, viewPort.Height / 4);
            _rotatorObj[3].transform.Position = new Vector2(viewPort.Width / 1.5f, viewPort.Height / 1.3f);
            _rotatorObj[4].transform.Position = new Vector2(viewPort.Width / 3, viewPort.Height / 1.3f);
            #endregion

            #region Bounce Values
            transBounce = new Transform[]
            {
                new Transform(),
                new Transform(),
                new Transform()
            };

            SpriteRenderer rendererBounce = new SpriteRenderer();

            _bouncerObj = new BounceObject[]
            {
                new BounceObject(transBounce[0], rendererBounce, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 3, 3),
                new BounceObject(transBounce[1], rendererBounce, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 2.5f, 3),
                new BounceObject(transBounce[2], rendererBounce, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 6.5f, 3)
            };

            //Position Bounce Object
            _bouncerObj[0].transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2.5f);
            _bouncerObj[1].transform.Position = new Vector2(viewPort.Width / 4, viewPort.Height / 2.5f);
            _bouncerObj[2].transform.Position = new Vector2(viewPort.Width / 1.3f, viewPort.Height / 2.5f);
            #endregion

            #region Scale Values
            transScale = new Transform[]
            {
                new Transform(),
                new Transform(),
                new Transform(),
                new Transform()
            };

            SpriteRenderer rendererScale = new SpriteRenderer();

            _scaleObj = new ScaleObject[]
            {
                new ScaleObject(transScale[0], rendererScale, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 2),
                new ScaleObject(transScale[1], rendererScale, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 4),
                new ScaleObject(transScale[2], rendererScale, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 8),
                new ScaleObject(transScale[3], rendererScale, _texture, new Vector2(_texture.Width/2, _texture.Height/2), 0.5f)
            };

            //position scale object
            _scaleObj[0].transform.Position = new Vector2(viewPort.Width/3, viewPort.Height/3);
            _scaleObj[1].transform.Position = new Vector2(viewPort.Width/ 1.5f, viewPort.Height/3);
            _scaleObj[2].transform.Position = new Vector2(viewPort.Width/3, viewPort.Height / 1.5f);
            _scaleObj[3].transform.Position = new Vector2(viewPort.Width/1.5f, viewPort.Height/1.5f);
            #endregion

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space)) CLICKASDBIUAS = true;
            else if (CLICKASDBIUAS == true)
            {
                if (keyboardState.IsKeyUp(Keys.Space))
                {
                    clicked += 1;
                    CLICKASDBIUAS = false;
                }
            }
            else CLICKASDBIUAS = false;

            if (clicked == 3) clicked = 0;

            for (int i = 0; i < _bouncerObj.Length; i++) _bouncerObj[i].Update(gameTime);

            for (int i = 0; i < _rotatorObj.Length; i++) _rotatorObj[i].Update(gameTime);

            for (int i = 0; i < _scaleObj.Length; i++) _scaleObj[i].Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "PRESS  SPACE  FOR  NEXT  EXAMPLE", new Vector2(viewPort.Width / 2.8f, 0), Color.Black);
            switch (clicked)
            {
                case 0:
                    for (int i = 0; i < _bouncerObj.Length; i++)
                    {
                        _bouncerObj[i].Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"speed: {_bouncerObj[i].Speed} wave height: {_bouncerObj[i].WaveHeight}", new Vector2(_bouncerObj[i].transform.Position.X - 75, _bouncerObj[i].transform.Position.Y + _texture.Height), Color.Black);
                    }
                    break;
                case 1:
                    for (int i = 0; i < _rotatorObj.Length; i++)
                    {
                        _rotatorObj[i].Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"rotation speed: {_rotatorObj[i].Speed}", new Vector2(_rotatorObj[i].transform.Position.X - 65, _rotatorObj[i].transform.Position.Y + _texture.Height), Color.Black);
                    }
                    break;
                case 2:
                    for (int i = 0; i < _scaleObj.Length; i++)
                    {
                        _scaleObj[i].Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"scale speed: {_scaleObj[i].Speed}", new Vector2(_scaleObj[i].transform.Position.X - 45, _scaleObj[i].transform.Position.Y + _texture.Height), Color.Black);
                    }
                    break;

            }
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
