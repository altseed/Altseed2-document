using Altseed;

namespace Tutorial
{
    // 弾のクラス
    public class Bullet : SpriteNode
    {
        // フレーム毎に進む距離
        private Vector2F velocity;

-        // コンストラクタ
-        public Bullet(Vector2F position, Vector2F velocity)
-        {
-            // 座標を設定
-            Position = position;
-
-            // 弾速を設定
-            this.velocity = velocity;
-
-            // 表示位置をプレイヤーや敵より奥に設定
-            ZOrder--;
-        }

        // ================================================================
        // 省略
        // ================================================================
    }
}
