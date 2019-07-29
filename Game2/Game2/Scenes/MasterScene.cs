using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class MasterScene : Scene
    {
        public override void initialize()
        {
            clearColor = Color.LightGray;
            addRenderer(new DefaultRenderer());

            var tiledMap = content.Load<TiledMap>("neztilemap");
            var objectlayer = tiledMap.getObjectGroup("objects");
            var spawn = objectlayer.objectWithName("spawn");

            var tiledEntity = createEntity("tiled-map");
            tiledEntity.addComponent(new TiledMapComponent(tiledMap, "Tile Layer 1"));


            var player = createEntity("player");
            player.transform.setPosition(spawn.x, spawn.y);
            player.addComponent(new PrototypeSprite(16, 32)).setColor(Color.Red);
            player.addComponent<PlayerController>();
            player.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("Tile Layer 1")));
            player.addComponent(new BoxCollider(-8, -16, 16, 32));
        }
    }
}
