using Altseed;

namespace Tutorial
{
    // 敵の基礎となるクラス
    public class Enemy : SpriteNode
    {
        // 倒された時に加算されるスコアの値
        protected int score;
        
        // プレイヤーへの参照
        protected Player player;
        
        // コンストラクタ
        public Enemy(Player player, Vector2F position)
        {
            // 座標を設定
            Position = position;

            // プレイヤーへの参照を設定
            this.player = player;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // CollidableObjectのOnUpdateを実行
            base.OnUpdate();

            // 画面外に出たら自身を削除
            RemoveMyselfIfOutOfWindow();
        }

        // 画面外に出た時自身を消去
        protected void RemoveMyselfIfOutOfWindow()
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
