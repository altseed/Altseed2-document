//////////////////////////////////////////////////////////////////////
//
//    Sound・SoundMixerを使ってBGMを再生するサンプル
//

using Altseed;

class Sound_BGM
{
    static void Main(string[] args)
    {
        // Altseedを初期化する.
        Engine.Initialize("Sound_SE", 640, 480);

        // 音ファイルを読み込む.
        // BGMの場合,第2引数をfalseに設定することで,再生しながらファイルを解凍することが推奨されている.
        Sound bgm = Sound.Load("bgm1.ogg", false);

        // 音を再生する.
        int id_bgm = Engine.Sound.Play(bgm);

        // Altseedのウインドウが閉じられていないか確認する.
        while(Engine.DoEvents())
        {
            // Altseedを更新する.
            Engine.Update();

            // 音の再生が終了しているか調べる.
            if(!Engine.Sound.GetIsPlaying(id_bgm))
            {
                break;
            }
        }

        // Altseedの終了処理をする.
        Engine.Terminate();
    }
}