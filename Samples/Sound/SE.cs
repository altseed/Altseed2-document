//////////////////////////////////////////////////////////////////////
//
//    Sound・SoundMixerを使って効果音を再生するサンプル
//

using Altseed;

class Sound_SE
{
    static void Main(string[] args)
    {
        // Altseedを初期化する.
        Engine.Initialize("Sound_SE", 640, 480);

        // 音ファイルを読み込む.
        // 効果音の場合,第2引数をtrueに設定することで,この場でファイルを解凍することが推奨されている.
        Sound se = Sound.Load("se1.wav", true);

        // 音を再生する.
        int id_se = Engine.Sound.Play(se);

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