using Altseed;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        ...略...

        // 敵召還関連
        private void UpdateStage()
        {
            // カウントが100の倍数だったら
            if (count % 100 == 0)
            {
                // 敵が残っていたら画面に追加
                if (enemies[wave - 1].Count > 0)
                {
                    characterNode.AddChildNode(enemies[wave - 1].Dequeue());
                }
                else
                {
                    // カウントをリセット
                    count = 0;

                    //ウェーブを次に進める
                    wave++;

+                   // もし最終ウェーブが終わっていて，かつ画面遷移中でなければ実行
+                   if (wave > waves && !fading)
+                   {
+                       // BGMをフェードアウト
+                       if (bgmID.HasValue)
+                       {
+                           Engine.Sound.FadeOut(bgmID.Value, 1.0f);
+
+                           // BGMが止まったのでIDをnullに
+                           bgmID = null;
+                       }
+
+                       // エンジンから自身を削除
+                       Engine.RemoveNode(this);
+
+                       // クリア画面をエンジンに追加
+                       Engine.AddNode(new LevelCompletedNode());
+
+                       // 画面遷移中フラグを立てる
+                       fading = true;
+                   }
                }
            }
        }
    }
}
