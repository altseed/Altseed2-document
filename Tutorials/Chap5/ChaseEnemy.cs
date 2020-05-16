using Altseed;

namespace Tutorial
{
    // 追跡型敵
    public class ChaseEnemy : Enemy
    {
        // 移動速度
        private float speed;

        // コンストラクタ
        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // 移動速度を設定
            this.speed = speed;

            // 自身が倒された時に加算されるスコアを設定
            score = 10;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // プレイヤーへのベクトルの単位ベクトルを取得
            var vector = (player.Position - Position).Normal;

            // ベクトルの長さを調整
            vector *= speed;

            // ベクトル分座標を動かす
            Position += vector;

            // EnemyのOnUpdateを実行
            base.OnUpdate();
        }
    }
}