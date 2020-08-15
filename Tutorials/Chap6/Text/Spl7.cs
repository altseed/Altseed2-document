+       public PlayerBullet(MainNode mainNode, Vector2F position) : base(mainNode, position, new Vector2F(10f, 0.0f))
-       public PlayerBullet(Vector2F position) : base(position, new Vector2F(10f, 0.0f))
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;
        }