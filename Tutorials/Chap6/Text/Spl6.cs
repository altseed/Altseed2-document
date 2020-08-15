+       public EnemyBullet(MainNode mainNode, Vector2F position, Vector2F velocity) : base(mainNode, position, velocity)
-       public EnemyBullet(Vector2F position, Vector2F velocity) : base(position, velocity)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Red.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;
        }