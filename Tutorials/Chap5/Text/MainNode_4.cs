using Altseed2;
+ using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
+       // カウンタ
+       private int count = 0;

+       // 敵を格納するキュー
+       private Queue<Enemy> enemies = new Queue<Enemy>();

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

            // 背景に使用するテクスチャ
            var backTexture = new SpriteNode();
            // 背景のテクスチャを読み込む
            backTexture.Texture = Texture2D.LoadStrict("Resources/Background.png");
            // 表示位置を奥に設定
            backTexture.ZOrder = -100;

            // 背景テクスチャを追加
            AddChildNode(backTexture);

            // プレイヤーを設定
            player = new Player(new Vector2F(100, 360));

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);

-           characterNode.AddChildNode(new StraightShotEnemy(player, new Vector2F(600, 620)));
-
-           characterNode.AddChildNode(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
-
-           characterNode.AddChildNode(new StraightShotEnemy(player, new Vector2F(600, 620));
-
-           characterNode.AddChildNode(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

+           // ウェーブを初期化する
+           InitWave();
        }

+       // ウェーブの初期化
+       private void InitWave()
+       {
+           // enemies.Enqueue～でウェーブに敵を追加
+           // 追加した順番に敵が出現する
+
+
+           enemies.Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));
+
+           enemies.Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));
+
+           enemies.Enqueue(new Meteor(player, new Vector2F(910, 400), new Vector2F(-4.0f, 0.0f)));
+
+           enemies.Enqueue(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
+       }
+
+       // フレーム毎に実行
+       protected override void OnUpdate()
+       {
+           // ステージの更新
+           UpdateStage();
+
+           // カウントを進める
+           count++;
+       }
+
+       // 敵召還関連
+       private void UpdateStage()
+       {
+           // カウントが100の倍数だったら
+           if (count % 100 == 0)
+           {
+               // 敵が残っていたら画面に追加
+               if (enemies.Count > 0)
+               {
+                   characterNode.AddChildNode(enemies.Dequeue());
+               }
+           }
+       }
    }
}
