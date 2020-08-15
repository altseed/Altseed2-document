        public StraightShotEnemy(Player player, Vector2F position) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // 倒された時に加算されるスコアを設定
            score = 20;
        }

                // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
+            Parent.AddChildNode(new EnemyBullet(mainNode, Position, velocity));
-            Parent.AddChildNode(new EnemyBullet(Position, velocity));
        }
