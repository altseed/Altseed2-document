using Altseed;

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
            // キャラクターノードを追加
            AddChildNode(characterNode);

            // UIを表示するノード
            var uiNode = new Node();

            // UIノードを追加
            AddChildNode(uiNode);

+            // 背景に使用するテクスチャ
+            var backTexture = new SpriteNode();
+            // 背景のテクスチャを読み込む
+            backTexture.Texture = Texture2D.LoadStrict("Resources/Background.png");
+            // 表示位置を奥に設定
+            backTexture.ZOrder = -100;
+
+            // 背景テクスチャを追加
+            AddChildNode(backTexture);

            // プレイヤーを設定
            player = new Player(new Vector2F(100, 360));

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);
        }
    }
}