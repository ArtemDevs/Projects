using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.UI;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {

        public Game1() : base(640 * 2, 480 * 2)
        {
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Scene.setDefaultDesignResolution(640, 480, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            scene = new FirstScene();
        }
    }
}
