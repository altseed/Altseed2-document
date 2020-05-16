using Altseed;
using System;
using System.Collections.Generic;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
+       // コンストラクタ
+       public Player(Vector2F position)
+       {
+           // 座標を設定
+           Position = position;
+
+           // テクスチャを読み込む
+           Texture = Texture2D.LoadStrict("Resources/Player.png");
+
+           // 中心座標を設定
+           CenterPosition = Texture.Size / 2;
+       }

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
            // ↑キーでY座標を減少
            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold)
            {
                Position += new Vector2F(0.0f, -2.5f);
            }

            // ↓キーでY座標を増加
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold)
            {
                Position += new Vector2F(0.0f, 2.5f);
            }

            // →キーでX座標を増加
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold)
            {
                Position += new Vector2F(2.5f, 0.0f);
            }

            // ←キーでX座標を減少
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold)
            {
                Position -= new Vector2F(2.5f, 0.0f);
            }
        }

        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                // 発射される自機弾
-               var bullet = new Bullet();
+               var bullet = new Bullet(Position);

-               // 自機弾のテクスチャを読み込む
-               bullet.Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");
-               // 自機弾の座標を設定
-               bullet.Position = player.Position;
-               // 自機弾の中心座標を設定
-               bullet.CenterPosition = bullet.Texture.Size / 2;
-               // 自機弾の表示位置を自機より奥に設定
-               bullet.ZOrder--;

                // 自機弾をエンジンに追加
                Engine.AddNode(bullet);
            }
        }
    }

    // 弾のクラス
    public class Bullet : SpriteNode
    {
+       // コンストラクタ
+       public Bullet(Vector2F position)
+       {
+           // 座標を設定
+           Position = position;
+
+           // テクスチャを読み込む
+           Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");
+
+           // 中心座標を設定
+           CenterPosition = Texture.Size / 2;
+
+           // 表示位置をプレイヤーや敵より奥に設定
+           ZOrder--;
+       }

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
-           var player = new Player();
+           var player = new Player(new Vector2F(100, 360));
-           // 自機のテクスチャを読み込む
-           player.Texture = Texture2D.LoadStrict("Resources/Player.png");
-           // 自機の座標を設定
-           player.Position = new Vector2F(100, 360);
-           // 自機の中心座標を設定
-           player.CenterPosition = player.Texture.Size / 2;

            // 自機をエンジンに追加
            Engine.AddNode(player);

            // メインループ
            while (Engine.DoEvents())
            {
                // エンジンを更新
                Engine.Update();

                // Escapeキーでゲーム終了
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push)
                {
                    break;
                }
            }

            // エンジンの終了処理を行う
            Engine.Terminate();
        }
    }
}