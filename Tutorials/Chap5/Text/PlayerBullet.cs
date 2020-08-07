using Altseed2;

namespace Tutorial
{
    // 自機弾
    public class PlayerBullet : Bullet
    {
        // コンストラクタ
        public PlayerBullet(Vector2F position) : base(position, new Vector2F(10f, 0.0f))
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;
        }
    }
}
