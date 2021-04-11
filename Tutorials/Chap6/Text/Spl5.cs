using Altseed2;

namespace Tutorial
{
    // 弾のクラス
    public class Bullet : CollidableObject
    {
        // フレーム毎に進む距離
        private Vector2F velocity;

        // コンストラクタ
-       public Bullet(Vector2F position, Vector2F velocity)
+       public Bullet(MainNode mainNode, Vector2F position, Vector2F velocity) : base(mainNode, position)
        {
+           // 衝突判定を行わないように設定
+           doSurvey = false;

-           // 座標を設定
-           Position = position;

            // 弾速を設定
            this.velocity = velocity;

            // 表示位置をプレイヤーや敵より奥に設定
            ZOrder--;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 座標を速度分進める
            Position += velocity;

+           // CollidableObjectのOnUpdateを呼び出す
+           base.OnUpdate();

            // 画面外に出たら自身を削除
            RemoveMyselfIfOutOfWindow();
        }

-       private void RemoveMyselfIfOutOfWindow()
-       {
-           var halfSize = Texture.Size / 2;
-           if (Position.X < -halfSize.X
-               || Position.X > Engine.WindowSize.X + halfSize.X
-               || Position.Y < -halfSize.Y
-               || Position.Y > Engine.WindowSize.Y + halfSize.Y)
-           {
-               // 画面外に出たら自身を削除
-               Parent?.RemoveChildNode(this);
-           }
-       }
    }
}
