using Altseed;

class Empty
{
    static void Main(string[] args)
    {
        // Altseedを初期化します。
        Engine.Initialize("Empty", 640, 480);

        // ここで画像などのデータを読み込んだりノードツリーを作成したりすることができます。

        // ゲームのメインループ
        while(Engine.DoEvents())
        {
            // ここに挙動をべた書きすることも可能です。

            // Altseed2 の各種更新処理を行います。
            Engine.Update();
        }

        // Altseedの終了処理をします。
        Engine.Terminate();
    }
}