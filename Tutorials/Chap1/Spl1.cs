using Altseed;
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