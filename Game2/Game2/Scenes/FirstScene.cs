using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game2
{
    class FirstScene : OpenScene
    {
        public FirstScene() { }

        private Table table;
        public override Table Table
        {
            get { return table; }
            set { table = value; }
        }
    

        public override void initialize()
        {
            SetupScene();
            Table.row().setPadTop(150).setPadRight(-640);
            Table.add(new Label("Main Menu").setFontScale(5));
            Table.row().setPadRight(-640);
            Table.add(new Label("This is our main menu for our game!").setFontScale(2));

            Table.row().setPadRight(-640);
            var playButton2 = Table.add(new TextButton("Enter Game", Skin.createDefaultSkin())).setFillX().setMinHeight(30).setMaxWidth(320).getElement<TextButton>();
            playButton2.onClicked += PlayButton2_onClicked;

            Table.row().setPadRight(-640);
            var playButton = Table.add(new TextButton("Options menu", Skin.createDefaultSkin())).setFillX().setMinHeight(30).setMaxWidth(320).getElement<TextButton>();        
            playButton.onClicked += PlayButton_onClicked;

            //Table.row().setPadRight(-640);
            //Table.add(new ProgressBar(0, 1, 0.1f, false, ProgressBarStyle.create(Color.LawnGreen, Color.White)).setValue(0.45f));

            //Table.row().setPadRight(-640);
            //Table.add(new TextField("A simple Textfield!", Skin.createDefaultSkin())).getElement<TextField>();
            //Table.row().setPadRight(-640);
            //Table.add(new CheckBox("Is this tutorial great?", Skin.createDefaultSkin())).getElement<CheckBox>();
        }

        private void PlayButton_onClicked(Button obj)
        {
            Core.startSceneTransition(new TextureWipeTransition(() => new SecondScene())
            {
                transitionTexture = Core.content.Load<Texture2D>("nez/textures/textureWipeTransition/wink")
            });
        }

        private void PlayButton2_onClicked(Button obj)
        {
            Core.startSceneTransition(new TextureWipeTransition(() => new WorldScene())
            {
                transitionTexture = Core.content.Load<Texture2D>("nez/textures/textureWipeTransition/horizontal")
            });
        }
    }
}
