using Altseed2;
using System;
using System.Collections.Generic;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
        // コンストラクタ
        public Player(Vector2F position)
        {
            // 座標を設定
            Position = position;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 移動を実行
            Move();

            // ショットを実行
            Shot();
        }

        // 移動を行う
        void Move()
        {
+           // 現在のX座標を取得する
+           var x = Position.X;
+           // 現在のY座標を取得する
+           var y = Position.Y;

            // ↑キーでY座標を減少
            if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold)
            {
-               Position -= new Vector2F(0.0f, 2.5f);
+               y -= 2.5f;
            }

            // ↓キーでY座標を増加
            if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold)
            {
-               Position += new Vector2F(0.0f, 2.5f);
+               y += 2.5f;
            }

            // →キーでX座標を増加
            if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold)
            {
-               Position += new Vector2F(2.5f, 0.0f);
+               x += 2.5f;
            }

            // ←キーでX座標を減少
            if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold)
            {
-               Position -= new Vector2F(2.5f, 0.0f);
+               x -= 2.5f;
            }

+           // テクスチャのサイズの半分を取得する
+           var halfSize = ContentSize / 2;
+
+           // X座標が画面外に行かないように調整
+           x = MathHelper.Clamp(x, Engine.WindowSize.X - halfSize.X, halfSize.X);
+           // Y座標が画面外に行かないように調整
+           y = MathHelper.Clamp(y, Engine.WindowSize.Y - halfSize.Y, halfSize.Y);
+
+           // 調整された座標を設定
+           Position = new Vector2F(x, y);
        }

        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Push)
            {
                // 発射される自機弾
                var bullet = new Bullet(Position);

                // 自機弾をエンジンに追加
                Engine.AddNode(bullet);
            }
        }
    }

    // 弾のクラス
    public class Bullet : SpriteNode
    {
        // コンストラクタ
        public Bullet(Vector2F position)
        {
            // 座標を設定
            Position = position;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

            // 表示位置をプレイヤーや敵より奥に設定
            ZOrder--;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 座標を速度分進める
            Position += new Vector2F(10.0f, 0.0f);
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化
            Engine.Initialize("Tutorial", 960, 720);

            // 自機
            var player = new Player(new Vector2F(100, 360));

            // 自機をエンジンに追加
            Engine.AddNode(player);

            // メインループ
            while (Engine.DoEvents())
            {
                // エンジンを更新
                Engine.Update();

                // Escapeキーでゲーム終了
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push)
                {
                    break;
                }
            }

            // エンジンの終了処理を行う
            Engine.Terminate();
        }
    }
}