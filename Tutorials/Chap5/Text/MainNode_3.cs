using Altseed2;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        // キャラクターを表示するノード
        private Node characterNode = new Node();
        
        // プレイヤーの参照
        private Player player;

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // ================================================================
            // 省略
            // ================================================================

            // 敵を追加する。
+            characterNode.AddChildNode(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            characterNode.AddChildNode(new StraightShotEnemy(player, new Vector2F(600, 620)));

            characterNode.AddChildNode(new Meteor(player, new Vector2F(910, 400), new Vector2F(-4.0f, 0.0f)));

+            characterNode.AddChildNode(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
        }
    }
}
