using Altseed2;
using System;
using System.Collections.Generic;

namespace Tutorial
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化
            Engine.Initialize("Tutorial", 960, 720);

-           // 自機
-           var player = new Player(new Vector2F(100, 360));
-
-           // 自機をエンジンに追加
-           Engine.AddNode(player);
+           // メイン画面をエンジンに追加
+           Engine.AddNode(new MainNode());

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