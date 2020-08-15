using Altseed2;

namespace Tutorial
{
    // 敵の基礎となるクラス
    public class Enemy : CollidableObject
    {

        ...略...

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象が自機弾だったら
            if (obj is PlayerBullet)
            {
+               // スコアを加算
+               mainNode.score += score;

                // 死亡時エフェクトを再生
                Parent.AddChildNode(new DeathEffect(Position));

                // 自身を削除
                Parent.RemoveChildNode(this);

                // 死亡時サウンドを読み込み
                var deathSound = Sound.LoadStrict("Resources/Explosion.wav", true);

                // 死亡時サウンドを再生
                Engine.Sound.Play(deathSound);
            }
        }

        ...略...

    }
}
