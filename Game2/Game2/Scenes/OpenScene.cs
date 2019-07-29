using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    abstract class OpenScene : Scene
    {
        abstract public Table Table { get; set; }
        
        public void SetupScene()
        {
            clearColor = Color.LightGray;
            addRenderer(new DefaultRenderer());

            var UICanvas = createEntity("ui-canvas").addComponent(new UICanvas());
            Table = UICanvas.stage.addElement(new Table());

            Table.setFillParent(true).top().padLeft(10).padTop(50);
            Table = UICanvas.stage.addElement(new Table());
        }
    }
}
