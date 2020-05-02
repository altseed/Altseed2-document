namespace Tutorial
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化
            Engine.Initialize("Tutorial", 960, 720);

+           // タイトル画面をエンジンに追加
+           Engine.AddNode(new TitleNode());
-           // メイン画面をエンジンに追加
-           Engine.AddNode(new MainNode());

            // メインループ
            while (Engine.DoEvents())
            {
                …以下略…