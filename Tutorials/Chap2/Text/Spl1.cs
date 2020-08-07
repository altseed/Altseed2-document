using Altseed2;
using System;

namespace Tutorial
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化
            Engine.Initialize("Tutorial", 960, 720);

+           // 自機
+           var player = new SpriteNode();
+           // 自機のテクスチャを読み込む
+           player.Texture = Texture2D.LoadStrict("Resources/Player.png");
+           // 自機の座標を設定
+           player.Position = new Vector2F(100, 360);
+           // 自機の中心座標を設定
+           player.CenterPosition = player.ContentSize / 2;
+
+           // 自機をエンジンに追加
+           Engine.AddNode(player);

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