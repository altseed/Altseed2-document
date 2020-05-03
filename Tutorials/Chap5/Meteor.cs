using Altseed;

namespace Tutorial
{
    // 隕石
    public class Meteor : Enemy
    {
        // フレーム毎の移動速度
        private Vector2F velocity;

        // コンストラクタ
        public Meteor(Player player, Vector2F position, Vector2F velocity) : base(player, position)
        {
            // 速度の設定
            this.velocity = velocity;

            // テクスチャの設定
            Texture = Texture2D.LoadStrict("Resources/Meteor.png");

            // 中心座標の設定
            CenterPosition = Texture.Size / 2;

            // スコアの設定
            score = 1;
        }

        // 毎フレーム実行
        protected override void OnUpdate()
        {
            // 座標を速度分加算
            Position += velocity;

            // EnemyクラスのOnUpdate呼び出し
            base.OnUpdate();
        }
    }
}
