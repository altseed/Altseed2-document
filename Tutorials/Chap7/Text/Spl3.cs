using Altseed2;

namespace Tutorial
{
    // 敵の基礎となるクラス
    public class Enemy : CollidableObject
    {
        // 倒された時に加算されるスコアの値
        protected int score;

        // プレイヤーへの参照
        protected Player player;

        // コンストラクタ
        public Enemy(Player player, Vector2F position) : base(player.mainNode, position)
        {
            // 衝突判定を行うように設定
            doSurvey = true;

            // プレイヤーへの参照を設定
            this.player = player;
        }

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象が自機弾だったら
            if (obj is PlayerBullet)
            {
                // スコアを加算
                mainNode.score += score;

                // 死亡時エフェクトを再生
                Parent.AddChildNode(new DeathEffect(Position));

                // 自身を削除
                Parent.RemoveChildNode(this);

+               // 死亡時サウンドを読み込み
+               var deathSound = Sound.LoadStrict("Resources/Explosion.wav", true);
+
+               // 死亡時サウンドを再生
+               Engine.Sound.Play(deathSound);
            }
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // CollidableObjectのOnUpdateを実行
            base.OnUpdate();

            // 画面外に出たら自身を削除
            RemoveMyselfIfOutOfWindow();
        }
    }
}
