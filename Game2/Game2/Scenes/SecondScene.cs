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
    class SecondScene : OpenScene
    {
        public SecondScene() { }

        private Table table;
        public override Table Table
        {
            get { return table; }
            set { table = value; }
        }

        public override void initialize()
        {
            SetupScene();

            Table.row().setPadTop(250).setPadRight(-640);
            Table.add(new Label("Options Menu").setFontScale(5));
            Table.row().setPadRight(-640);
            Table.add(new Label("You can enable/disable options here!").setFontScale(2));

            Table.row().setPadRight(-640);
            Table.add(new Label("Sound options").setFontScale(2));
            Table.row().setPadRight(-640);
            Table.add(new CheckBox("Master sound", Skin.createDefaultSkin())).getElement<CheckBox>();

            Table.row().setPadRight(-640);
            Table.add(new Label("Graphics options").setFontScale(2));
            Table.row().setPadRight(-640);
            Table.add(new CheckBox("enable multicore htreading", Skin.createDefaultSkin())).getElement<CheckBox>();
            Table.row().setPadRight(-640);
            Table.add(new CheckBox("enable v-sync", Skin.createDefaultSkin())).getElement<CheckBox>();

            Table.row().setPadRight(-640);
            var playButton = Table.add(new TextButton("Exit", Skin.createDefaultSkin())).setFillX().setMinHeight(30).setMaxWidth(320).getElement<TextButton>();
            playButton.onClicked += PlayButton_onClicked;       
        }

        private void PlayButton_onClicked(Button obj)
        {
            Core.startSceneTransition(new TextureWipeTransition(() => new FirstScene())
            {
                transitionTexture = Core.content.Load<Texture2D>("nez/textures/textureWipeTransition/crissCross")
            });
        }
    }
}
