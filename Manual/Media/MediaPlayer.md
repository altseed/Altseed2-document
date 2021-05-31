# MediaPlayer

[MediaPlayer](xref:Altseed2.MediaPlayer)クラスは、映像を再生する機能です。
h264の映像を読み込み、テクスチャに出力します。

パッケージ機能には対応しておらず、映像はパッケージの外に置く必要があります。

以下のように記述して映像を出力します。

```csharp
using System;

using Altseed2;

namespace Sample
{
    class Movie
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("Movie", 640, 480)) return;

            // 空のテクスチャを作成します。
            var texture = Texture2D.Create(new Vector2I(640, 480));

            // 映像を読み込みます。
            var mediaPlayer = MediaPlayer.Load(@"TestData/Movie/Test1.mp4");

            // 映像を再生します。
            mediaPlayer.Play(false);

            // スプライトを描画するノードを作成します。
            var node = new SpriteNode();

            // テクスチャを設定します。
            node.Texture = texture;

            // ノードを登録します。
            Engine.AddNode(node);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // 現在の映像を画像に書き込みます。
                mediaPlayer.WriteToTexture2D(texture);

                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}

```
