using Altseed;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        ...略...

        // 現在ウェーブを表示するノード
        private TextNode waveNode;

+       // 他画面へ遷移しているかどうか
+       private bool fading = false;

        // スコア
        public int score;

        ...略...

+       // ゲームオーバー画面に遷移
+       public void ToGameOver()
+       {
+           // BGMをフェードアウト
+           if (bgmID.HasValue)
+           {
+               Engine.Sound.FadeOut(bgmID.Value, 1.0f);
+
+               // BGMが止まったのでIDをnullに
+               bgmID = null;
+           }
+
+           // 画面遷移中でないなら遷移処理を実行
+           if (!fading)
+           {
+               // 自身をエンジンから削除
+               Engine.RemoveNode(this);
+
+               // エンジンにゲームオーバー画面を追加
+               Engine.AddNode(new GameOverNode());
+
+               // 遷移中フラグを縦立てる
+               fading = true;
+           }
+       }

        // 敵召還関連
        private void UpdateStage()
        ...略...
    }
}
