using Altseed;

namespace Tutorial
{
    // 弾のクラス
    public class Bullet : SpriteNode
    {
        // フレーム毎に進む距離
        private Vector2F velocity;

        ------removed start------

        // コンストラクタ
        public Bullet(Vector2F position, Vector2F velocity)
        {
            // 座標を設定
            Position = position;

            // 弾速を設定
            this.velocity = velocity;

            // 表示位置をプレイヤーや敵より奥に設定
            ZOrder--;
        }

        ------removed end------

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 座標を速度分進める
            Position += velocity;

            // CollidableObjectのOnUpdateを呼び出す
            base.OnUpdate();

            // 画面外に出たら自身を削除
            RemoveMyselfIfOutOfWindow();
        }

        // 画面外に出た時自身を消去
        private void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X
                || Position.X > Engine.WindowSize.X + halfSize.X
                || Position.Y < -halfSize.Y
                || Position.Y > Engine.WindowSize.Y + halfSize.Y)
            {
                // 自身を削除
                Parent?.RemoveChildNode(this);
            }
        }
    }
}
