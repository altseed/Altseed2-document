using Altseed;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        // カウンタ
        private int count = 0;

        // ウェーブの個数
        private const int waves = 3;

        // 現在ウェーブ
        private int wave = 1;

        // 敵を格納するキュー
        private Queue<Enemy>[] enemies = new Queue<Enemy>[waves];

        // キャラクターを表示するノード
        private Node characterNode = new Node();

        // プレイヤーの参照
        private Player player;

        // スコア
        public int score;

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
            player = new Player(this, new Vector2F(100, 360));

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);

            // 全てのウェーブを初期化する
            InitAllWave();

+           // BGMを初期化する
+           InitBGM();
        }

        // エンジンから削除されたときに実行
        protected override void OnRemoved()
        {
            // 衝突判定を全てリセット
            CollidableObject.objects.Clear();
        }

+       // BGMを初期化
+       private void InitBGM()
+       {
+           // BGMを読み込む
+           var bgm = Sound.LoadStrict("Resources/BGM.wav", false);
+

+           // BGMのプレイ開始
+           Engine.Sound.Play(bgm);
+       }

        // 全ウェーブの初期化
        private void InitAllWave()
        {
            // 各キューの初期化
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Queue<Enemy>();
            }

            // ウェーブ1を初期化
            InitWave1();
            // ウェーブ2を初期化
            InitWave2();
            // ウェーブ3を初期化
            InitWave3();
        }

        // ウェーブ1の初期化
        private void InitWave1()
        {
            // enemies[0].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));

            enemies[0].Enqueue(new Meteor(player, new Vector2F(910, 400), new Vector2F(-4.0f, 0.0f)));

            enemies[0].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
        }

        // ウェーブ2の初期化
        private void InitWave2()
        {
            // enemies[1].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


        }

        // ウェーブ3の初期化
        private void InitWave3()
        {
            // enemies[2].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // ステージの更新
            UpdateStage();

            // カウントを進める
            count++;
        }

        // 敵召還関連
        private void UpdateStage()
        {
            // カウントが100の倍数だったら
            if (count % 100 == 0)
            {
                // 敵が残っていたら画面に追加
                if (enemies[wave - 1].Count > 0)
                {
                    characterNode.AddChildNode(enemies[wave - 1].Dequeue());
                }
                else
                {
                    // カウントをリセット
                    count = 0;

                    //ウェーブを次に進める
                    wave++;
                }
            }
        }
    }
}
